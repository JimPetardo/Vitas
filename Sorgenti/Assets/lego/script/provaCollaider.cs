using UnityEngine;
using System.Collections;

//quando collido con il bottone crea il cubetto del relativo colore
public class provaCollaider : MonoBehaviour {

	//Assegno da unity il blocco che voglio far comparire
	public GameObject Brick;
	//Variabile di supporto per creare cloni delle lego
	private GameObject clone;
	//Conta il tempo trascorso
	public float TempoAttuale;

	//la funzione Start viene chiamata uno sola volta all inizio 
	void Start () {
		//Azzero il tempo attuale
		TempoAttuale = (float)Time.time;
	}


	void OnCollisionEnter() {
		//Metto del tempo per non far creare piu blocchi per sbaglio
		if (( (float)Time.time - TempoAttuale) > 1.0f) {
			//creo un clone del blocchetto
			clone = Instantiate(Brick) as GameObject;	
			//lo posiziono nel posto di creazione
			clone.transform.position = new Vector3 (transform.position.x+0.2f, transform.position.y, transform.position.z);
			TempoAttuale = (float)Time.time;
		}


	}

}
