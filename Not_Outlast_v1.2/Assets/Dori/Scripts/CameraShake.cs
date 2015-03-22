using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour 
{
	private bool isShaking;
	private float shakeDecay;
	public float shakeIntensity;
	private Quaternion originalRotation;
	private MouseLook player;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<MouseLook> ();
	}
	
	void Start () 
	{
		isShaking = false;
	}

	void Update () 
	{
		if (isShaking) {
			transform.rotation = new Quaternion (originalRotation.x + Random.Range (-shakeIntensity, shakeIntensity),
			                                     originalRotation.y + Random.Range (-shakeIntensity, shakeIntensity),
			                                     originalRotation.z + Random.Range (-shakeIntensity, shakeIntensity),
			                                     originalRotation.w + Random.Range (-shakeIntensity, shakeIntensity));
			shakeIntensity -= shakeDecay;
		}	
	}

	public void DoShake()
	{
		player.enabled = false;
		originalRotation = transform.rotation;
		shakeIntensity = 0.1f * Time.deltaTime;
		shakeDecay = 0.03f * Time.deltaTime;
		isShaking = true;
	}

	public void StopShake()
	{
		player.enabled = true;
		transform.rotation = originalRotation;

		Debug.Log (transform.rotation);

		isShaking = false;
	}
}
