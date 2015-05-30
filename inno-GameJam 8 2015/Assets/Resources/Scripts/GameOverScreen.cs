using UnityEngine;
using System.Collections;

public class GameOverScreen : MonoBehaviour {

	void OnGUI() {
		if (GUI.Button(new Rect(((Screen.width - 150) / 2), Screen.height - 50 - 50, 150, 50), "Click to retry"))
		{
			Application.LoadLevel("Intro");
		}
	}
}
