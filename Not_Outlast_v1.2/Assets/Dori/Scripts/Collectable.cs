using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour 
{
	private Interact interact;

	void Awake()
	{
		interact = GameObject.FindGameObjectWithTag ("Player").GetComponent<Interact> ();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			interact.isNearClue = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			interact.isNearClue = false;
		}
	}
}