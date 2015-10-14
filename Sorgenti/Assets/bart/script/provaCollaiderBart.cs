using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//for writing in file
using System.IO;
using System;

public class provaCollaiderBart : MonoBehaviour {

	//stampa a schermo il punteggio
	void OnGUI () {
		GUIStyle myStyle = new GUIStyle();
		myStyle.fontSize = Screen.width/40;
		myStyle.normal.textColor = Color.white;

		GUILayout.Label("  TIME LEFT: "+ timeLeftRecived.ToString ("F2") + " \n  SCORE: " + punti+" / "+ prove, myStyle);
	}

	public AudioClip ButtonSound;
	//bottone contenente lo script bart
	public GameObject redBotton;
	//tempo rimasto ricavato dal bart
	private float timeLeftRecived = 0.0f;
	//prove ricavate dal bart
	private int prove = 0;
	//punteggio 
	public  static int punti = 0;
	//ora attuale
	private string ora = "";
	//mano che viene utilizzata per toccare il bottone
	private string manoToccata = "";
	//blocco per non eseguire più di una volta la funzione statistic
	private bool LockforStatistic=false;
	//frase in caso di fallimento
	private static string frase = "" ;
	//frase in caso di successo
	private static string frase2 = "";
	//inizialmente a 500 per garantire la diversità da zero il primo ciclo 
	//serve per chiamare statistic solo quando prove != proveOld
	private static int proveOld=500;
	//	//lista di frasi scritte su file
	public static string[] arrayStrighe = new string[182];

	private string nome = "";
	private string cognome = "";


	void OnCollisionEnter(Collision mano) {

		//this will get called whenever this gameObject collides with another gameObject (or the other way around) use (GameObject variableName) as parameters for this function if you only want, for example, change the color when objects with a certain tag collide with it

		//coloro il material di rosso avvio il suono e aggiuno un punto poichè il bottone è stato toccato
		if (renderer.material.color != Color.red) {
			punti++;
			audio.PlayOneShot (ButtonSound);
		}
		//controllo l'oggetto che ha avuto una collisione e successivamente lo nomino con il nome della mano toccata
		if (mano.collider.gameObject.name == "bone3")
			manoToccata = "0";
	
		if (mano.collider.gameObject.name == "destra")
			manoToccata = "1";
		//creo la frase di successo
		frase2 = prove + "\t" + (-timeLeftRecived + 181).ToString("F1") + "\t1\t" + "\t" + (this.transform.position.x + 3.98f).ToString("F4") + "\t" + (this.transform.position.z - 11.05f).ToString("F4") + "\t" + manoToccata;
		//prendo la stringa in posizione prova (segnata di falimento di default) e  la sostituisco con la frase di successo
		arrayStrighe [prove] = frase2;
		renderer.material.color = Color.red;


	}

	//scrive le statistiche per ogni bottone comparso
	void statistiche (){

		LockforStatistic = false;


		frase =  prove + "\t"+(-timeLeftRecived + 181 ).ToString("F1")+"\t0\t";
		arrayStrighe [prove] = frase;
	//181 secondi finiti
		if (timeLeftRecived < 0) {
			print ("fine");
		}

	



	}

	//salvataggio dei dati dall'applicazione

	void OnApplicationSave() {
		DateTime now = DateTime.Now;
		//per evitare problemi di creazione del file cambio i caratteri non ammessi per directory
		ora = now.ToString ();
		ora = ora.Replace('/','-');
		ora = ora.Replace(' ','_');
		ora = ora.Replace(':','-');
		// scrittura su file
		System.IO.File.WriteAllText("save/Bart_"+nome+cognome+ora+".txt", "");
		for (int i = 1; i < 180; i++) {
		
			System.IO.File.AppendAllText ("save/Bart_"+nome+cognome+ora+".txt", arrayStrighe[i]+ "\n" );

		
		}

	}

	void Start(){



		StreamReader streamReader = new StreamReader("settings.txt");
		//scorro le prime linee che non mi servono
		nome = streamReader.ReadLine();
		cognome = streamReader.ReadLine();
		streamReader.Close();
	}

	// Update is called once per frame

	void Update () {
		//semaforo di salvataggio
		if (Input.GetKey (KeyCode.S))
			OnApplicationSave ();
		//recupero e salvataggio in variabili locali dati da componente Bart
		Bart script = (Bart)redBotton.GetComponent("Bart");
		prove = script.GetProve();
		timeLeftRecived = script.timeLeft;

		// controllo per chiamare statistic ogni 1.8 secondi
		if (((script.timeLeft % 1.8) > 1.7) && (prove!=proveOld)){
			proveOld = prove;
			LockforStatistic = true;

		}

		if (LockforStatistic) {
			statistiche ();
		}

	}



}

