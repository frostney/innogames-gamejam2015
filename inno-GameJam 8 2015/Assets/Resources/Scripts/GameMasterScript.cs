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

	public GameSounds Sounds;

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

	public void NextLevel()
	{
		Camera.current.GetComponent<SceneBlender>().FadeNextScene();
	}

	// Use this for initialization
	void Start()
	{
		Camera.current.GetComponent<SceneBlender>().SetTarget(Player); 
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}
}
