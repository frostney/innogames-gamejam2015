using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour 
{

	public enum DIRECTION
	{
		LEFT = -1,
		STAND = 0,
		RIGHT = 1
	}

	[SerializeField]
	private Vector3 Right,Left;

	public float speed = 1;
	public DIRECTION MovingDirection;
	// Use this for initialization
	void Start() 
	{
		GetComponent<Rigidbody>().centerOfMass =  -this.transform.up*5;
	}

	private void checkInput()
	{
		DIRECTION newDirection = (DIRECTION)Input.GetAxis("Horizontal");

		if(newDirection != MovingDirection)
		{
			//rotate the character:
			switch(MovingDirection)
			{
			case DIRECTION.LEFT:
				transform.forward = -Camera.current.gameObject.transform.right;
				transform.GetChild(0).gameObject.GetComponent<Animation>().Play();
				break;

			case DIRECTION.STAND:
				transform.GetChild(0).gameObject.GetComponent<Animation>().Stop();
				break;

			case DIRECTION.RIGHT:
				transform.forward = Camera.current.gameObject.transform.right;
				transform.GetChild(0).gameObject.GetComponent<Animation>().Play();
				break;
			}

			MovingDirection = newDirection;
		}
	}

	private void moveCharackter()
	{
		if(MovingDirection == DIRECTION.LEFT || MovingDirection == DIRECTION.RIGHT)
			transform.position += transform.forward * speed;
	}
	
	// Update is called once per frame
	void Update()
	{
		checkInput();
		moveCharackter();
	}

	public void Hit()
	{
		//todo .. player get hit by Spikes or other enemy...
	}

}
