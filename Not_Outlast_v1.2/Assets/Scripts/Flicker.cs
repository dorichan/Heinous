/* This script can be placed on any light. To control the speed of the flicker effect,
 * increase the value of flickerTime. */

using UnityEngine;
using System.Collections;

public class Flicker : MonoBehaviour 
{
	public float randomInt;
	public float timer;
	private float flickerTime;
	private Light light;

	void Awake()
	{
		light = this.transform.GetComponent<Light> ();
	}

	void Start()
	{
		randomInt = 0;
		flickerTime = 6.0f;
	}

	void Update()
	{
		timer += Time.deltaTime + 1.0f;

		// Timer to control the random integer.
		// This slows down the enabling and disabling of the light, 
		// creating a slower flicker effect
		if (timer >= flickerTime) {
			randomInt = Random.Range (0, 10);
			// Reset the timer once it has reached it's limit
			timer = 0.0f;
		}

		// Check if the random integer is divisible by 1.5
		if (randomInt%1.5 == 0) {
			// Enable the light if it is
			light.enabled = true;
		} else if (randomInt%1.5 != 0) {
			// Disable if it is not
			light.enabled = false;
		}
	}
}
