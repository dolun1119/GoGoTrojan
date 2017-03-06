using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glue : MonoBehaviour {

	private bool alreadyPut;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) 
	{
		if (alreadyPut) {
			
			if (other.tag.Contains("Player"))  // if missile collides with player or enemy
			{

				Debug.Log (other.tag + " touched glue");

//				itemEffects ie = other.GetComponent<itemEffects> ();
//				if (!ie.IsShieldEquipped()) {
					// TODO: implement SlowDown()
					// GameObject.Find (other.tag).SendMessage("SlowDown");
//				}

				Destroy(gameObject);
			}
		}

	}

	void OnTriggerExit(Collider other) {

		// this item works only after player put this item
		alreadyPut = true;
	}
}
