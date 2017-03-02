﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTimer : MonoBehaviour {

	public Text timerText;
	public Text preTimerText;
	private float startTime;
	private float departTime;

	public string totalMinute;
	public string totalSecond;
	public string totalMiliSecond;

	int testTime;
	bool finished;
	bool canStartRacing;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		preTimerText.text = "";
//		testTime = 1;
		
	}
	
	// Update is called once per frame
	void Update () {

		if (finished) {
			return;
		}

		testTime = (int)(startTime - Time.time + 4);

		// when test time = 3, 2, 1
		if (testTime < 5 && testTime >= 1) {
			
			preTimerText.text = testTime.ToString ();

		} 
		else if (testTime == 0) {
			
			preTimerText.text = "GO!";
			departTime = Time.time;
		} 

		else {

			if (!canStartRacing) {

//				GameObject.Find ("RegularC").SendMessage("setStartRacing");
//				GameObject.Find ("RaceC").SendMessage("setStartRacing");
				GameObject.Find ("RegularC").SendMessage("SetCDstarts");
				GameObject.Find ("RaceC").SendMessage("SetCDstarts");
				canStartRacing = true;
			}

			preTimerText.text = "";

			float timer = Time.time - departTime;
			totalMinute = ((int)timer / 60).ToString ("D2");
			totalSecond = ((int)timer % 60).ToString ("D2");
			totalMiliSecond = ((int)(timer * 100) % 100).ToString ("D2");
			timerText.text = "TIME\n" + totalMinute + ":" + totalSecond + ":" + totalMiliSecond;


		}
	}

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.CompareTag ("FinishLine"))
		{
			Finnish ();
		}
	
	}

	void Finnish() {
		timerText.color = Color.yellow;
		finished = true;
//		GameObject.Find ("RegularC").SendMessage("setGameOver");
//		GameObject.Find ("RaceC").SendMessage("setStopRacing");
//		GameObject.Find ("RegularC").SendMessage("SetCDstops");
		GameObject.Find ("RegularC").SendMessage("StopComputeRanking");
		GameObject.Find ("RegularC").SendMessage("GameOver");

	}

	public void DeathFinnish() {
		timerText.color = Color.red;
		finished = true;
//		GameObject.Find ("RegularC").SendMessage("setGameOver");
//		GameObject.Find ("RaceC").SendMessage("setStopRacing");
//		GameObject.Find ("RegularC").SendMessage("SetCDstops");
		GameObject.Find ("RegularC").SendMessage("StopComputeRanking");
		GameObject.Find ("RegularC").SendMessage("GameOver");

	}

	public string GetTotalTime() {
		string result = totalMinute + ":" + totalSecond + ":" + totalMiliSecond;
		return result;
	}
}
