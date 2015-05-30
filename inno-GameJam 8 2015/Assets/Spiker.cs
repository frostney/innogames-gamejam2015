using UnityEngine;
using System.Collections;

public class Spiker : MonoBehaviour
{
	private const float UP = 1;
	private const float DOWN = -1;
	private Vector3 ZEROPOINT;

	[SerializeField]
	private bool attack = false;
	private float position = DOWN;
	private bool Attack
	{
		get { return attack; }
		set
		{
			if(value && !directionUp)
				directionUp = true;

			attack = value;
		}
	}

	public float speed;
	private bool directionUp = false;
	private bool AttackAnimation()
	{
		if(directionUp)
			position += Time.deltaTime * speed * 4;
		else
			position -= Time.deltaTime * speed / 2;

		if(position >= UP)
			directionUp = false;

		transform.position = ZEROPOINT + ( transform.up * position );

		return !( position <= DOWN );
	}

	// Use this for initialization
	void Start() 
	{
		ZEROPOINT = transform.position;
		transform.position = ZEROPOINT + (transform.up * position);
	}
	
	// Update is called once per frame
	void Update() 
	{
		if(Attack)
			Attack = AttackAnimation();
	}

}

