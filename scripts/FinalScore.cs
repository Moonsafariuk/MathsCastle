using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour {

	public Text FinalScoreText;

	// Use this for initialization
	void Start () {

	
        if (QuestTextManager.LevelTwoReached)
        {

            FinalScoreText.text = "Final Score: " + QuestTextManager.PlayerScore;
            Debug.Log("Final score: " + QuestTextManager.PlayerScore);

        } else if(QuestTextManagerLevelTwo.LevelTwoReached)
        {

            FinalScoreText.text = "Final Score: " + QuestTextManagerLevelTwo.PlayerScore;
            Debug.Log("Final score: " + QuestTextManagerLevelTwo.PlayerScore);

        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
