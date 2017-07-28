using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	// Use this for initialization


	public void LoadLevel (string name)
	{
		Debug.Log("Request to load level " + name);
		Application.LoadLevel(name);

	}


	// application.quit() only for desktop games.. 
	//does not work for web and should not be used for mobile apps
	public void QuitRequest()
	{

		Debug.Log("Request to quit application made");
		Application.Quit();

	}


}