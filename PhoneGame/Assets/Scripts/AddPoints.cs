using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddPoints : MonoBehaviour {

	[SerializeField] List<GameObject> playersButton;

	// Use this for initialization
	void Start () {
		for(int i = 0; i< playersButton.Count; i++){
			playersButton [i].GetComponentInChildren<Text> ().text = playersButton [i].GetComponent<ScoreHold> ().myPlayer.name;

		}
	}

	public void onClick(){
		for(int i = 0; i< playersButton.Count; i++){
			if( playersButton [i].GetComponent<ScoreHold> ().selected == true){

				playersButton [i].GetComponent<ScoreHold> ().myPlayer.addScore ();
				playersButton [i].GetComponent<ScoreHold> ().selected = false;
				playersButton [i].GetComponent<Image> ().color = Color.white;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
