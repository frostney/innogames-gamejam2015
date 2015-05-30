using UnityEngine;
using System.Collections;

public class SpikeNippel : MonoBehaviour 
{
	void Start() 
	{
	
	}
	

	void Update() 
	{
	
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
			other.GetComponent<PlayerScript>().Hit();
	}
}
