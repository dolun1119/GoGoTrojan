using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class itemBtnOnClick : MonoBehaviour {

	public Button ItemBtn;
	public Text ItemBtnText;
	public PlayerItemCollector playerItemCollector;
	public Text test;


	// Use this for initialization
	void Start () {
		if (ItemBtnText != null) {
			ItemBtnText.text = "";
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void itemButtonOnClick () {

		ItemBtn.interactable = false;
		ItemBtnText.text = "";

		int itemValue = playerItemCollector.GetItemValue ();
		Debug.Log("itemValue = " + itemValue.ToString ());

		GameObject.Find ("Player0").SendMessage("UseItem" , itemValue);


	}


}
