﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

public class trakingManoBartSinistra : MonoBehaviour {

	// Use this for initialization
	//tempo per traking
	private float timeOld = 0;
	private float time = 0;
	
	//liste per avere i punti della mano X Y
	public static List<float> listaPuntiX = new List<float>();
	public static List<float> listaPuntiY = new List<float>();
	
	//nome e cognome supporto file
	private string nome;
	private string cognome;
	
	private static DateTime now = DateTime.Now;
	private string ora;
	
	// Use this for initialization
	void Start () {
		//leggo il nome e il cognome del paziente
		StreamReader streamReader = new StreamReader("settings.txt");
		//scorro le prime linee che non mi servono
		nome = streamReader.ReadLine();
		cognome = streamReader.ReadLine();
		streamReader.Close();
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		//salvo i punti ogni 0.2 secondi
		if(time - timeOld > 0.2f){
			timeOld = time;
			listaPuntiX.Add(this.transform.position.x + 3.98f);
			listaPuntiY.Add(this.transform.position.z - 11.05f);
		}
		
		
		
	}
	//quando distruggo la mano salvo il traking dei punti
	void OnDestroy(){
		
		ora = now.ToString ();
		ora = ora.Replace('/','-');
		ora = ora.Replace(' ','_');
		ora = ora.Replace(':','-');
		
		//salvo i dati e scrivo le liste
		System.IO.File.WriteAllText("save/BartHandSinistra_"+nome +cognome +ora+".txt", "" );
		for (int p = 0; p < listaPuntiX.Count; p++) // Loop with for.
		{
			System.IO.File.AppendAllText("save/BartHandSinistra_"+nome +cognome +ora+".txt", 
			                             listaPuntiX[p].ToString("F5") + "\t"+ 
			                             listaPuntiY[p].ToString("F5") + "\n") ;	
			
		}
		
		
	}
}
