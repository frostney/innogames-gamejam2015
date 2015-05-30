using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	public Transform characterTransform;
	public Vector3 TargetDirection = new Vector3(1,0,0);
	public Vector3 currentDirection = new Vector3(1,0,0);
	
	public float speed = 10;
	public float angel = 0;
	private bool isRotating=false;
	private Vector3 startDirection = new Vector3(1, 0, 0);
	private float timer;
	public float rotationTime = 2;

	void Start() 
	{
		characterTransform = GameObject.Find("Player").GetComponent<Transform>();
		transform.right = TargetDirection = characterTransform.forward;
	}

	private void rotate()
	{
		if(!isRotating)
			startDirection = currentDirection;
		timer += Time.deltaTime;
		transform.right = -(currentDirection = Vector3.Lerp(startDirection, TargetDirection, timer / rotationTime));
		if(currentDirection == TargetDirection)
		{
			isRotating = false;
			timer = 0;
		}
	}
	
	// Update is called once per frame
	void Update() 
	{
		TargetDirection = characterTransform.forward;
		if(TargetDirection != currentDirection)
			rotate();
	}
}
