using UnityEngine;
using System.Collections;

//Script per implementare i vari movimenti delle lego mentre collidono con altri blocchi

public class ColliderLego : MonoBehaviour {

	//ON-OFF sulle istruzioni da visualizzare
	private bool istruzuoni = false;
	//Texture delle istruzioni da utilizzare all interno di OnGui
	public Texture aTexture;

	//La funzione OnGui fa comparire componenti a livello gui che vengono visualizzati in primo piano sulla telecaamera
	void OnGUI () {
		//Bottone che premendolo si visualizzano le istruzioni
		if (GUI.Button (new Rect (0, 0, 150, 40), "Instructions ON/OFF")) {
			//premendo compaiono le istruzioni o se sono gia visibili vengono nascoste
			if(istruzuoni)
				istruzuoni = false;
			else
				istruzuoni = true;

			}

		if (istruzuoni) {
			//visualizza la texture delle istruzioni
			GUI.DrawTexture(new Rect(Screen.width/2 -250,Screen.height/2 -200 ,500,500), aTexture);
		}
	}


	//La fiunzione Update viene chiamata ad ogni frame(30 volte al secondo)
	void Update(){
		//Premendo il tasto Z faccio sbloccare tutti i blocchi
		if (Input.GetKeyDown(KeyCode.Z))
		{
			//Blocco la rotazione di tutte le lego
			rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
			//le sposto un po per non farle collidare evitando eventuali bug
			transform.position = new Vector3 (this.transform.position.x, this.transform.position.y +0.06f, this.transform.position.z);
		}

	}

	//Funzione che viene chiamata quando l oggetto a cui e attaccato lo script collide, l oggetto con cui collide e col
	void OnCollisionEnter(Collision col) {
		//Prendo il componente GrabbableObject per controllare che la lego sia grabbata
		GrabbableObject grabbato = this.GetComponent<GrabbableObject>();

		//Controllo tutti i possibili blocchi quindi marrone, rosso, blu e giallo
		if(grabbato.grabbed_) {
			if(col.gameObject.name == "legoBrickMarrone(Clone)" ||
			   col.gameObject.name == "legoBrickRosso(Clone)" ||
			   col.gameObject.name == "legoBrickGiallo(Clone)" ||
			   col.gameObject.name == "legoBrickBlue(Clone)")
			{
				//Se premo il tasto S il blocco viene posizionato in alto
				if (Input.GetKey(KeyCode.S)){
					//sposto il cubetto nella posizione corretta
					this.transform.position = new Vector3 (col.transform.position.x, col.transform.position.y +0.045f, col.transform.position.z);
					//freezo quello principale
					this.rigidbody.constraints = RigidbodyConstraints.FreezePositionX |RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ|
						RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
					//freezo il cubetto sotto
					col.rigidbody.constraints = RigidbodyConstraints.FreezePositionX |RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ|
						RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
					//tolgo il grab per evitare bug
					grabbato.grabbed_ = false;

				}
				//Se premo il tasto S il blocco viene posizionato in alto a sinistra
				if (Input.GetKey(KeyCode.A)){
					//sposto il cubetto nella posizione corretta
					this.transform.position = new Vector3 (col.transform.position.x, col.transform.position.y +0.045f, col.transform.position.z-0.04f);
					//frezo quello principale
					this.rigidbody.constraints = RigidbodyConstraints.FreezePositionX |RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ|
						RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
					//frezo il cubetto sotto
					col.rigidbody.constraints = RigidbodyConstraints.FreezePositionX |RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ|
						RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
					//tolgo il grab per evitare bug
					grabbato.grabbed_ = false;

				}
				//Se premo il tasto S il blocco viene posizionato in alto a destra
				if (Input.GetKey(KeyCode.D)){
					//sposto il cubetto nella posizione corretta
					this.transform.position = new Vector3 (col.transform.position.x, col.transform.position.y +0.045f, col.transform.position.z+0.04f);
					//frezo quello principale
					this.rigidbody.constraints = RigidbodyConstraints.FreezePositionX |RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ|
						RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
					//frezo il cubetto sotto
					col.rigidbody.constraints = RigidbodyConstraints.FreezePositionX |RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ|
						RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
					//tolgo il grab per evitare bug
					grabbato.grabbed_ = false;

				}
				//Se premo il tasto S il blocco viene posizionato a sinistra
				if (Input.GetKey(KeyCode.F)){
					//sposto il cubetto nella posizione corretta
					this.transform.position = new Vector3 (col.transform.position.x, col.transform.position.y, col.transform.position.z-0.07f);
					//frezo quello principale
					this.rigidbody.constraints = RigidbodyConstraints.FreezePositionX |RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ|
						RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
					//frezo il cubetto sotto
					col.rigidbody.constraints = RigidbodyConstraints.FreezePositionX |RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ|
						RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
					//tolgo il grab per evitare bug
					grabbato.grabbed_ = false;
					
				}
				//Se premo il tasto S il blocco viene posizionato a destra
				if (Input.GetKey(KeyCode.G)){
					//sposto il cubetto nella posizione corretta
					this.transform.position = new Vector3 (col.transform.position.x, col.transform.position.y, col.transform.position.z+0.07f);
					//frezo quello principale
					this.rigidbody.constraints = RigidbodyConstraints.FreezePositionX |RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ|
						RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
					//frezo il cubetto sotto
					col.rigidbody.constraints = RigidbodyConstraints.FreezePositionX |RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ|
						RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
					//tolgo il grab per evitare bug
					grabbato.grabbed_ = false;
					
				}

			}	

		}

		
	}

}