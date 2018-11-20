using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHold : MonoBehaviour {
	public PlayerScriptable myPlayer;
	public bool selected = false;

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
