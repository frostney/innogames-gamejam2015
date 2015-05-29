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
		CollissionCheck();
		Move();
	}

	private void CollisionCheck()
	{

	}

	private void Move()
	{
		if (falling)
		{

		}
		else if (moving_left)
		{

		}
		else if (moving_right)
		{

		}
	}

	private void InputCheck()
	{		
		if (Input.GetKeyUp(right) && moving_right)
		{
			Vector3 rotate = this.gameObject.transform.eulerAngles;
			this.gameObject.transform.eulerAngles = new Vector3(rotate.x, rotate_y, rotate.z);
			animation.clip = animation.GetClip(animation_idle);
			animation.Play();
			moving_right = false;
			looking_right = false;
		}
		else if (Input.GetKeyUp(left) && moving_left)
		{
			Vector3 rotate = this.gameObject.transform.eulerAngles;
			this.gameObject.transform.eulerAngles = new Vector3(rotate.x, rotate_y, rotate.z);
			animation.clip = animation.GetClip(animation_idle);
			animation.Play();
			moving_left = false;
			looking_left = false;;
		}
		
		if (Input.GetKeyDown(release))
		{
			Vector3 rotate = this.gameObject.transform.eulerAngles;
			this.gameObject.transform.eulerAngles = new Vector3(rotate.x, rotate_y, rotate.z);
			animation.clip = animation.GetClip(animation_fall);
			animation.Play();
			moving_left = false;
			moving_right = false;
			falling = true;
		}
		
		if (Input.GetKeyDown(right) && !moving_left && !falling)
		{
			Vector3 rotate = this.gameObject.transform.eulerAngles;
			rotate_y = rotate.y;
			this.gameObject.transform.eulerAngles = new Vector3(rotate.x, rotate_y - 90, rotate.z);
			animation.clip = animation.GetClip(animation_walk);
			animation.Play();
			moving_right = true;
			looking_right = true;
		}
		else if (Input.GetKeyDown(left) && !moving_right && !falling)
		{
			Vector3 rotate = this.gameObject.transform.eulerAngles;
			rotate_y = rotate.y;
			this.gameObject.transform.eulerAngles = new Vector3(rotate.x, rotate_y + 90, rotate.z);
			animation.clip = animation.GetClip(animation_walk);
			animation.Play();
			moving_left = true;
			looking_left = true;
		}
	}
}
