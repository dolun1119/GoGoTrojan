using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyItemCollector : MonoBehaviour {

//	bool ItemCollected = false;

	// we have total 6 kinds of items and effects
	//	1, missle		-> 射出擊中敵人扣血
	//	2, land mine	-> 敵人碰到扣血
	//	3, oil spill	-> 打滑
	//	4, glue			-> 速度變慢一段時間
	//	5, shield		-> 不受技能道具影響
	//	6, lightning	-> 閃電劈所有敵人
	private int numOfItems = 6;

	// if player doesn't collect an item, the default itemValue = 0;
	// when player get a item, the item value will be 1 ~ 6;
	private int itemValue = 0;

	// number of coins
	private int coinCount = 0;


	public GameObject missile;
	public GameObject landMine;
	public GameObject oilSpill;
	public GameObject glue;
	//	public GameObject shield;
	public GameObject lightning;

	public ParticleSystem shieldPS;

	private bool ShieldEquipped;

	public GameObject[] Players;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (itemValue != 0) {
			Debug.Log ("enemy get item no." + itemValue);

			UseItem (itemValue);

			itemValue = 0;
		}
	}

	// we have 4 kinds of collectable pickups
	// 1. coin  								// But enemy doesn't eat coins
	// 2. heart
	// 3. poison
	// 4. box (randomly generate items)

	void OnTriggerEnter(Collider other)
	{

		if (other.gameObject.CompareTag ("Coin")) {
			other.gameObject.SetActive (false);

			coinCount++;
		}


		if (other.gameObject.CompareTag ("Heart")) {
			other.gameObject.SetActive (false);

			gameObject.SendMessage("HealDamage", 20);
		}

		if (other.gameObject.CompareTag ("Poison")) {
			other.gameObject.SetActive (false);

			gameObject.SendMessage("TakeDamage", 50);
		}

		if (other.gameObject.CompareTag ("Arrow")) {
			other.gameObject.SetActive (false);

			int randomValue = Random.Range (1, numOfItems + 1);
//			int randomValue = 6;

			SetItemValue (randomValue);


		}
	}


	public void SetItemValue(int value) {

		itemValue = value;
	}


	public void UseItem (int itemValue) {
		
		switch (itemValue) {
		case 1:
			Missle ();
			break;
		case 2:
			LandMine ();
			break;
		case 3:
			OilSpill ();
			break;
		case 4:
			Glue ();
			break;
		case 5:
			Shield ();
			break;
		case 6:
			Lightning ();
			break;
		}
					
	}


	public void Missle() {

		// generate a missile
		Instantiate(missile,transform.position,transform.rotation);

	}

	public void LandMine() {

		Instantiate(landMine,transform.position,transform.rotation);
	}

	public void OilSpill() {

		Instantiate(oilSpill,transform.position,transform.rotation);
	}

	public void Glue() {

		Instantiate(glue,transform.position,transform.rotation);
	}

	public void Shield() {

		shieldPS.Play ();
		ShieldEquipped = true;
		Debug.Log ("USE SHIELD");
		Invoke ("UnequipShield", 3);
	}


	void UnequipShield() {
		Debug.Log ("NO SHIELD NOW");
		ShieldEquipped = false;
	}

	public bool IsShieldEquipped() {

		return ShieldEquipped;
	}


	public void Lightning() {

		//		GameObject enemy = GameObject.Find ("RaceC");
		//		Instantiate(lightning, enemy.transform.position, enemy.transform.rotation);
		//		enemy.SendMessage("TakeDamage", 20);


		// attack all players!
		foreach (GameObject go in Players) {

			if (!go.tag.Equals(gameObject.tag)) {

				Instantiate(lightning, go.transform.position, go.transform.rotation);

				//				itemEffects ie = go.GetComponent<itemEffects> ();
				//				if (!ie.IsShieldEquipped ()) {
				go.SendMessage ("TakeDamage", 20);
				//				}

			}
		}


	}
}
