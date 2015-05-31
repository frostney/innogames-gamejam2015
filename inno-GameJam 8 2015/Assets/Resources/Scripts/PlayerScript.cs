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
	private Transform innerTransform;

	public int massPoint=10;

	public DIRECTION MovingDirection;
	// Use this for initialization
	void Start() 
	{
		GetComponent<Rigidbody>().centerOfMass =  (-this.transform.up * massPoint);
		innerTransform = transform.GetChild(0);
	}

	public float speed = 3;
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
			//	innerTransform.up = this.transform.up;
			//	innerTransform.forward = this.transform.right;
		
				break;

			case DIRECTION.STAND:
				innerTransform.rotation = this.transform.rotation;
				innerTransform.localEulerAngles = new Vector3( innerTransform.localEulerAngles.x,180, innerTransform.localEulerAngles.z);

				//transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180.0f, transform.eulerAngles.z);

				break;

			case DIRECTION.RIGHT:
			//	innerTransform.forward = -this.transform.right;
				//transform.eulerAngles = new Vector3(transform.eulerAngles.x, -90.0f, transform.eulerAngles.z);
			
				break;
			}

			MovingDirection = newDirection;
		}
	}

	private void moveCharackter()
	{
		switch (MovingDirection)
		{
		case DIRECTION.LEFT:
			innerTransform.rotation = this.transform.rotation;
			innerTransform.localEulerAngles = new Vector3(innerTransform.localEulerAngles.x, -90.0f, innerTransform.localEulerAngles.z);
		//	innerTransform.up = this.transform.up;
		//	innerTransform.forward = -this.transform.right;
			this.transform.position += ( -this.transform.right * Speed );
			break;

		case DIRECTION.STAND:

			break;

		case DIRECTION.RIGHT:
			innerTransform.rotation = this.transform.rotation;
			innerTransform.localEulerAngles = new Vector3(innerTransform.localEulerAngles.x, 90.0f, innerTransform.localEulerAngles.z);
		//	innerTransform.up = this.transform.up;
		//	innerTransform.forward = this.transform.right;
			this.transform.position += ( this.transform.right * Speed );
			break;
		}
		
			
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
