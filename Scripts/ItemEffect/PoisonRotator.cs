﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonRotator : MonoBehaviour {

	public int spinSpeed = 3;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3(0,90,0) * Time.deltaTime * spinSpeed);
	}
}
