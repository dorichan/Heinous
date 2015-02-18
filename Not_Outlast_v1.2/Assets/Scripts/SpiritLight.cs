using UnityEngine;
using System.Collections;

public class SpiritLight : MonoBehaviour 
{
	public Flashlight player;
	public Behaviour halo;
	public ParticleSystem ps;

	void Start()
	{
		halo = (Behaviour)GetComponent ("Halo");
		halo.enabled = false;
		ps = GetComponent<ParticleSystem> ();
	}

	void OnTriggerStay(Collider other) {
		if (other.gameObject.tag == "Player") {
			player.SendMessage("FlickerOn");
			halo.enabled = true;
			ps.startSize = 5;	
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Player") {
			player.SendMessage("FlickerOff");
			halo.enabled = false;
			ps.startSize = 1;
		}
	}
}