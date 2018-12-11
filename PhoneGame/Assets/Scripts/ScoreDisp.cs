using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisp : MonoBehaviour {

	[SerializeField] GameObject playerHolder;
	List<PlayerScriptable>  playerList;
	[SerializeField] GameObject scoreHolder;
	List<Text>  scores;

	// Use this for initialization
	void Start () {
		playerList = playerHolder.GetComponent<LoadPlayers> ().players;
		Text[] temp  = scoreHolder.GetComponentsInChildren<Text> ();
		scores = new List<Text> (temp);
	}
	
	// Update is called once per frame
	/*void Update () {
		for(int i = 0; i<playerList.Count; i++){
			scores [i].text = playerList [i].name +":   " + playerList [i].Score;
		}
		
	}*/

	public void onClick () {
		for(int i = 0; i<playerList.Count; i++){
			//Debug.Log (i);
			if(playerList[i].activePlayer == true){
				scores [i].text = playerList [i].name +":   " + playerList [i].Score;
				
				if(i<(playerList.Count-1)){
					playerList [i].activePlayer = false;
					playerList [i + 1].activePlayer = true;
					break;
				}
				else if(i>=(playerList.Count-1)){
					playerList [i].activePlayer = false;
					playerList [0].activePlayer = true;
					break;
				}
			}

		}

	}


	public void updateAll () {
		for(int i = 0; i<playerList.Count; i++){
			//Debug.Log (i);
			scores [i].text = playerList [i].name +":   " + playerList [i].Score;

			}

	}

}