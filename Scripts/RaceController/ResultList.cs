using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
	this script should be dragged on canvas for OnClick functions.
*/

public class ResultList : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public void LeaveButtonOnClick() {
		SceneManager.LoadScene("MainMenu");
	}

	public void PlayAgainOnClick() {
		SceneManager.LoadScene("Race");
	}
}
