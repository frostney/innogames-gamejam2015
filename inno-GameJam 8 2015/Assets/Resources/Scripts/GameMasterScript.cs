using UnityEngine;
using System.Collections;

public class GameMasterScript : MonoBehaviour 
{

	private static GameMasterScript _instance = null;
	public static GameMasterScript Instance
	{
		get { return _instance; }
	}

	private GameObject Player;
	private GameObject Door;

	void Awake()
	{
		if(_instance != null && _instance != this)
		{
			Destroy(gameObject);
			return;
		}

		_instance = this;
		Player = GameObject.Find("Player");
		Door = GameObject.Find("Door");

		DontDestroyOnLoad(gameObject);
	}


	// Use this for initialization
	void Start()
	{

	}
	
	// Update is called once per frame
	void Update()
	{
		
	}
}
