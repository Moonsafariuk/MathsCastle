using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class DifficultyScript : MonoBehaviour {

public Slider DifficultyLevelSlider;
public static float DifficultyLevel;

public void CheckDifficultyLevel (float newValue)
	{
		DifficultyLevel = (int) newValue;
	}


	void Update () {
	Debug.Log("DifficultySliderValue = " + DifficultyLevelSlider.value);
	CheckDifficultyLevel(DifficultyLevelSlider.value);
	Debug.Log("DifficultyLevel = " + DifficultyLevel);
	}

}


public class DifficultyLevelStaticClass {


	public Slider DifficultyLevelSlider;
	public int DifficultyLevel;

	public void CheckDifficultyLevel ()
	{
	DifficultyLevel = (int) DifficultyLevelSlider.value;
	}



	public static int difficultyLevel; 


}
