using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {

	public Image HealthBar;
	public Image CDBar;

	public int NumberOfChar;
	// 	different skills for characters:
	//	Number		Character				Passive	Skill			Active Skill	
	//	1.			Marshall				Coin x2					Coins attack		
	//	2.			Viterbi					item效果增強				防護罩
	//	3.			Football Player			血多						衝撞		
	//	4.			Med Student				補血 x2					回血		
	//	5.			Cinema					集氣快					freeze others
	//  6.			...						...						...



	//  Now we have Nitro & Freeze

	private bool isDead = false;

	public float maxHealthPoint = 100;
	public float maxCDPoint = 100;

	public float currentHealthPoint = 100;
	public float currentCDPoint = 0;

	public int CDspeed = 10;

	private bool CDstarts = false;


	// Use this for initialization
	void Start () {
		UpdateHealthBar ();
		UpdateCDBar ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!isDead && CDstarts) {
			
			if (currentCDPoint >= maxCDPoint) {
				currentCDPoint = maxCDPoint;

				// implement USEMOVE();
				LaunchActiveSkill(NumberOfChar);

				currentCDPoint = 0;
			} else {
				currentCDPoint += Time.deltaTime * CDspeed;
			}

			UpdateCDBar ();
		}

	}

	private void UpdateHealthBar() {

		float ratio = currentHealthPoint / maxHealthPoint;
		HealthBar.rectTransform.localScale = new Vector3 (ratio, 1, 1);
	
	}

	private void UpdateCDBar() {

		float ratio = currentCDPoint / maxCDPoint;
		CDBar.rectTransform.localScale = new Vector3 (ratio, 1, 1);

	}

	void reduceCDtoZero() {
		currentCDPoint = 0;
		UpdateCDBar ();
	}

	public void TakeDamage (float damage) {

		currentHealthPoint -= damage;

		if (currentHealthPoint <= 0) {
			currentHealthPoint = 0;

			Death();
		}

		UpdateHealthBar ();
	}

	public void HealDamage(float heal) {

		if (!isDead) {
			
			currentHealthPoint += heal;

			if (currentHealthPoint > maxHealthPoint) {
				currentHealthPoint = maxHealthPoint;
			}

			UpdateHealthBar ();
		}
	}

	private void Death() {
		isDead = true;
		reduceCDtoZero ();
		GameObject.Find (gameObject.tag).SendMessage("setStopRacing");
		GameObject.Find (gameObject.tag).SendMessage("setDead");
	}


	public void SetCDstarts() {
		CDstarts = true;
	}

	public void SetCDstops() {
		CDstarts = false;
	}

	public void LaunchActiveSkill(int NumberOfChar) {

		switch (NumberOfChar) {
		case 1:
			gameObject.SendMessage("NitroStart");
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
