using UnityEngine;
using System.Collections;

public class ExitDoor : MonoBehaviour 
{
	static OpenDoor opener;

	public static void Open()
	{
		opener.Open = true;	
	}



	void Start() 
	{
		opener = transform.GetComponentInChildren<OpenDoor>();
	}
	


	void Update() 
	{
		
	}
}
