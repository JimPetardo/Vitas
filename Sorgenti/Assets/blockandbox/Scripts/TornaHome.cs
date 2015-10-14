using UnityEngine;
using System.Collections;

public class TornaHome : MonoBehaviour {

	/*void OnGUI()
	{  
			//GUI.Box(Rect(140,Screen.height-50,Screen.width-300,120),("PREMI E"));
			GUI.Label (new Rect (0, 0, 200, 100), "Premi A per posizionare a Sinistra");
			GUI.Label (new Rect (0, 15, 200, 100), "Premi S per posizionare Sopra");
			GUI.Label (new Rect (0, 30, 200, 100), "Premi D per posizionare a Destra");
			GUI.Label (new Rect (0, 60, 200, 100), "Z Reset");

	}*/
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Q)){
			
			Application.LoadLevel ("Tuscany_Completo");
		}
	}
}
