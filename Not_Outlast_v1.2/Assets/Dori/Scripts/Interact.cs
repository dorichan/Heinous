using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour 
{
	public bool isNearClue;
	public GameObject nearObj;
	private RiddleMain rm;

	void Awake()
	{
		rm = GameObject.FindGameObjectWithTag ("RiddleMain").GetComponent<RiddleMain> ();
	}

	void Start()
	{
		isNearClue = false;
		nearObj = null;
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.E) && isNearClue) {
			rm.collected.Add(nearObj);
			nearObj.SetActive (false);
			nearObj = null;
			isNearClue = false;
		}
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.tag == "Collect") {
			nearObj = other.gameObject;
		}
	}

	void OnTriggerExit(Collider other) 
	{
		if (other.gameObject.tag == "Collect") {
			nearObj = null;
		}
	}
}