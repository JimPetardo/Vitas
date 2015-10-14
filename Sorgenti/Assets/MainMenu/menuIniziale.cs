using UnityEngine;
using System.Collections;
using System;

public class menuIniziale : MonoBehaviour {
	
	private string nomeGiocatore="";
	private string cognomeGiocatore="";
	private string ora;
	private string radiusBeB = "2.0";
	private string numeroBlocks = "10";

	private string tempoBart = "1.8";

	private string diffLego = "1";

	private string textFieldString= "";

	private bool startOK = false;

	void OnGUI () {

		DateTime now = DateTime.Now;
		//per evitare problemi di creazione del file cambio i caratteri non ammessi per directory
		ora = now.ToString ();
		ora = ora.Replace('/','-');
		ora = ora.Replace(' ','_');
		ora = ora.Replace(':','-');

		GUI.Box(new Rect(Screen.width/2 -200,Screen.height/2 -200,400,400), "MAIN MENU");

		//nome e cognome
		GUI.Label(new Rect(Screen.width/2 -40, Screen.height/2 - 170, 60, 100), "Name");
		nomeGiocatore = GUI.TextField(new Rect(Screen.width/2 -40, Screen.height/2 -150, 60, 20), nomeGiocatore, 25);
		GUI.Label(new Rect(Screen.width/2 +20, Screen.height/2 - 170, 60, 100), "Surname");
		cognomeGiocatore = GUI.TextField(new Rect(Screen.width/2 +20 , Screen.height/2 -150, 60, 20), cognomeGiocatore, 25);

		//Blocks&Box
		GUI.Label(new Rect(Screen.width/2 - 40, Screen.height/2 - 120, 80, 20), "Blocks&Box");

		GUI.Label(new Rect(Screen.width/2 + 10, Screen.height/2 - 100, 80, 20), "Radius");
		radiusBeB = GUI.TextField(new Rect(Screen.width/2 -40, Screen.height/2 -100, 40, 20), radiusBeB, 25);

		GUI.Label(new Rect(Screen.width/2 + 10, Screen.height/2 - 80, 80, 20), "Blocks");
		numeroBlocks = GUI.TextField(new Rect(Screen.width/2 -40, Screen.height/2 -80, 40, 20), numeroBlocks, 25);



		//Bart
		GUI.Label(new Rect(Screen.width/2 - 40, Screen.height/2 - 60, 80, 20), "Bart");

		GUI.Label(new Rect(Screen.width/2 + 10, Screen.height/2 - 40, 80, 20), "Time");
		tempoBart = GUI.TextField(new Rect(Screen.width/2 -40, Screen.height/2 -40, 40, 20), tempoBart, 25);

		//Lego
		GUI.Label(new Rect(Screen.width/2 - 40, Screen.height/2 - 20, 80, 20), "Lego");

		GUI.Label(new Rect(Screen.width/2 + 10, Screen.height/2 , 80, 20), "Difficulty(1-4)");
		diffLego = GUI.TextField(new Rect(Screen.width/2 -40, Screen.height/2 , 40, 20), diffLego, 25);


		if (GUI.Button (new Rect (Screen.width/2 -190, Screen.height/2 +170 , 50, 20), "Save")) {
			if(nomeGiocatore!="" && cognomeGiocatore!=""){
				System.IO.File.WriteAllText("settings.txt", nomeGiocatore + "\n");
				System.IO.File.AppendAllText ("settings.txt", cognomeGiocatore + "\n" );
				System.IO.File.AppendAllText ("settings.txt", radiusBeB + "\n" );
				System.IO.File.AppendAllText ("settings.txt", numeroBlocks + "\n" );
				System.IO.File.AppendAllText ("settings.txt", tempoBart + "\n" );
				System.IO.File.AppendAllText ("settings.txt", diffLego + "\n" );
				//backup
				System.IO.File.WriteAllText("backupDatiPazienti/settings_"+cognomeGiocatore+nomeGiocatore+ora+".txt", nomeGiocatore + "\n");
				System.IO.File.AppendAllText ("backupDatiPazienti/settings_"+cognomeGiocatore+nomeGiocatore+ora+".txt", cognomeGiocatore + "\n" );
				System.IO.File.AppendAllText ("backupDatiPazienti/settings_"+cognomeGiocatore+nomeGiocatore+ora+".txt", radiusBeB + "\n" );
				System.IO.File.AppendAllText ("backupDatiPazienti/settings_"+cognomeGiocatore+nomeGiocatore+ora+".txt", numeroBlocks + "\n" );
				System.IO.File.AppendAllText ("backupDatiPazienti/settings_"+cognomeGiocatore+nomeGiocatore+ora+".txt", tempoBart + "\n" );
				System.IO.File.AppendAllText ("backupDatiPazienti/settings_"+cognomeGiocatore+nomeGiocatore+ora+".txt", diffLego + "\n" );
				startOK = true;
			}

		}
		if (GUI.Button (new Rect (Screen.width / 2 + 140, Screen.height / 2 + 170, 50, 20), "Start")) {
			if(startOK)
				Application.LoadLevel ("Tuscany_Completo");
		}
		
	}
}
