using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RiddleMain : MonoBehaviour 
{
	public float counter;
	public int index;
	public bool hasSolved;
	private Canvas paper;
	private bool riddleStart;
	private bool riddleEnd;
	private CameraShake cs;

	public List<GameObject> collected = new List<GameObject>();

	void Awake()
	{
		cs = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<CameraShake> ();
	}

	void Start()
	{
		index = 0;
		hasSolved = false;
		riddleStart = false;
	}

	void Update()
	{
		if (riddleStart) {
			if (collected.Count == 3) {
				riddleEnd = true;
			}
		}

		if (riddleEnd) {
			cs.DoShake();

			counter += 1.0f * Time.deltaTime;

			if (counter >= 4.0f) {
				cs.StopShake();
				counter = 0;
				riddleEnd = false;
				collected.Clear ();
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player") {
			riddleStart = true;
		}
	}
}