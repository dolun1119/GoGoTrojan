using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

	public float speed;  // default value = 70

	public float damageValue; // default value = 50

	public GameObject explosion;
	private bool alreadyPut;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		transform.Translate (0, 0, speed * Time.deltaTime);
		Destroy (gameObject, 3);
	}


	void OnTriggerEnter(Collider other) 
	{
		if (alreadyPut) {
			if (other.tag.Contains ("Player")) {  // if missile collides with player or enemy
				Instantiate (explosion, other.transform.position, other.transform.rotation);

//				itemEffects ie = other.GetComponent<itemEffects> ();

//				if (!ie.IsShieldEquipped ()) {
					
					GameObject.Find (other.tag).SendMessage ("TakeDamage", damageValue);
					// TODO: implement Stop()

//				}
				gameObject.SetActive (false);
				Destroy (gameObject);
			}
		}

	}

	void OnTriggerExit(Collider other) {

		// this item works only after player put this item
		alreadyPut = true;
	}
}
