using UnityEngine;
using System.Collections;

public class SpikeNippel : MonoBehaviour 
{
	private const float ATTAX = 0.8f;
	private const float MAX = -0.55f;
	private const float MIN = -0.8f;
	private const float ORIGIN = 0;

	private float max;
	private float position = ORIGIN;

	private float counter = 0;
//	private byte inverter = 1;
	public float speed = 1.0f;

	private bool attack = false;
	public bool Attack
	{
		get { return attack; }
		set
		{
			if(value && !attack)
				gameObject.transform.parent.gameObject.GetComponent<AudioSource>().PlayOneShot(GameMasterScript.Instance.Sounds.SpikerPiker);
			
			attack = value;
		}
	}

	private float lastCounter = 0;

	public bool Animate()
	{
		bool returnvalue = attack;

		if(( counter += ( speed * Time.deltaTime ) ) > 360)
			counter -= 360;
		else if(counter >= 270 && lastCounter < 270)
			returnvalue = false;

		max = attack ? ( max < ATTAX ? max + 0.05f : max ) : ( max > MAX ? max - 0.05f : max );

		position = Mathf.Sin(counter) * (( max - MIN ) / 2);

		Vector3 scale = transform.localScale;
		scale.z = ORIGIN + position;
		transform.localScale = scale;

		return returnvalue;
	}

	void Update()
	{
	//	Attack = Animate();
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
			other.GetComponent<PlayerScript>().Hit();
	}
}
