using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {
    public static GameManager instance = null;
    public Challenges challenges;
    public GameObject RemovalScreen;
    public GameObject QRCodeScreen;
    [SerializeField]
    Text gameName;
    [SerializeField]
    Text instructions;
    [SerializeField]
    Text playerText;
    [SerializeField]
    Text removalText;

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
        int range = 0;
        string[] data;
        switch (selection)
        {
            case "http://onevsone":
                if(challenges.OnevOne.Count == 0)
                {
                    DisplayChallengeRemoval("Remove all One V One cards. \n DON'T PLACE THEM BACK IN PILE");
                    return;
                }
                range = Random.Range(0, challenges.OnevOne.Count);
                data = challenges.OnevOne[range].Split('|');
                gameName.text = data[0];
                instructions.text = data[1];
                ChoosePlayer(1);
                challenges.OnevOne.RemoveAt(range);
                break;
            case "http://twovstwo":
                if (challenges.TwovTwo.Count == 0)
                {
                    DisplayChallengeRemoval("Remove all Two V Two cards. \n DON'T PLACE THEM BACK IN PILE");
                    return;
                }
                range = Random.Range(0, challenges.TwovTwo.Count);
                data = challenges.TwovTwo[range].Split('|');
                gameName.text = data[0];
                instructions.text = data[1];
                ChoosePlayer(2);
                challenges.TwovTwo.RemoveAt(range);
                break;
            case "http://onevsall":
                if (challenges.OnevAll.Count == 0)
                {
                    DisplayChallengeRemoval("Remove all One V All cards. \n DON'T PLACE THEM BACK IN PILE");
                    return;
                }
                range = Random.Range(0, challenges.OnevAll.Count);
                data = challenges.OnevAll[range].Split('|');
                gameName.text = data[0];
                instructions.text = data[1];
                ChoosePlayer(0);
                challenges.OnevAll.RemoveAt(range);
                break;
            case "http://royale":
                if (challenges.Royale.Count == 0)
                {
                    DisplayChallengeRemoval("Remove all Royale cards. \n DON'T PLACE THEM BACK IN PILE");
                    return;
                }
                range = Random.Range(0, challenges.Royale.Count);
                data = challenges.Royale[range].Split('|');
                gameName.text = data[0];
                instructions.text = data[1];
                ChoosePlayer(0);
                challenges.Royale.RemoveAt(range);
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
                if (challenges.OnevOne.Count == 0)
                {
                    DisplayChallengeRemoval("Remove all One V One cards. \n DON'T PLACE THEM BACK IN PILE");
                    return;
                }
                range = Random.Range(0, challenges.OnevOne.Count);
                data = challenges.OnevOne[range].Split('|');
                gameName.text = data[0];
                instructions.text = data[1];
                ChoosePlayer(1);
                challenges.OnevOne.RemoveAt(range);
                break;
            case 1:
                if (challenges.TwovTwo.Count == 0)
                {
                    DisplayChallengeRemoval("Remove all Two V Two cards. \n DON'T PLACE THEM BACK IN PILE");
                    return;
                }
                range = Random.Range(0, challenges.TwovTwo.Count);
                data = challenges.TwovTwo[range].Split('|');
                gameName.text = data[0];
                instructions.text = data[1];
                ChoosePlayer(2);
                challenges.TwovTwo.RemoveAt(range);
                break;
            case 2:
                if (challenges.OnevAll.Count == 0)
                {
                    DisplayChallengeRemoval("Remove all One V All cards. \n DON'T PLACE THEM BACK IN PILE");
                    return;
                }
                range = Random.Range(0, challenges.OnevAll.Count);
                data = challenges.OnevAll[range].Split('|');
                gameName.text = data[0];
                instructions.text = data[1];
                ChoosePlayer(0);
                challenges.OnevAll.RemoveAt(range);
                break;
            case 3:
                if (challenges.Royale.Count == 0)
                {
                    DisplayChallengeRemoval("Remove all Royale cards. \n DON'T PLACE THEM BACK IN PILE");
                    return;
                }
                range = Random.Range(0, challenges.Royale.Count);
                data = challenges.Royale[range].Split('|');
                gameName.text = data[0];
                instructions.text = data[1];
                ChoosePlayer(0);
                challenges.Royale.RemoveAt(range);
                break;
            default:
                Debug.Log("Error: Data isn't able to be parse and presented to the user");
                break;
        }
    }

    /// <summary>
    /// Sets the text field of the Removal Screen so the player knows what cards to remove
    /// Enables and Disables correct screens
    /// </summary>
    /// <param name="text"></param>
    private void DisplayChallengeRemoval(string text)
    {
        removalText.text = text;
        QRCodeScreen.SetActive(false);
        RemovalScreen.SetActive(true);
    }

    private void ChoosePlayer(int selection)
    {
        if(selection == 1)
        {
            int player = Random.Range(1, 4);
            int random = Random.Range(0, 1);
            if(random == 0)
            {
                playerText.text = "You (Phone Holder) and the player " + player + " clockwise from you";
            }
            else
            {
                playerText.text = "You (Phone Holder) and the player " + player + " counter-clockwise from you";
            }
        }
        else if (selection == 2)
        {
            int player = Random.Range(1, 4);
            int random = Random.Range(0, 1);
            if (random == 0)
            {
                playerText.text = "You (Phone Holder) and the player " + player + " clockwise from you are a Team";
            }
            else
            {
                playerText.text = "You (Phone Holder) and the player " + player + " counter-clockwise from you are a Team";
            }
        }
        else
        {
            playerText.text = "";
        }
    }

    void ParseChallenges()
    {
        TextAsset challengeData = Resources.Load<TextAsset>("ChallengeData");

        string[] data = challengeData.text.Split('\n');

        for(int i = 1; i < data.Length; i++)
        {
            string[] row = data[i].Split(',');
            if (row.Length < 4) continue;
            if (row[0] != "" && row[0] != " " && row[0] != "\r") challenges.OnevOne.Add(row[0]);
            if (row[1] != "" && row[1] != " " && row[1] != "\r") challenges.TwovTwo.Add(row[1]);
            if (row[2] != "" && row[2] != " " && row[2] != "\r") challenges.OnevAll.Add(row[2]);
            if (row[3] != "" && row[3] != " " && row[3] != "\r") challenges.Royale.Add(row[3]);
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



