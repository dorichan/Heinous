using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour 
{
	private bool isShaking;
	private float shakeDecay;
	public float shakeIntensity;
	private Quaternion originalRotation;
	private int index;
	
	void Start () 
	{
		isShaking = false;
		index = 0;
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
		if (index == 0) {
			SaveCurrentRotation ();
		}

		shakeIntensity = 1.5f * Time.deltaTime;
		shakeDecay = 0.3f * Time.deltaTime;
		isShaking = true;
	}

	void SaveCurrentRotation()
	{
		index += 1;
		Debug.Log (originalRotation);
		originalRotation = transform.rotation;
	}

	public void StopShake()
	{
		transform.rotation = originalRotation;

		Debug.Log (transform.rotation);

		isShaking = false;
	}
}
