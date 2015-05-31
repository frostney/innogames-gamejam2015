using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour 
{
	private Transform characterTransform;

	void Start() 
	{
		characterTransform = GameObject.Find("Player").GetComponent<Transform>();
		transform.forward = new Vector3(0,0,1);
	}

	
	void Update() 
	{
		Vector3 vec = transform.rotation.eulerAngles;
		vec.z = characterTransform.rotation.eulerAngles.z;
		transform.eulerAngles = vec;

		Physics.gravity = -transform.up * 9.81f;

		vec = characterTransform.position;
		vec.z = transform.position.z;
		transform.position = vec;
	}
}
