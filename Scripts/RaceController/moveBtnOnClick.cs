using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moveBtnOnClick : MonoBehaviour {

	public Button MoveBtn;
	public Text MoveBtnText;
	public int NumberOfChar; // passed from choice of character


	// Use this for initialization
	void Start () {
		if (MoveBtnText != null) {
			MoveBtnText.text = "";
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void moveButtonOnClick () {

		MoveBtn.interactable = false;
		MoveBtnText.text = "";
		GameObject.Find ("Player0").SendMessage("CDUsed");
		//		PlayerCoolDownValue cdv = GameObject.FindGameObjectWithTag ("MyCar").GetComponent<PlayerCoolDownValue> ();
		//		cdv.CDUsed ();


		switch (NumberOfChar) {
		case 1:
			GameObject.Find ("Player0").SendMessage("NitroStart");
			break;
//		case 2:
//			skill2 ();
//			break;
//		case 3:
//			skill3 ();
//			break;
//		case 4:
//			skill4 ();
//			break;
//		case 5:
//			skill5 ();
//			break;
//		case 6:
//			skill6 ();
//			break;
		}

	}
}
