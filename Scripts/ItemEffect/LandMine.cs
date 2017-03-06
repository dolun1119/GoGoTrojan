using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMine : MonoBehaviour {

	public GameObject explosion;

	public float damageValue; // default value = 30

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

				Instantiate (explosion, other.transform.position, other.transform.rotation);

			
//				itemEffects ie = other.GetComponent<itemEffects> ();
//
//				if (!ie.IsShieldEquipped()) {
					
					GameObject.Find (other.tag).SendMessage ("TakeDamage", damageValue);
					// TODO: implement Stop()
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
