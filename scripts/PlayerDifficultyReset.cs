using UnityEngine;
using System.Collections;

public class PlayerDifficultyReset : MonoBehaviour {

	// Use this for initialization
	void Start () {
		QuestTextManager.PlayerScore = 0;
		QuestTextManagerLevelTwo.PlayerScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
