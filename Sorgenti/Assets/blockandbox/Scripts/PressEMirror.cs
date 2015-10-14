using UnityEngine;
using System.Collections;

public class PressEMirror : MonoBehaviour {

	private bool collider = false;
	private int dist = 1; //distance at which you can pick things up
	public Transform Object3;
	void OnGUI()
	{
		if (collider == true)
		{    
			//GUI.Box(Rect(140,Screen.height-50,Screen.width-300,120),("PREMI E"));
			GUI.Label (new Rect(Screen.width/2,Screen.height/2 -13,100,100), "Mirror");
			GUI.Label (new Rect(Screen.width/2,Screen.height/2,100,100), "Premi E");
		}
	}
	void Update () {
		if(Vector3.Distance(transform.position, Object3.position) < dist) //if distance is less than dist variable
		{
			collider = true;
		}else{
			collider = false;
		} 
		if(Input.GetKeyDown(KeyCode.E)){ //if you press 'q'
			
			if(Vector3.Distance(transform.position, Object3.position) < dist) //if distance is less than dist variable
			{
				Application.LoadLevel ("Tuscany_mirror");
			}
		}
		
	}
}