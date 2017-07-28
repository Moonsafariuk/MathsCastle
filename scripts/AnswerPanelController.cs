using UnityEngine;
using System.Collections;

public class AnswerPanelController : MonoBehaviour {


	public GameObject AnswerButtonPanel;

	void Awake ()
	{

		if (AnswerButtonPanel.activeInHierarchy) {
			AnswerButtonPanel.SetActive(false);
			Debug.Log ("AnswerButtonPanel is active");
		}

	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
