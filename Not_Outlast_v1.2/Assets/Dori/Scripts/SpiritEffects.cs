using UnityEngine;
using System.Collections;

public class SpiritEffects : MonoBehaviour 
{
	public Flashlight player;
	public ParticleSystem ps;

	void Start()
	{
		ps = GetComponent<ParticleSystem> ();
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			player.SendMessage("FlickerOn");
			ps.startSize = 3f;	
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Player") {
			player.SendMessage("FlickerOff");
			ps.startSize = 0.5f;
		}
	}
}