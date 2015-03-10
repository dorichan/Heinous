/* This script is placed on a spot light that's parented to the player controller.
 * There is also a flicker that occurs when there is paranormal activity nearby. */

using UnityEngine;
using System.Collections;

public class Flashlight : MonoBehaviour 
{
	public int iter;
	public int randomInt;
	public float flickerTime;
	public float timer;
	public bool isFlicker;
	public bool isOn;
	private Light flashlight;

	void Awake()
	{
		flashlight = this.transform.GetComponent<Light>();
	}

	void Start()
	{
		// Set the iter to one at the start. This will ensure
		// that the flashlight if OFF at the start of the game.
		iter = 1;
		randomInt = 0;
		flickerTime = 8.0f;
		timer = 0.0f;
		isFlicker = false;
		isOn = false;
	}

	void Update()
	{
		// When 'F' is pressed, add one to iter. This will 
		// control whether the flashlight is enabled or disabled
		if (Input.GetKeyDown (KeyCode.F)) {
			iter++;
		}

		// Check to see if iter is divisible by two.
		if (iter%2 == 0) {
			// Enable the flashlight if iter is divisible by two.
			flashlight.enabled = true;
			isOn = true;

			if (isFlicker) {
				flashlight.enabled = false;
			}
		} else if (iter%2 != 0) {
			// Disable the flashlight if it is not divisible by two.
			flashlight.enabled = false;
			isOn = false;
		}

		// If iter is greater than or equal to two, then it is reset to zero.
		if (iter >= 2) {
			iter = 0;
		}

		if (isOn && isFlicker) {
			timer += Time.deltaTime + 1.0f;

			if (timer >= flickerTime) {
				randomInt = Random.Range (0, 10);
			}

			if (randomInt%1.5 == 0) {
				flashlight.enabled = true;
			} else if (randomInt%1.5 != 0) {
				flashlight.enabled = false;
			}
		} 
	}

	public void FlickerOn()
	{
		isFlicker = true;
	}

	public void FlickerOff()
	{
		isFlicker = false;
	}
}