﻿using UnityEngine;
using System.Collections;

public class RiddleStart : MonoBehaviour 
{
	public bool riddleStart;

	void Start()
	{
		riddleStart = false;
	}

	void Update()
	{
		if (riddleStart) {

		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player") {
			riddleStart = true;
		}
	}
}