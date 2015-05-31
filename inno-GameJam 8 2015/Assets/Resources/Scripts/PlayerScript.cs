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
//	private GameObject wizard;


	public DIRECTION MovingDirection;
	// Use this for initialization
	void Start() 
	{
		GetComponent<Rigidbody>().centerOfMass =  -this.transform.up * 5;
	//	wizard = transform.GetChild(0).gameObject;
	}

	public float speed = 1;
	private float Speed
	{
		get { return (speed * Time.deltaTime); }
	}
	bool left;
	bool right;
	private void checkInput()
	{
		if(Input.GetKeyDown(KeyCode.LeftArrow))
			{ left = true; right = false; }

		if(Input.GetKeyDown(KeyCode.RightArrow))
			{ left = false; right = true; }

		if(Input.GetKeyUp(KeyCode.LeftArrow))
			{ left = false; }

		if(Input.GetKeyUp(KeyCode.RightArrow))
			{ right = false; }

		DIRECTION newDirection = DIRECTION.STAND;

		if(left && !right)
			newDirection = DIRECTION.LEFT;
		else if(right && !left)
			newDirection = DIRECTION.RIGHT;

		if(newDirection != MovingDirection)
		{
			//rotate the character:
			switch(newDirection)
			{
			case DIRECTION.LEFT:
				//transform.eulerAngles = new Vector3(transform.eulerAngles.x, 90.0f, transform.eulerAngles.z);
		
				break;

			case DIRECTION.STAND:
				//transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180.0f, transform.eulerAngles.z);

				break;

			case DIRECTION.RIGHT:
				//transform.eulerAngles = new Vector3(transform.eulerAngles.x, -90.0f, transform.eulerAngles.z);
			
				break;
			}

			MovingDirection = newDirection;
		}
	}

	private void moveCharackter()
	{

		if(MovingDirection == DIRECTION.LEFT)
			transform.position += ( transform.right * Speed );
		else if(MovingDirection == DIRECTION.RIGHT)
			transform.position += ( -transform.right * Speed );
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
