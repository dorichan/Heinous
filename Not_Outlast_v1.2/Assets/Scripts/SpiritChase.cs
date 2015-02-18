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
		speed = 2.0f;
		chaseDistance = 5.0f;
	}

	void Update()
	{
		Vector3 direction = target.transform.position - gameObject.transform.position;

		if (direction.magnitude > chaseDistance) {
			Vector3 moveVector = direction.normalized * speed * Time.deltaTime;
			gameObject.transform.position += moveVector;
		}
	}
}