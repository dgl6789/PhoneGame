using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {
    public Challenges challenges;
    [SerializeField]
    Text gameName;
    [SerializeField]
    Text instructions;

    void Start () {
        challenges = new Challenges();
        ParseChallenges();

        foreach(string challenge in challenges.AllSolo)
        {
            Debug.Log(challenge);
        }
	}
	

    public void SelectGame()
    {
        int game = Random.Range(1, 4);
        int range = 0;
        string[] data;
        switch (game)
        {
            case 1:
                range = Random.Range(0, challenges.XvX.Count);
                data = challenges.XvX[range].Split('|');
                gameName.text = data[0];
                instructions.text = data[1];
                break;
            case 2:
                range = Random.Range(0, challenges.AllSolo.Count);
                data = challenges.AllSolo[range].Split('|');
                gameName.text = data[0];
                instructions.text = data[1];
                break;
            case 3:
                //range = Random.Range(0, challenges.Solo.Count);
                data = challenges.Solo[0].Split('|');
                gameName.text = data[0];
                instructions.text = data[1];
                break;
            default:
                gameName.text = "Resetting Data: Try Again";
                instructions.text = "Resetting";
                break;
        }
    }

    void ParseChallenges()
    {
        TextAsset challengeData = Resources.Load<TextAsset>("ChallengeData");

        string[] data = challengeData.text.Split('\n');

        for(int i = 1; i < data.Length; i++)
        {
            string[] row = data[i].Split(',');
            if (row[0] != "" || row[0] != "\r") challenges.XvX.Add(row[0]);
            if (row[1] != "" || row[1] != "\r") challenges.AllSolo.Add(row[1]);
            if (row[2] != "" || row[2] != "\r") challenges.Solo.Add(row[2]);
        }
    }
}

public class Challenges
{
    public List<string> XvX;
    public List<string> AllSolo;
    public List<string> Solo;

    public Challenges()
    {
        XvX = new List<string>();
        AllSolo = new List<string>();
        Solo = new List<string>();
    }
}

