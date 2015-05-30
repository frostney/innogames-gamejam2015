using UnityEngine;
using System.Collections;

public class character : MonoBehaviour 
{
	Animation animation;
	bool moving_right = false;
	bool moving_left = false;
	bool looking_right = false;
	bool looking_left = false;
	bool falling = false;
	float rotate_y = 0f;
	float rotate_x = 0f;
	float rotate_z = 0f;
	short pos = 0;

	[SerializeField]
	public string animation_idle = "None";
	[SerializeField]
	public string animation_walk = "Default Take";
	[SerializeField]
	public string animation_fall = string.Empty;
	[SerializeField]
	public KeyCode left = KeyCode.LeftArrow;
	[SerializeField]
	public KeyCode right = KeyCode.RightArrow;
	[SerializeField]
	public KeyCode release = KeyCode.Space;
	[SerializeField]
	public float falling_speed = 10f;
	[SerializeField]
	public float walk_speed = 5f;

	// Use this for initialization
	void Start () 
	{
		animation = this.gameObject.GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		InputCheck();
		CollisionCheck();
		Move();
	}

	private void CollisionCheck()
	{
		if (falling)
		{
			Vector3 camera_rotation = Camera.main.transform.eulerAngles;
			Camera.main.transform.eulerAngles = new Vector3(camera_rotation.x,camera_rotation.y, camera_rotation.z + 90);
			Vector3 rotate = this.gameObject.transform.eulerAngles;
			this.gameObject.transform.eulerAngles = new Vector3(rotate.x, rotate.y, rotate.z + 90);
			falling = false;
		}
	}

	private void Move()
	{
		if (falling)
		{

		}
		else if (moving_left)
		{
			this.gameObject.transform.Translate(0, 0, Time.deltaTime * walk_speed);
		}
		else if (moving_right)
		{
			this.gameObject.transform.Translate(0, 0, Time.deltaTime * walk_speed);
		}
	}

	private void InputCheck()
	{		
		if (Input.GetKeyUp(right) && moving_right)
		{
			Vector3 rotate = this.gameObject.transform.eulerAngles;
			this.gameObject.transform.eulerAngles = new Vector3(rotate_x, rotate_y, rotate_z);
			animation.clip = animation.GetClip(animation_idle);
			animation.Play();
			moving_right = false;
			looking_right = false;
		}
		else if (Input.GetKeyUp(left) && moving_left)
		{
			Vector3 rotate = this.gameObject.transform.eulerAngles;
			this.gameObject.transform.eulerAngles = new Vector3(rotate_x, rotate_y, rotate_z);
			animation.clip = animation.GetClip(animation_idle);
			animation.Play();
			moving_left = false;
			looking_left = false;
		}
		
		if (Input.GetKeyDown(release))
		{
			Vector3 rotate = this.gameObject.transform.eulerAngles;
			this.gameObject.transform.eulerAngles = new Vector3(rotate_x, rotate_y, rotate_z);
			animation.clip = animation.GetClip(animation_fall);
			animation.Play();
			moving_left = false;
			moving_right = false;
			falling = true;
			pos++;
			if (pos > 3)
				pos = 0;
		}
		
		if (Input.GetKeyDown(right) && !moving_left && !falling)
		{
			SetRotation(1);
			moving_right = true;
			looking_right = true;
		}
		else if (Input.GetKeyDown(left) && !moving_right && !falling)
		{
			SetRotation(-1);
			moving_left = true;
			looking_left = true;
		}
	}

	private void SetRotation(short direction)
	{
		Vector3 rotate = this.gameObject.transform.eulerAngles;
		rotate_y = rotate.y;
		rotate_x = rotate.x;
		rotate_z = rotate.z;
		int x = 0;
		int y = 0;
		switch(pos)
		{
		case 0: y = -90 * direction;
			break;
		case 1: x = 90 * direction;
			break;
		case 2: y = 90 * direction;
			break;
		case 3: x = -90 * direction;
			break;
		}
		
		this.gameObject.transform.eulerAngles = new Vector3(rotate_x + x, rotate_y + y, rotate_z);
		animation.clip = animation.GetClip(animation_walk);
		animation.Play();
	}
	}
	