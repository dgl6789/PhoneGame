using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {
    public static GameManager instance = null;
    public Challenges challenges;
    [SerializeField]
    Text gameName;
    [SerializeField]
    Text instructions;

    void Start () {
        //Instance gamemanager on start
        if (instance == null)
            instance = this;

        challenges = new Challenges();
        ParseChallenges();

        foreach(string challenge in challenges.TwovTwo)
        {
            Debug.Log(challenge);
        }
	}
	

    public void SelectGame(string selection)
    {
        int game = Random.Range(1, 4);
        int range = 0;
        string[] data;
        switch (selection)
        {
            case "onevone":
                range = Random.Range(0, challenges.OnevOne.Count);
                data = challenges.OnevOne[range].Split('|');
                gameName.text = data[0];
                instructions.text = data[1];
                break;
            case "twovtwo":
                range = Random.Range(0, challenges.TwovTwo.Count);
                data = challenges.TwovTwo[range].Split('|');
                gameName.text = data[0];
                instructions.text = data[1];
                break;
            case "onevall":
                range = Random.Range(0, challenges.OnevAll.Count);
                data = challenges.OnevAll[range].Split('|');
                gameName.text = data[0];
                instructions.text = data[1];
                break;
            case "royale":
                range = Random.Range(0, challenges.Royale.Count);
                data = challenges.Royale[0].Split('|');
                gameName.text = data[0];
                instructions.text = data[1];
                break;
            default:
                RandomChallenge();
                break;
        }
    }

    public void RandomChallenge()
    {
        int range = Random.Range(0, 4);
        string[] data;
        switch (range)
        {
            case 0:
                range = Random.Range(0, challenges.OnevOne.Count);
                data = challenges.OnevOne[range].Split('|');
                gameName.text = data[0];
                instructions.text = data[1];
                break;
            case 1:
                range = Random.Range(0, challenges.TwovTwo.Count);
                data = challenges.TwovTwo[range].Split('|');
                gameName.text = data[0];
                instructions.text = data[1];
                break;
            case 2:
                range = Random.Range(0, challenges.OnevAll.Count);
                data = challenges.OnevAll[range].Split('|');
                gameName.text = data[0];
                instructions.text = data[1];
                break;
            case 3:
                range = Random.Range(0, challenges.Royale.Count);
                data = challenges.Royale[0].Split('|');
                gameName.text = data[0];
                instructions.text = data[1];
                break;
            default:
                Debug.Log("Error: Data isn't able to be parse and presented to the user");
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
            if (row[0] != "" || row[0] != " " || row[0] != "\r") challenges.OnevOne.Add(row[0]);
            if (row[1] != "" || row[1] != " " || row[1] != "\r") challenges.TwovTwo.Add(row[1]);
            if (row[2] != "" || row[2] != " " || row[2] != "\r") challenges.OnevAll.Add(row[2]);
            if (row[3] != "" || row[3] != " " || row[3] != "\r") challenges.Royale.Add(row[3]);
        }
    }
}

public class Challenges
{
    public List<string> OnevOne;
    public List<string> TwovTwo;
    public List<string> OnevAll;
    public List<string> Royale;

    public Challenges()
    {
        OnevOne = new List<string>();
        TwovTwo = new List<string>();
        OnevAll = new List<string>();
        Royale = new List<string>();
    }
}

