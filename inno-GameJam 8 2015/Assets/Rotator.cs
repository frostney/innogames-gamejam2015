using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	public Vector3 TargetDirection = new Vector3(1,0,0);
	public Vector3 currentDirection = new Vector3(1,0,0);
	
	public float speed = 10;
	public float angel = 0;
	private bool isRotating = false;
	private Vector3 startDirection = new Vector3(1, 0, 0);
	private float timer;
	public float rotationTime = 1;

	void Start() 
	{
	
	}

	private void rotate()
	{
		if(!isRotating)
			startDirection = currentDirection;
		timer += Time.deltaTime;
		currentDirection = Vector3.Lerp(startDirection, TargetDirection, timer / rotationTime);

	}
	
	// Update is called once per frame
	void Update() 
	{
		if(TargetDirection != currentDirection)
			rotate();
	}
}
