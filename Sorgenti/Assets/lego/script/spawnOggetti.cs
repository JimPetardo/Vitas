using UnityEngine;
using System.Collections;
using System.IO;

public class spawnOggetti : MonoBehaviour {

	public GameObject[] listaOggetti;
	private int diff;
	// Use this for initialization
	void Start () {
		//Apro il file di settings per leggere la difficolta
		StreamReader streamReader = new StreamReader("settings.txt");
		//scorro le prime linee che non mi servono
		for (int i = 0; i<5; i++) {
			streamReader.ReadLine();
		}
		//prendo la difficolta in char -48 per avere l intero corispondente
		diff = streamReader.Read() - 48;
		//chiudo il read
		streamReader.Close();
		//inizializzo l oggetto di difficolta diff 
		Instantiate (listaOggetti [diff-1]);
		
	}
}