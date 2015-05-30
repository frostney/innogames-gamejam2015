using UnityEngine;
using System.Collections;

public class TutorialHintMove : MonoBehaviour {

	void OnGUI() {
		GUI.Label (new Rect (10, Screen.height - 40 - 10, 250, 40), "Press LEFT and RIGHT to move around.\nOh, and you can run up walls.");
	}

}
