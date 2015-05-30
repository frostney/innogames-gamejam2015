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
	private Vector3 GlobalRight,GlobalLeft,GlobalY,GlobalZ;

	public DIRECTION MovingDirection;
	// Use this for initialization
	void Start() 
	{
	
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
				transform.forward = GlobalLeft;
				break;

			case DIRECTION.STAND:
				transform.forward = GlobalZ;
				break;

			case DIRECTION.RIGHT:
				transform.forward = GlobalRight;
				break;
			}
		}
	}

	private void moveCharackter()
	{

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
