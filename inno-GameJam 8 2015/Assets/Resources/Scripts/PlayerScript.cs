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
	private GameObject wizard;


	public DIRECTION MovingDirection;
	// Use this for initialization
	void Start() 
	{
		GetComponent<Rigidbody>().centerOfMass =  -this.transform.up*5;
		wizard = transform.GetChild(0).gameObject;
	}

	public float speed = 1;
	private float Speed
	{
		get { return (speed * Time.deltaTime); }
	}

	private void checkInput()
	{
		bool left = Input.GetKey(KeyCode.LeftArrow);
		bool right = Input.GetKey(KeyCode.RightArrow);
		DIRECTION newDirection = DIRECTION.STAND;

		if(left && !right)
			newDirection = DIRECTION.LEFT;
		else if(right && !left)
			newDirection = DIRECTION.RIGHT;

		if(newDirection != MovingDirection)
		{
			//rotate the character:
			switch(MovingDirection)
			{
			case DIRECTION.LEFT:
				wizard.transform.right = -transform.right;
				transform.GetChild(0).gameObject.GetComponent<Animation>().Stop();
				break;

			case DIRECTION.STAND:
				wizard.transform.forward = -transform.forward;
				transform.GetChild(0).gameObject.GetComponent<Animation>().Play();
				break;

			case DIRECTION.RIGHT:
				wizard.transform.right = transform.right;
				transform.GetChild(0).gameObject.GetComponent<Animation>().Stop();
				break;
			}

			MovingDirection = newDirection;
		}
	}

	private void moveCharackter()
	{
		if(MovingDirection == DIRECTION.LEFT)
			transform.position += ( -transform.right * Speed );
		else if(MovingDirection == DIRECTION.RIGHT)
			transform.position += ( transform.right * Speed );
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
