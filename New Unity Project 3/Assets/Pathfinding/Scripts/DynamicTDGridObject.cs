using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public class DynamicTDGridObject : MonoBehaviour 
{
    private List<Vector2> IDs = new List<Vector2>();

    public float lowestY = 0F;
    public float timer = 0F;
    public bool SetTimer = false;

    private Vector3 lastPos = Vector3.zero;
    private Quaternion lastRot = Quaternion.identity;

    void Start()
    {
        StartCoroutine(DelayStart()); 
    }

    void Update()
    {
        if (!SetTimer)
        {
            if (transform.position != lastPos || transform.rotation != lastRot)
            {
                lastPos = transform.position;
                lastRot = transform.rotation;
                RemoveFromMap();
                UpdateMap();
            }
        }
    }

    void OnDestroy()
    {
        RemoveFromMap();
    }

    public void UpdateMap()
    {
        List<Vector3> checkList = new List<Vector3>();
        Bounds bR = renderer.bounds;
        Bounds bM = gameObject.GetComponent<MeshFilter>().mesh.bounds;
        checkList = DynamicSetupList(bR.min.x, bR.max.x, bR.min.z, bR.max.z, bR, bM);
  
        Pathfinder.Instance.DynamicMapEdit(checkList, UpdateList);
    }

    public void RemoveFromMap()
    {
        if (IDs != null)
        {
            Pathfinder.Instance.DynamicRedoMapEdit(IDs);
        }
    }

    private void UpdateList(List<Vector2> ids)
    {
        IDs = ids;
    }

    private List<Vector3> DynamicSetupList(float minX, float maxX, float minZ, float maxZ, Bounds bR, Bounds bM)
    {      
        List<Vector3> checkList = new List<Vector3>();
        float Tilesize = Pathfinder.Instance.Tilesize;

        for (float i = minZ; i < maxZ; i += Tilesize / 2)
        {
            for (float j = minX; j < maxX; j += Tilesize / 2)
            {
                for (float k = bR.min.y; k < bR.max.y; k += Tilesize)
                {
                    if (k > lowestY)
                    {
                        Vector3 local = transform.InverseTransformPoint(new Vector3(j, k, i));

                        if (bM.Contains(local))
                        {
                            checkList.Add(new Vector3(j, k, i));
                        }
                    }
                }
            }
        }
        return checkList;
    }

    IEnumerator CoroutineUpdate(float _timer)
    {
        if (transform.position != lastPos || transform.rotation != lastRot)
        {
            lastPos = transform.position;
            lastRot = transform.rotation;
            RemoveFromMap();
            UpdateMap();
        }
        
        //Wait amount of time and call its self recursively
        yield return new WaitForSeconds(_timer);
        StartCoroutine(CoroutineUpdate(_timer));
    }

    IEnumerator DelayStart()
    {
        yield return new WaitForEndOfFrame();

        lastPos = transform.position;
        lastRot = transform.rotation;
        UpdateMap();

        if (SetTimer)
        {
            StartCoroutine(CoroutineUpdate(0.2f)); //Calls it 5 times per second
        }
    }
}
