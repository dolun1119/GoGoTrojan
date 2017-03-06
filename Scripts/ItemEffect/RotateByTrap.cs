using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateByTrap : MonoBehaviour {

    public float rotateAngle = 720.0f;
    public float rotateTime = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    Transform topLevelParent(Transform childTransform)
    {
        if (childTransform.parent != null)
        {
            return topLevelParent(childTransform.parent);
        }
        else
        {
            return childTransform;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        Vector3 posBeforeSpin;
        //Quaternion rotationBeforeSpin;
        Transform topLevelTransform = topLevelParent(other.GetComponent<Transform>());
        Rigidbody rb = topLevelTransform.GetComponent<Rigidbody>();
        GameObject topLevelObject = topLevelTransform.gameObject;
        Debug.Log(other.name);

        if (rb != null && topLevelObject.layer == 9)
        { //Car layer
            Debug.Log(rb.name);
            //Debug.Log ("Hey!");	
            //StartCoroutine(spinForTime(rotateTime, topLevelTransform));

			StartCoroutine(rotateAngleInSecond(topLevelTransform, Vector3.up * rotateAngle, rotateTime));
			GetComponent<Renderer>().enabled = false;
        }

    }

    /*IEnumerator spinForTime(float time, Transform topLevelTransform)
    {
        Quaternion rotationBeforeSpinning = topLevelTransform.rotation;
        topLevelTransform.Rotate(Vector3.up, spinningSpeed * Time.deltaTime);
        yield return new WaitForSeconds(rotateTime);
        topLevelTransform.rotation = rotationBeforeSpinning;

        gameObject.SetActive(false);
        Destroy(this);
    }

	IEnumerator RotateMe(Transform topLevelTransform, Vector3 byAngles, float inTime)
	{
		Debug.Log("RotateMe called");
		Quaternion fromAngle = topLevelTransform.rotation ;
		Quaternion toAngle = Quaternion.Euler(topLevelTransform.eulerAngles + byAngles) ;
		for(float t = 0f ; t < 1f ; t += Time.deltaTime/inTime)
		{
			topLevelTransform.rotation = Quaternion.Lerp(fromAngle, toAngle, t) ;
			yield return null ;
		}
	}*/

	IEnumerator rotateAngleInSecond (Transform transform, Vector3 byAngles, float inTime) {
		//Quaternion fromAngle = transform.rotation ;
		//Debug.Log ("fromAngle: " + fromAngle);
		//Quaternion toAngle = Quaternion.Euler(transform.eulerAngles + byAngles) ;
		//Debug.Log ("toAngle: " + toAngle);
		float rotateFrames = inTime / Time.deltaTime;
		Debug.Log ("rotateFrames: " + rotateFrames);
		Vector3 step = byAngles / rotateFrames;
		Debug.Log ("step: " + step);
		for(int t = 0 ; t < rotateFrames ; t++)
		{
			transform.Rotate(step) ;
			yield return new WaitForEndOfFrame();
		}

		gameObject.SetActive(false);
		Destroy(this);
	}

}

