﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmName : MonoBehaviour {

	[SerializeField]GameObject GreetingText;

	[SerializeField]GameObject NextScene;

	[SerializeField]GameObject NamePromptScene;

	[SerializeField]GameObject InputFieldHolder;
	InputField input;


	[SerializeField] GameObject playerHolder;
	//LoadPlayers playerObjects;
	int curPlayer = 0;


	List<PlayerScriptable>  playerList;


	// Use this for initialization
	void Start () {
		playerList = playerHolder.GetComponent<LoadPlayers> ().players;
		//playerObjects = PlayerHolder.GetComponent<LoadPlayers> ();
		input = InputFieldHolder.GetComponent<InputField> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onClick(){
		if(curPlayer < playerList.Count){
			playerList[curPlayer].name = input.text;
			input.text = null;


			switch(curPlayer){
			case 0:
				GreetingText.GetComponent<Text> ().text = "Player Two,\n Enter your name";
				break;
			case 1:
				GreetingText.GetComponent<Text> ().text = "Player Three,\n Enter your name";
				break;
			case 2:
				GreetingText.GetComponent<Text> ().text = "Player Four,\n Enter your name";
				break;
			case 3:
				GreetingText.GetComponent<Text> ().text = "Player One,\n Enter your name";
				break;

			}
			curPlayer++;
			if(curPlayer >= 4){
				NextScene.SetActive (true);
				NamePromptScene.SetActive (false);
				curPlayer = 0;
			}

		}


	}
}
