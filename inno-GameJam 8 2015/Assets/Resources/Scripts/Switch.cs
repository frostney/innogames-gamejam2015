using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour 
{
	private bool _rotating = false;
	private bool rotating
	{
		get { return _rotating; }
		set
		{
			if(value && !_rotating)
				gameObject.GetComponent<AudioSource>().PlayOneShot(GameMasterScript.Instance.Sounds.Switch);
			_rotating = value;
		}
	}

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
		vec.x -= (speed * Time.deltaTime);

		transform.eulerAngles = vec;

		if(vec.x <= 230)
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
