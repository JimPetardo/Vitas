using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class Bart : MonoBehaviour {
	//variabili

	//semaforo per iniziare la scena con start
	public bool Start_Scene = false;
	//bottone verde originale
	public GameObject botton;
	//clone per istanziare bottone 
  	private GameObject Clone;
	//array di posizioni lungo y
	public  Vector3[] array1;
	//numero di prove (ossia di bottoni) eseguiti dallo start
	public int prove;
	//lista di posizioni lungo y
	public  List<Vector3> listaVettori= new List<Vector3> (6);
	//lista di posizioni lungo x
	public  List<Vector3> listaVettoriRot= new List<Vector3> (15);
	//array memorizza le posizioni per evitare la duplicazione dello stesso bottone
	public int[,] array4 = new int[6, 15];
	// tempo iniziale
	public float timeLeft = 181;
	// semafoto pulsante di start
	private bool hasBeenPressed = false;
	//tempo per ogni spawn punto
	private float tempo;
	private string tempostr;



	//stampato su schermo on gui
	void OnGUI () {
		//creazione e distruzione dello start 
		if (!hasBeenPressed) {
			if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "Start")) {
				
				Start_Scene = true;
				//chiama l'inizializzazione dello scrit
				Start ();
				hasBeenPressed = true;

			}
		}
	}
  

	//funzione di start
    void Start() {
		timeLeft = 181;
		provaCollaiderBart.punti = 0;

		StreamReader streamReader = new StreamReader("settings.txt");
		//scorro le prime linee che non mi servono
		for (int i = 0; i<4; i++) {
			streamReader.ReadLine();
		}
		//converto da string a float

		tempostr = streamReader.ReadLine();
		tempo = float.Parse(tempostr);
		//chiudo il read
		streamReader.Close();
		print (tempo);


		//semaforo di inizio scena (controllato dal pulsante start)
		if (Start_Scene) {
			//array di vettori di somma per determinare il modulo del vettore
			Vector3[] array1 = new Vector3[6]{
			new Vector3 (0.1f, -90f, 0f),
			new Vector3 (0.14f, -90f, 0f),
			new Vector3 (0.18f, -90f, 0f),
			new Vector3 (0.22f, -90f, 0f),
			new Vector3 (0.26f, -90f, 0f),
			new Vector3 (0.30f, -90f, 0f),
		};

			Vector3[] array2 = new Vector3[15]{
			//array di vettori per determinarne la rotazione  

			new Vector3 (0.0f, 20f, 0f),
			new Vector3 (0.0f, 30f, 0f),
			new Vector3 (0.0f, 40f, 0f),
			new Vector3 (0.0f, 50f, 0f),
			new Vector3 (0.0f, 60f, 0f),
			new Vector3 (0.0f, 70f, 0f),
			new Vector3 (0.0f, 80f, 0f),
			new Vector3 (0.0f, 90f, 0f),
			new Vector3 (0.0f, 100f, 0f),
			new Vector3 (0.0f, 110f, 0f),
			new Vector3 (0.0f, 120f, 0f),
			new Vector3 (0f, 130f, 0f),
			new Vector3 (0.0f, 140f, 0f),
			new Vector3 (0.0f, 150f, 0f),
			new Vector3 (0.0f, 160f, 0f),
			
		};
			//creazione di due liste contenenti i valori dell'array1 (vettore lunghezza) e l'array2 (rotazione)

			listaVettori.Add (array1 [0]);
			listaVettori.Add (array1 [1]);
			listaVettori.Add (array1 [2]);
			listaVettori.Add (array1 [3]);
			listaVettori.Add (array1 [4]);
			listaVettori.Add (array1 [5]);

			listaVettoriRot.Add (array2 [0]);
			listaVettoriRot.Add (array2 [1]);
			listaVettoriRot.Add (array2 [2]);
			listaVettoriRot.Add (array2 [3]);
			listaVettoriRot.Add (array2 [4]);
			listaVettoriRot.Add (array2 [5]);
			listaVettoriRot.Add (array2 [6]);
			listaVettoriRot.Add (array2 [7]);
			listaVettoriRot.Add (array2 [8]);
			listaVettoriRot.Add (array2 [9]);
			listaVettoriRot.Add (array2 [10]);
			listaVettoriRot.Add (array2 [11]);
			listaVettoriRot.Add (array2 [12]);
			listaVettoriRot.Add (array2 [13]);
			listaVettoriRot.Add (array2 [14]);
		

			// chiamata della funzione Create and Destroy rispettivamente ogni 1.8 sec dopo 1 secondo dallo start
			// per Create e 2.8 sec per Destroy

			InvokeRepeating ("Create", 1, tempo);
			InvokeRepeating ("Destroy", tempo+1, tempo);
		}
    }

	void Create() {
			//incrementa il numero di prove
			prove++;
	

			int rotazione = Random.Range (0, listaVettoriRot.Count);
			int traslazione = Random.Range (0, listaVettori.Count);
			//controlla se esiste già la stella in posizione [i,p]
		while (array4 [traslazione, rotazione] == 1) {
				//ricerca il un'altro valora scegliendolo random
				rotazione = Random.Range (0, listaVettoriRot.Count);
				traslazione = Random.Range (0, listaVettori.Count);
			}
			;
			//crea un clone lo ruota e lo trasla applicandoli i vettori scelti
			Clone = (GameObject)Instantiate (botton);
			Clone.transform.Rotate (listaVettoriRot [rotazione]);
			Clone.transform.Translate (listaVettori [traslazione]);	
			//memorizza che il bottone  è stato traslato e ruotato
			array4 [traslazione, rotazione] = 1;
	
	}

	//distrugge clone
	void Destroy() {
		Destroy(Clone);

	}	
	//ritorna il numero di prove
	public int GetProve() {
		return prove;

	}	
		
	void Update () {
		if (Start_Scene) {
			//aggiorna tempo
			timeLeft -= Time.deltaTime;
		}

	}


}