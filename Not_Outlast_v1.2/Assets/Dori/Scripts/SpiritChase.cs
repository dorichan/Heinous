using UnityEngine;
using System.Collections;

public class SpiritChase : MonoBehaviour 
{
	public float speed;
	public float chaseDistance;
	private GameObject target;

	void Awake()
	{
		target = GameObject.FindGameObjectWithTag ("Player");
	}

	void Start()
	{
		speed = 0.03f;
		chaseDistance = 5.0f;
	}

	void FixedUpdate()
	{
		Vector3 direction = target.transform.position - gameObject.transform.position;

		if (direction.magnitude > chaseDistance) {
			Vector3 moveVector = direction.normalized * speed;
			gameObject.transform.position += moveVector;
			//gameObject.transform.rotation = Quaternion.LookRotation(moveVector);

		}
	}
}