using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour 
{
	public int clueCount;
	public bool isNearClue;

	void Start()
	{
		clueCount = 0;
		isNearClue = false;
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.E) && isNearClue) {
			RaycastHit hit;
			if(Physics.Raycast(transform.position, Vector3.forward, out hit)) {
				if(hit.transform.gameObject.tag == "Clue") {
					clueCount += 1;
				}
			}
		}
	}
}