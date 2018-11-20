using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LoadPlayers : MonoBehaviour {

	public List<PlayerScriptable> players;

	// Use this for initialization
	void Start () {
		players = Resources.LoadAll<PlayerScriptable>("ScriptableObjects").ToList();
		players [0].activePlayer = true;
	}

}
