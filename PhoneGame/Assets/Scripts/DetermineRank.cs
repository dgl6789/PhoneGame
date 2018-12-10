using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class DetermineRank : MonoBehaviour {
	[SerializeField] GameObject playerHolder;
	[SerializeField] GameObject RankTextHolder;
	List<PlayerScriptable>  playerList;
	List<PlayerScriptable>  playerListTEMP;
	List<Text> Ranks;
	List<string> intoRank;

	// Use this for initialization
	void Start () {
		intoRank = new List<string>();
		playerList = playerHolder.GetComponent<LoadPlayers> ().players;
		Ranks = RankTextHolder.GetComponentsInChildren<Text>().ToList();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DetermineRanks() {
		playerListTEMP = new List<PlayerScriptable> (playerList);
		//Debug.Log (playerList[1].name);
		int place = 1;
		while(playerListTEMP.Count>0){
			
			int highScore = 0;
			for (int i = 0; i < playerListTEMP.Count; i++) {
				if(playerListTEMP[i].Score > highScore){
					highScore = playerListTEMP [i].Score;

				}
			}
			for (int i = 0; i < playerListTEMP.Count; i++) {
				if(playerListTEMP[i].Score == highScore){
					intoRank.Add (place +".  "+ " " + playerListTEMP[i].name + ": " + playerListTEMP[i].Score);
					playerListTEMP.RemoveAt (i);
				}
			}
			place++;
			highScore = 0;

		}
		place = 1;
		for(int i =0; i< intoRank.Count; i++){
			Debug.Log (Ranks.Count);
			Debug.Log (intoRank[i] + "   " +i);
			Ranks [i].text = intoRank [i];
		}
		intoRank = new List<string>();

	}


}
