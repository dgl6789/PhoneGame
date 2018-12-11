using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LoadPlayers : MonoBehaviour {

	public List<PlayerScriptable> players;

	// Use this for initialization
	void Start () {
		//players = Resources.LoadAll<PlayerScriptable>("ScriptableObjects").ToList();


		//this code would be better, I think. but it conflicts with game manager somehow

		for(int i = 0; i<4; i++){
			players.Add( ScriptableObject.CreateInstance ("PlayerScriptable") as PlayerScriptable);
			players [i].name = "Player " + i;
			players [i].Score = 0;
			players [i].activePlayer = false;
		}
		players [0].activePlayer = true;
	}

}
