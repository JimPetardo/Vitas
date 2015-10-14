using UnityEngine;
using System.Collections;
using System.IO;

public class SpawnCubiRandom : MonoBehaviour {
	//creo i cubi
	public GameObject cubo;
	private int NumeroCubiDaSpawnare = 10;
	private string NumeroCubiDaSpawnarestr;
	public Color[] colors = {Color.red, Color.blue, Color.magenta, Color.green, Color.yellow};
	//creo/distruggo il pulsante start
	private bool hasBeenPressed = false;
	public bool Start_Scene = false;
	// Use this for initialization

	//se clicco su start allora chiama la funzione Start e disabilita il pulsante
	void OnGUI() {
		if (!hasBeenPressed) {
			if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "Start")) {
				
				Start_Scene = true;
				Start ();
				hasBeenPressed = true;
			}
		}
		
	}
	void Start () {
		Punteggio.score = 0;
		StreamReader streamReader = new StreamReader("settings.txt");
		//scorro le prime linee che non mi servono
		for (int i = 0; i<3; i++) {
			streamReader.ReadLine();
		}

		//prendo la difficolta in char -48 per avere l intero corispondente
		NumeroCubiDaSpawnarestr = streamReader.ReadLine();
		print (NumeroCubiDaSpawnarestr);
		NumeroCubiDaSpawnare = int.Parse(NumeroCubiDaSpawnarestr);

		streamReader.Close();


		if (Start_Scene) {
			Color[] Colori = {Color.red, Color.blue, Color.magenta, Color.green, Color.yellow};
			//creo i cubi in posizione random  e ne assegno un colore 
			for (int i = 0; i<NumeroCubiDaSpawnare; i++) {
				Vector3 RandomPos = new Vector3 (Random.Range (1.014049f, 1.43f), 1.112f, Random.Range (1.479741f, 2.097f));
				Color CubeColor = colors [Random.Range (0, colors.Length)];//colors[Random.Range (0, 5)]; 
				GameObject clone = Instantiate (cubo, RandomPos, Quaternion.identity) as GameObject;
				clone.renderer.material.color = CubeColor; 
			}
		}
	}
}