using UnityEngine;
using System.Collections;

public class Spiker : MonoBehaviour
{
	private const float UP = 2;
	private const float DOWN = 0;
	private Vector3 ZEROPOINT;

	public float timer = 0;
	[SerializeField]
	private bool attack = false;
	private float position = DOWN;
	private bool isAttacking = false;
	private bool Attack	   
	{
		get { return attack; }
		set
		{
			if(value && !isAttacking)
			{
				directionUp = true;
			}
			isAttacking = attack = value;
		}
	}

	public float speed;
	private bool directionUp = false;
	private bool AttackAnimation()
	{
		timer = timer + (directionUp? (Time.deltaTime*2) : -(Time.deltaTime/2) );

		position = Mathf.Lerp(DOWN, UP, timer / speed);

		transform.position = ZEROPOINT + ( transform.up * position );

		if(position >= UP)
		{
			position = UP;
			directionUp = false;
		}
		else if(position <= DOWN)
		{
			position = DOWN;
			directionUp = true;
			isAttacking = attack = false;
			timer = 0;
			return false;
		}

		return true;
	}

	// Use this for initialization
	void Start() 
	{
		ZEROPOINT = transform.position;
		
	}
	
	// Update is called once per frame
	void Update() 
	{
		if(attack)
			Attack = AttackAnimation();
	}

}

