#pragma strict

class JSPath extends MonoBehaviour
{
	protected var Path : Vector3[] = new Vector3[0];
	protected var Index : int = 0;
	
	function Start()
	{
	
	}
	
	function GetJSPath(path : Vector3[])
	{       
        if(Path.Length > 0)
	    {
	    	Path = new Vector3[0];
	    }	
	    
	    //We reset path and index   	        	    
	    Index = 0;
	    Path = path;
	}
	
	public function CallJSPath(start : Vector3, end : Vector3)
	{
		var arr : Vector3[] = new Vector3[2];
		arr[0] = start;
		arr[1] = end;
		gameObject.SendMessage("FindJSPath", arr);
	}
}

