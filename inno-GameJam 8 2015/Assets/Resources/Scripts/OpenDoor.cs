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


	public const float closed = 270;
	public const float opened = 400;

	public float eulerY;


	bool AnimateDoor(bool shouldDoorBeOpen)
	{
		if(isAnimating)
		{
			//float eulerY;
		//	timer += Time.deltaTime;
			transform.Rotate(new Vector3(0, 0, 1), shouldDoorBeOpen ? speed* Time.deltaTime : -speed*Time.deltaTime);
			eulerY = transform.eulerAngles.y;
			if(eulerY < 50)
				eulerY += 360;

			if(eulerY < closed || eulerY > opened)
				return shouldDoorBeOpen;

			if(timer >= speed)
				return shouldDoorBeOpen;
		}

		return !shouldDoorBeOpen;
	}

	public void PlaySound(char soundSign)
	{
		if(soundSign == 'o')
			gameObject.GetComponent<AudioSource>().PlayOneShot(GameMasterScript.Instance.Sounds.DoorOpenSound);
		else
			gameObject.GetComponent<AudioSource>().PlayOneShot(GameMasterScript.Instance.Sounds.ExitSound);
	}

	void Start()
	{

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
