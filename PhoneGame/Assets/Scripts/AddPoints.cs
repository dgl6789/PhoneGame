using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddPoints : MonoBehaviour {

	int gamesPlayed = 1;
	[SerializeField] List<GameObject> playersButton;
	[SerializeField] GameObject playerholder;


	[SerializeField] GameObject addPointsScreen;
	[SerializeField] GameObject QrScreen;
	[SerializeField] GameObject WinScreen;


	//[SerializeField] List<PlayerScriptable> players;

	// Use this for initialization
	void Start () {
		
	}

	public void ButtonNames () {
		//players = playerholder.GetComponent<LoadPlayers> ().players;
		for(int i = 0; i< playersButton.Count; i++){
			playersButton [i].GetComponentInChildren<Text> ().text = playerholder.GetComponent<LoadPlayers> ().players[i].name;

		}
	}

	public void onClick(){
		for(int i = 0; i< playersButton.Count; i++){
			if( playersButton [i].GetComponent<ScoreHold> ().selected == true){
				//Debug.Log (playerholder.GetComponent<LoadPlayers> ().players[i].name);
				playerholder.GetComponent<LoadPlayers> ().players[i].addScore();
				playersButton [i].GetComponent<ScoreHold> ().selected = false;
				playersButton [i].GetComponent<Image> ().color = Color.white;
			}
		}
		if (gamesPlayed >= 4) {
			WinScreen.SetActive(true);
			addPointsScreen.SetActive (false);
			//ResetGame ();
		} else {
			QrScreen.SetActive(true);
			addPointsScreen.SetActive(false);
		}
		gamesPlayed++;
	}
	
	// Update is called once per frame
	public void ResetGame () {
		gamesPlayed = 0;
		for (int i = 0; i < playersButton.Count; i++) {
			playerholder.GetComponent<LoadPlayers> ().players [i].Score = 0;

		}
	}
}
