using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayer", menuName = "GameComponents/Player")]
public class PlayerScriptable : ScriptableObject {
	public string name = "Player";	//Player Name, get from fourm on the menu screen
	public int playerNum = 0; //this can be used to determine groups for games
	public bool activePlayer; //is it the player's turn
	public int Score = 0; //Add to this when challenges complee
}
