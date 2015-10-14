using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

public class Punteggio : MonoBehaviour {
	//punteggio
	public static int score;
	//semaforo dare un solo punto
	private bool soloUnPunto = false;
	//tempo rimasto
	private float timeLeft = 60;
	private float timeOld = 60;

	//tempo in cui si tiene l'oggetto in mano
	private float timeGrabbed = 0;
	//media di TimeGrabbed
	private float media;
	//ora per salvataggio file
	private string ora;
	//lista dei tempi
	public static List<float> listaTempi = new List<float>();
	//lista dei successi
	public static List<int> success = new List<int>();
	//tempo trascorso dallo start
	public static List<float> timeFromStart = new List<float>();
	//lista per posizioni cubo
	public static List<float> listaPuntiCuboX = new List<float>();
	public static List<float> listaPuntiCuboY = new List<float>();
	public static List<float> listaPuntiCuboZ = new List<float>();
	// Use this for initialization

	private string nome;
	private string cognome;

	//stampa a schermo
	void OnGUI() {
		GUIStyle myStyle = new GUIStyle();
		myStyle.fontSize = Screen.width/40;
		myStyle.normal.textColor = Color.white;


		GUILayout.Label("  TIME LEFT: "+ timeLeft.ToString ("F2") + " \n  SCORE: "+ score, myStyle);

	}

	void Start () {

		//inizializzazione ora
			DateTime now = DateTime.Now;
			ora = now.ToString ();
			ora = ora.Replace ('/', '-');
			ora = ora.Replace (' ', '_');
			ora = ora.Replace (':', '-');

		StreamReader streamReader = new StreamReader("settings.txt");
		//scorro le prime linee che non mi servono
		nome = streamReader.ReadLine();
		cognome = streamReader.ReadLine();
		streamReader.Close();
	}
	
	// Update is called once per frame
	void Update () {

			//salvataggio dati
			if (Input.GetKey (KeyCode.S))
				OnApplicationSave ();
			

			//aggiornamento tempo
			timeLeft -= Time.deltaTime;
			
			//prendo lo script grabbable object per contare quando tempo è preso
			GrabbableObject grabbable = this.GetComponent<GrabbableObject> ();

		//se è preso aumento il contatore
		if (grabbable.grabbed_) {

			//start acquisizione punti cubi
			if(timeOld - timeLeft > 0.2f){
				timeOld = timeLeft;
				listaPuntiCuboX.Add(-((this.transform.position.x-1.48f)/2.5f));
				listaPuntiCuboY.Add((this.transform.position.y-0.935f)/2.5f);
				listaPuntiCuboZ.Add((this.transform.position.z-1.778f)/2.5f);
			}
			timeGrabbed += Time.deltaTime;
			soloUnPunto = true;
			}
		//quando rilascio l'oggetto salvo il tempo nella lista e controllo se ha avuto successo in caso positivo aumento lo score
		if (!grabbable.grabbed_ && soloUnPunto) {
			//stop acquisizione cubi
			listaPuntiCuboX.Add(0);
			listaPuntiCuboY.Add(0);
			listaPuntiCuboZ.Add(0);
			timeFromStart.Add ((60 - timeLeft));
				soloUnPunto = false;
				listaTempi.Add (timeGrabbed);
				success.Add (0);
			 	// se a posizione dell'oggetto è superiore alla metà della scena
				if (this.transform.position.x > 1.5) {
					score = score + 1;
				//riporto il successo nella lista
					success [success.Count - 1] = 1;	
				}
			
			
			}
		
		
		//se il tempo finisce...
			if (timeLeft < 0) {
				print ("fine");
			}
		

	}
	
	
	void OnCollisionEnter(Collision mano) {

		//controllo l'oggetto che ha avuto una collisione e successivamente lo nomino con il nome della mano toccata
		/*if (mano.collider.gameObject.name == "bone3")
			manoToccata = "0";
		
		if (mano.collider.gameObject.name == "destra")
			manoToccata = "1";	*/
		
	}

	
	
	void OnApplicationSave() {
		//salvo i dati e scrivo le liste
		System.IO.File.WriteAllText("save/BeB_"+nome +cognome +ora+".txt", "" );
		
		for (int i = 0; i < listaTempi.Count; i++) // Loop with for.
		{
			System.IO.File.AppendAllText("save/BeB_"+nome +cognome +ora+".txt", (i+1) + "\t"+ timeFromStart[i].ToString("F2") + "\t" + success[i] + "\t"+ listaTempi[i].ToString("F1")+ "\n" );
			media += listaTempi [i];	

		}
		System.IO.File.WriteAllText("save/BeBHand_"+nome +cognome +ora+".txt", "" );
		for (int p = 0; p < listaPuntiCuboX.Count; p++) // Loop with for.
		{
			System.IO.File.AppendAllText("save/BeBHand_"+nome +cognome +ora+".txt", 
			                             listaPuntiCuboX[p].ToString("F5") + "\t"+ 
			                             listaPuntiCuboY[p].ToString("F5") + "\t"+ 
			                             listaPuntiCuboZ[p].ToString("F5") +"\n") ;	
			
		}

		
	}
	
	
	
	
}