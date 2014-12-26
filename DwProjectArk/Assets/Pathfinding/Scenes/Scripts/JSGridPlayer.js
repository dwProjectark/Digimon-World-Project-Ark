#pragma strict

class JSGridPlayer extends JSPath
{
	function Update()
	{
		FindPath();
		MoveMethod();
	}
	
	private function MoveMethod()
    {
        if (Index < Path.Length-1)
        {
           var pathVector : Vector3 = Path[Index];
           pathVector.y = 0;
           var direction = (pathVector - transform.position).normalized;

           transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, Time.deltaTime * 14F);
           if (transform.position.x < pathVector.x + 0.4F && transform.position.x > pathVector.x - 0.4F && transform.position.z > pathVector.z - 0.4F && transform.position.z < pathVector.z + 0.4F)
           {
                Index++;
           }           
        }
    }
    
    private function FindPath()
    {
    	if (Input.GetButtonDown("Fire1"))
        {
            var ray : Ray;
            ray = Camera.mainCamera.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            var hit : RaycastHit;

            if (Physics.Raycast(ray, hit, Mathf.Infinity))
            {
                CallJSPath(transform.position, hit.point);
            }      
        }
    }
}