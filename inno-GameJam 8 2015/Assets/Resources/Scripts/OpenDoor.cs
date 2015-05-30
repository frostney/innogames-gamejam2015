using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {

	private bool isAnimating = false;
	[SerializeField]
	private bool open = false;
	private bool isOpen = false;
	public bool Open
	{
		get { return open; }
		set
		{
			 if(value!=isOpen && !isAnimating)
			 {
				 isAnimating = true;
				 timer = 0;
			 }

			 if(value == isOpen)
				 isAnimating = false;
			 open = value;
		}
	}

	private Vector3 START,END;
	private float timer=0;
	public float speed = 3;


	private float closed;

	bool AnimateDoor(bool shouldDoorBeOpen)
	{
		if(isAnimating)
		{
			float eulerY;
		//	timer += Time.deltaTime;
			transform.Rotate(new Vector3(0, 0, 1), shouldDoorBeOpen ? speed* Time.deltaTime : -speed*Time.deltaTime);
			eulerY = transform.eulerAngles.y;

			if(eulerY <= closed || eulerY >= closed+115)
			return shouldDoorBeOpen;

			if(timer >= speed)
				return shouldDoorBeOpen;
		}

		return !shouldDoorBeOpen;
	}



	void Start()
	{
		closed = transform.eulerAngles.y;
	}
	

	void Update()
	{
		Open = open;
		if (Open != isOpen)
		{
			isOpen = AnimateDoor(Open);
		}
	}
}
