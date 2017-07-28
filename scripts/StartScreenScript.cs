using UnityEngine;
using System.Collections;

public class StartScreenScript : MonoBehaviour {

	public GameObject OptionsPanel;
	public GameObject MenuPanel;

	// Use this for initialization

	void Awake ()
	{

		if (OptionsPanel.activeInHierarchy) {
			OptionsPanel.SetActive(false);
			Debug.Log ("options panel is active");
		}

	}

	void Start () {




	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
