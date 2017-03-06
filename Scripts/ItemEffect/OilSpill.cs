using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilSpill : MonoBehaviour {

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

				Debug.Log (other.tag + " touched oil spill");

//				itemEffects ie = other.GetComponent<itemEffects> ();
//				if (!ie.IsShieldEquipped()) {
//					
					// TODO: implement Slip()
					// GameObject.Find (other.tag).SendMessage("Slip");
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
