using UnityEngine;
using System.Collections;

public class TitleScreen : MonoBehaviour 
{
	public SceneBlender sceneblender;


	void OnGUI() {
		GUI.Label (new Rect (10, Screen.height - 50 - 10, 200, 50), "André Ahrendt\nKalle Münster\nJohannes Stein");
		GUI.Label (new Rect (Screen.width - 200 - 10, Screen.height - 20 - 10, 200, 20), "Made for InnoGames GameJam 8");

		if (GUI.Button(new Rect(((Screen.width - 150) / 2), Screen.height - 50 - 50, 150, 50), "Click here to start"))
		{
			sceneblender.FadeToNextScene = true;
			
		//	Application.LoadLevel("Intro");
		}
	}
}
