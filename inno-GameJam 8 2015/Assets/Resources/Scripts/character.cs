using UnityEngine;
using System.Collections;

public class character : MonoBehaviour 
{
	Animation animation;
	bool moving_right = false;
	bool moving_left = false;
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
	[SerializeField]
	public float max_distance_wall = 1.5f;
	[SerializeField]
	public float max_distance_ground = 1f;
	[SerializeField]
	public string ground_layer = "Ground";

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
		Vector3 pos_char = this.gameObject.transform.localPosition;

		if (falling)
		{
			
		}

		RaycastHit hit;
		Ray rayX = new Ray(pos_char, new Vector2(pos_char.x + 10, 0));
		Physics.Raycast(rayX, out hit, max_distance_wall);
		if (hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer(ground_layer))
		{
			Vector3 rotate = this.gameObject.transform.eulerAngles;
			this.gameObject.transform.eulerAngles = new Vector3(rotate.x, rotate.y, rotate.z + 90);
			pos++;
			if (pos > 3)
				pos = 0;
		}

		rayX = new Ray(pos_char, new Vector2(pos_char.x - 10, 0));
		Physics.Raycast(rayX, out hit, max_distance_wall);		
		if (hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer(ground_layer))
		{
			Vector3 rotate = this.gameObject.transform.eulerAngles;
			this.gameObject.transform.eulerAngles = new Vector3(rotate.x, rotate.y, rotate.z - 90);
			pos--;
			if (pos < 0)
				pos = 3;
		}

		rayX = new Ray(pos_char, new Vector2(0, pos_char.y - 10));
		Physics.Raycast(rayX, out hit, max_distance_ground);
		if (hit.collider == null && !falling)
		{
			SetFalling();
		}
		else if (hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer(ground_layer) && falling)
		{
			animation.clip = animation.GetClip(animation_idle);
			animation.Play();
			falling = false;
		}
	}
		
	private void Move()
	{
		if (moving_left)
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
			this.gameObject.transform.eulerAngles = new Vector3(rotate_x, rotate_y, rotate_z);
			animation.clip = animation.GetClip(animation_idle);
			animation.Play();
			moving_right = false;
		}
		else if (Input.GetKeyUp(left) && moving_left)
		{
			this.gameObject.transform.eulerAngles = new Vector3(rotate_x, rotate_y, rotate_z);
			animation.clip = animation.GetClip(animation_idle);
			animation.Play();
			moving_left = false;
		}
		
		if (Input.GetKeyDown(release))
		{
			SetFalling();
		}
		
		if (Input.GetKeyDown(right) && !moving_left && !falling)
		{
			SetRotation(1);
			moving_right = true;
		}
		else if (Input.GetKeyDown(left) && !moving_right && !falling)
		{
			SetRotation(-1);
			moving_left = true;
		}
	}

	private void SetFalling()
	{
		this.gameObject.transform.eulerAngles = new Vector3(rotate_x, rotate_y, rotate_z);
		animation.clip = animation.GetClip(animation_fall);
		animation.Play();
		moving_left = false;
		moving_right = false;
		falling = true;
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
	