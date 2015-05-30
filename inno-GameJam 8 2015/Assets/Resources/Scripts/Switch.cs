using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour 
{
	private bool rotating = false;
	public float speed = 10;

	void Start() 
	{
	
	}

	void Update() 
	{
		if(rotating)
			rotating = rotate();
	}

	private bool rotate()
	{
		Vector3 vec = transform.eulerAngles;
		vec.z += (speed * Time.deltaTime);

		transform.eulerAngles = vec;

		if(vec.z >= 122)
		{
			ExitDoor.Open();
			return false;
		}
		else
			return true;

	}

	void OnCollisionEnter(Collision info)
	{
			rotating = true;
			GetComponent<Rigidbody>().isKinematic = true;

	}
}
