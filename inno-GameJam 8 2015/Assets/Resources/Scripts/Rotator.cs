using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	public Transform characterTransform;

	private Vector3 rotationAxis = new Vector3(0, 0, 1);

	public float TargetAngle = 0;
	public float startAngle = 0;
	public float currentAngle = 0;

	public float speed = 10;
	private bool isRotating=false;
	//private Vector3 startDirection = new Vector3(1, 0, 0);
	private float timer;
	public float rotationTime = 2;

	void Start() 
	{
		characterTransform = GameObject.Find("Player").GetComponent<Transform>();
		transform.forward= new Vector3(0,0,1);
	}

	private void rotate()
	{
	//	if(!isRotating)
	//	{
	//		startAngle = currentAngle;
	//		isRotating = true;
	//	}
	//	timer += Time.deltaTime;
		transform.Rotate(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, characterTransform.rotation.eulerAngles.x);
		
		if((startAngle<TargetAngle)? currentAngle >= TargetAngle : currentAngle <= TargetAngle)
		{
			currentAngle = TargetAngle;
			isRotating = false;
			timer = 0;
		}
	}
	
	// Update is called once per frame
	void Update() 
	{
		transform.eulerAngles = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, characterTransform.rotation.eulerAngles.x);

	//	TargetAngle = characterTransform.rotation.eulerAngles.x;

	//	if(TargetAngle != currentAngle)
	//		rotate();
	}
}
