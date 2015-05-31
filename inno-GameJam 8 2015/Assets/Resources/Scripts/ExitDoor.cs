using UnityEngine;
using System.Collections;

public class ExitDoor : MonoBehaviour 
{
	private static OpenDoor opener;

 
	public static void Open()
	{
		opener.Open = true;
		opener.PlaySound('o');
	}

	public static void PlayerExit()
	{
		opener.PlaySound('e');
		GameMasterScript.Instance.NextLevel();
	}

	void Start() 
	{
		opener = transform.GetComponentInChildren<OpenDoor>();
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
			PlayerExit();
	}

	void Update() 
	{
		
	}
}
