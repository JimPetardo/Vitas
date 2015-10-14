using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class colliderS : MonoBehaviour {

	//variabile tempo
	public float timeLeft = 300;
	//mano che tocca il bottone
	private string manoToccata;
	//audio per bottone
	public AudioClip ButtonSound;
	//conteggio per l effettivo tocco della stella
	private int count;
	//punteggio globale 
	public static int punteggio;
	//ora e data per nome del file di salvataggio
	private string ora;
	//tempo per l esecuzione
	private static DateTime now = DateTime.Now;
	//	//lista di frasi scritte su file
	public static string[] arrayStrighe = new string[180];

	private string nome;
	private string cognome;

	//resetto il conteggio per verificare l effettivo tocco della stella
	void OnCollisionEnter() {
		audio.PlayOneShot (ButtonSound);
		count = 0;
	}
	void Start(){
		StreamReader streamReader = new StreamReader("settings.txt");
		//scorro le prime linee che non mi servono
		nome = streamReader.ReadLine();
		cognome = streamReader.ReadLine();
		streamReader.Close();
	}
	//la stella e toccata solo se si sta per qualche momento sopra
	void OnCollisionExit(Collision mano) {
		if (count > 10) {
			//controllo l'oggetto che ha avuto una collisione e successivamente lo nomino con il nome della mano toccata
			if (mano.collider.gameObject.name == "bone3")
				manoToccata = "1";

			if (mano.collider.gameObject.name == "destra")
				manoToccata = "0";

			arrayStrighe[punteggio]= ((punteggio+1) +"\t"+(300-timeLeft).ToString("F2")+"\t"+"1"+"\t"+((this.transform.position.z- 6.375 )/3).ToString("F5") +"\t" +((this.transform.position.y - 4.57)/3).ToString("F5")+"\t"+manoToccata+"\t");

			//aumentiamo il punteggio
			punteggio++;

			//toglie la stella toccata
			Destroy (gameObject);
		}
			//tolgo l intensita luminosa dalla stella 
			else
			this.light.intensity=0;	
	}
	
	//quando si sta sulla stella viene illuminata 
	void OnCollisionStay() {
		this.light.intensity = 8;
		count++;
		
	}
	//visualizzo il punteggio sulla Gui 
	void OnGUI() {
		GUIStyle myStyle = new GUIStyle();
		myStyle.fontSize = Screen.width/40;
		myStyle.normal.textColor = Color.white;

		GUILayout.Label("  TIME LEFT: " + timeLeft.ToString("F2") + " \n  SCORE: "+punteggio+"/42", myStyle);

	}
	//Quando si preme il tasto S le statistiche vengono salvate
	void Update () {
		timeLeft -= Time.deltaTime;

		if (Input.GetKey (KeyCode.S))
			OnApplicationSave ();

	}


	//Salviamo su un file 
	void OnApplicationSave() {
		//sistemo l ora in quanto darebbe problemi di caratteri speciali sul nome del file
		ora = now.ToString ();
		ora = ora.Replace('/','-');
		ora = ora.Replace(' ','_');
		ora = ora.Replace(':','-');
		//Scrivo il punteggio su file esterno
		System.IO.File.WriteAllText ("save/TestStelle_"+nome+cognome+ora + ".txt", "");

		for (int i = 0; i <= punteggio; i++)
		{

			System.IO.File.AppendAllText ("save/TestStelle_"+nome+cognome + ora + ".txt", arrayStrighe[i]+"\n" );

		}


		//per ogni stella nell array
		foreach (var gameObj in FindObjectsOfType(typeof(GameObject)) as GameObject[]) {
			if (gameObj.name == "Stellina") {

				System.IO.File.AppendAllText ("save/TestStelle_"+nome+cognome + ora + ".txt", "0" +"	"+(300-timeLeft).ToString("F2")+"	"+"0"+"	"+((gameObj.transform.position.z- 6.375 )/3).ToString("F5") +"	" +((gameObj.transform.position.y - 4.57)/3).ToString("F5")+"	"+"0"+"\n");
			}}
		
	}




}
