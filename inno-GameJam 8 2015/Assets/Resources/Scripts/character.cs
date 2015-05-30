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

		int z = 0;
		int rx = 0;
		int y = 0;
		int ry = 0;
		switch(pos)
		{
		case 0: y = -10 + (int)pos_char.y;
			break;
		case 1: z = 10 + (int)pos_char.z;
			break;
		case 2: y = 10 + (int)pos_char.y;
			break;
		case 3: z = -10 + (int)pos_char.z;
			break;
		}

		RaycastHit hit;
		float temp_distance = 0f;
		Ray rayX = new Ray(pos_char, new Vector3(0,y,z));
		Physics.Raycast(rayX, out hit, max_distance_ground);
		if (hit.collider == null && !falling)
		{
			;//SetFalling();
		}
		else if (hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer(ground_layer) && falling)
		{
			animation.clip = animation.GetClip(animation_idle);
			animation.Play();
			falling = false;
		}
		else
		{
			temp_distance = hit.distance;
			Debug.Log ("temp:" + temp_distance);
		}


		/*
		x = 0;
		y = 0;
		switch(pos)
		{
		case 0: x = -10 + (int)pos_char.x;
			rx = -90;
			break;
		case 1: y = -10 + (int)pos_char.y;
			ry = -90;
			break;
		case 2: x = 10 + (int)pos_char.x;
			rx = 90;
			break;
		case 3: y = 10 + (int)pos_char.y;
			ry = 90;
			break;
		}

		rayX = new Ray(pos_char, new Vector2(x,y));
		Physics.Raycast(rayX, out hit, max_distance_wall);
		if (hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer(ground_layer) && moving_right)
		{
			Vector3 rotate = this.gameObject.transform.eulerAngles;
			this.gameObject.transform.eulerAngles = new Vector3(rotate.x +rx, rotate.y +ry, rotate.z);
			rotate_z -= 90;
			ClimbingCorrection(temp_distance, -1);
			pos++;
			if (pos > 3)
				pos = 0;
		}*/
/*
		rayX = new Ray(pos_char, new Vector2(pos_char.x - 10, 0));
		Physics.Raycast(rayX, out hit, max_distance_wall);		
		if (hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer(ground_layer) && moving_left)
		{
			Vector3 rotate = this.gameObject.transform.eulerAngles;
			this.gameObject.transform.eulerAngles = new Vector3(rotate.x - 90, rotate.y, rotate.z);
			ClimbingCorrection(temp_distance, -1);
			pos--;
			if (pos < 0)
				pos = 3;
		}*/
		
		CollisionSideTest(1, pos_char, temp_distance);
		CollisionSideTest(-1, pos_char, temp_distance);
	}

	private void CollisionSideTest(short direction, Vector3 pos_char, float temp_distance)
	{
		bool moving = direction == 1 ? moving_right : moving_left;
		int x = 0;
		int y = 0;
		switch(pos)
		{
		case 0: x = 10 * direction;
			x+= (int)pos_char.x;
			break;
		case 1: y = 10 * direction;
			y+= (int)pos_char.y;
			break;
		case 2: x = -10 * direction;
			x+= (int)pos_char.x;
			break;
		case 3: y = -10 * direction;
			y+= (int)pos_char.y;
			break;
		}

		RaycastHit hit;
		Ray rayX = new Ray(pos_char, new Vector2(x, y));
		Physics.Raycast(rayX, out hit, max_distance_wall);
		if (hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer(ground_layer) && moving)
		{
			Vector3 rotate = this.gameObject.transform.eulerAngles;
			this.gameObject.transform.eulerAngles = new Vector3(rotate.x - 90 * direction, rotate.y, rotate.z );
			rotate_z -= 90 * direction;

			ClimbingCorrection(temp_distance, direction);
			pos += direction;
			if (pos > 3)
				pos = 0;
		
			if (pos < 0)
				pos = 3;
		}
	}

	private void ClimbingCorrection(float distance, short direction)
	{
		float temp = 0f;
		int x = 0;
		int y = 0;
		switch(pos)
		{
		case 0: x = 10 * direction;
			break;
		case 1: y = -10 * direction;
			break;
		case 2: x = -10 * direction;
			break;
		case 3: y = 10 * direction;
			break;
		}

		bool run = true;
		RaycastHit hit;
		while(run)
		{
			Vector3 pos_char = this.gameObject.transform.localPosition;
			Ray rayX = new Ray(pos_char, new Vector2(x, y));
			Physics.Raycast(rayX, out hit, max_distance_wall);
			if (hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer(ground_layer))
			{Debug.Log (hit.distance);
				temp = hit.distance;
				this.gameObject.transform.Translate(0, (distance - temp), 0);

				/*falling = true;
				moving_left = false;
				moving_right = false;*/

				run = false;
			}
			else
			{
				run = false;
				this.gameObject.transform.Translate(0, distance , 0);
			}
		}
	}

	private void Move()
	{
		if (moving_left || moving_right)
		{
			this.gameObject.transform.Translate( 0, 0, Time.deltaTime * walk_speed);
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
		case 1: x = -90 * direction;
			break;
		case 2: y = 90 * direction;
			break;
		case 3: x = 90 * direction;
			break;
		}
		
		this.gameObject.transform.eulerAngles = new Vector3(rotate_x + x, rotate_y + y, rotate_z);
		animation.clip = animation.GetClip(animation_walk);
		animation.Play();
	}
}
	