using UnityEngine;
using System.Collections;

public class PressE : MonoBehaviour {

	private int dist = 1; //distance at which you can pick things up
	public Transform Object1;
	void Update () {
		
		if(Input.GetKeyDown(KeyCode.Q)){ //if you press 'q'
			
			if(Vector3.Distance(transform.position, Object1.position) < dist) //if distance is less than dist variable
			{
				print("canguro nano");
			}
		}

	}
}