using UnityEngine;
using System.Collections;

public class TutorialHintSwitch : MonoBehaviour {

	void OnGUI() {
		GUI.Label (new Rect (10, Screen.height - 40 - 10, 250, 40), "Press X to change gravity.");
	}

}
