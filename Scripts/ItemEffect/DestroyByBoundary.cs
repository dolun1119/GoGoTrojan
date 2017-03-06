using UnityEngine;
using System.Collections;
public class DestroyByBoundary : MonoBehaviour
{
	public GameObject explosion;
	void OnTriggerEnter(Collider other) 
	{
		
		if (other.tag == "Enemy" || other.tag == "Player")
		{
			Instantiate(explosion, other.transform.position, other.transform.rotation);

			//implement takeDamage();
			GameObject.Find ("RaceC").SendMessage("takeDamage", 50);

			//implement Stop()

			Destroy(gameObject);
		}

		if (other.tag == "Player")
		{
			Instantiate(explosion, other.transform.position, other.transform.rotation);

			//implement takeDamage();
			GameObject.Find ("RegularC").SendMessage("TakeDamage", 50);

			//implement Stop()

			Destroy(gameObject);
		}
	}
}