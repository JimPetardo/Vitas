using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class generatoreFig : MonoBehaviour {
	//Qui attacco attraverso unity la stella 
	public GameObject Stella;

	private GameObject StellaGrande;
	private GameObject StellaPiccola;

	//Aiuti per cicli
	private float count=0;
	private float prova=0;

	//Salvataggio delle posizione gia utilizzate
	public float[,] array4 = new float[5000, 5000];

	//Rendere piu affidabile il random
	private float[] noiseValues;

	void Start() {
		//Rendere piu affidabile il random
		colliderS.punteggio = 0;
		Random.seed = 42;
		noiseValues = new float[10];
		int d = 0;
		while (d < noiseValues.Length) {
			noiseValues[d] = Random.value;
			d++;
		}
	//Ciclo per creare le stelle da mettere in scena
	for(count=0; count<108;count++){
	
		//Serviranno per spostare 
		float p =  Random.Range (0f, 11f);
		float i = Random.Range (0f,19f);
		//Salvo le posizioni all interno di un array
		while (array4 [(int)i,(int)p] == 1) {
			 p = Random.Range (0, 11f);
			 i = Random.Range (0,19f);
		}
		//Divido per ottenere un numero compatibile con la grandella della scena
		float g = i / 30;
		float m = p / 34;
		//creo 52 stelle Grandi
		if(count<52){
			//Istanzio la stella e la scalo a grandella giusta
			StellaGrande = Instantiate (Stella) as GameObject;
			StellaGrande.transform.localScale -= new Vector3(0.007F, 0.007F, 0.007F);
			
			//Cambio il versore con cui far posizionare le stelle
			if(count%4==0)
				StellaGrande.transform.position = new Vector3(transform.position.x-0.5f,transform.position.y+m,transform.position.z-g);
			if(count%4==1)
				StellaGrande.transform.position = new Vector3(transform.position.x-0.5f,transform.position.y+m,transform.position.z+g);
			if(count%4==2)
				StellaGrande.transform.position = new Vector3(transform.position.x-0.5f,transform.position.y-m,transform.position.z+g);
			if(count%4==3)
				StellaGrande.transform.position = new Vector3(transform.position.x-0.5f,transform.position.y-m,transform.position.z-g);
			//Salvo come utilizzata la posizione p,i
			array4[(int)i,(int)p] = 1;
			prova++;
		}
		//Creo le stelle piccole
		else if(count>52){
			//Istanzio la stella Piccola
			StellaPiccola = (GameObject)Instantiate (Stella);
			
			//Assegno collider alla stella a forma di sfera di raggio 7
			StellaPiccola.AddComponent ("SphereCollider");
			SphereCollider sphereCollider = StellaPiccola.GetComponent<SphereCollider>();
			sphereCollider.radius = 7.0F;
			//Scalo a grandezza giusta
			StellaPiccola.transform.localScale -= new Vector3(0.005F, 0.005F, 0.005F);
			//Rinomino la stella creata
			StellaPiccola.name = "Stellina";

			//Cambio il versore con cui far posizionare le stelle
			if(count%4==0)
				StellaPiccola.transform.position = new Vector3(transform.position.x-0.5f,transform.position.y+m,transform.position.z-g);
			if(count%4==1)
				StellaPiccola.transform.position = new Vector3(transform.position.x-0.5f,transform.position.y+m,transform.position.z+g);
			if(count%4==2)
				StellaPiccola.transform.position = new Vector3(transform.position.x-0.5f,transform.position.y-m,transform.position.z+g);
			if(count%4==3)
				StellaPiccola.transform.position = new Vector3(transform.position.x-0.5f,transform.position.y-m,transform.position.z-g);
			//Salvo come utilizzata la posizione p,i
			array4 [(int)i,(int) p] = 1;
			prova++;					
			}
		}
	}




}