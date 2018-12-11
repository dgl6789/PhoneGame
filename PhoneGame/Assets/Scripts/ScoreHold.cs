using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHold : MonoBehaviour {
	//[SerializeField] GameObject playerHolder;
	//[SerializeField] int playernum;
	//List<PlayerScriptable> players;
	//public PlayerScriptable myPlayer;
	public bool selected = false;

	void Start () {
		//Debug.Log (playerHolder.GetComponent<LoadPlayers> ().players[playernum].name);
		//myPlayer = playerHolder.GetComponent<LoadPlayers> ().players[playernum];
	}

	public void onClick(){
		if (selected == false) {
			gameObject.GetComponent<Image> ().color = Color.red;
			selected = true;
		}
		else if (selected == true) {
			gameObject.GetComponent<Image> ().color = Color.white;
			selected = false;
		}


	}
}
