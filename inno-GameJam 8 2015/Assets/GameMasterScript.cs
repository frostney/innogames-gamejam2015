using UnityEngine;
using System.Collections;

public class GameMasterScript : MonoBehaviour 
{
	private static GameMasterScript _instance = null;
	public static GameMasterScript Instance
	{
		get { return _instance; }
	}

	void Awake()
	{
		if(_instance != null && _instance != this)
		{
			Destroy(gameObject);
			return;
		}

		_instance = this;

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
