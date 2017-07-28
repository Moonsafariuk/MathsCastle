using UnityEngine;
using System.Collections;

public class SpookyWindScript : MonoBehaviour {

	static SpookyWindScript instance = null ; 

	// Use this for initialization

	void Awake ()
	{
		Debug.Log("Instance ID: " + GetInstanceID());

		if (instance != null) {
			Destroy (gameObject);
			Debug.Log("Destorying duplicate sound");

		} else {

			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
			Debug.Log("Instance ID: " + GetInstanceID());

		}

	}

	void Start ()
	{
	}

	

	
	// Update is called once per frame
	void Update () {
	
	}
}
