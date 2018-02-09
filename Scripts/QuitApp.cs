using UnityEngine;
using System.Collections;

public class QuitApp : MonoBehaviour {

	//for update version 1.1	
	//Quit the game on android Back button click
	void Update () {
		if (Application.platform == RuntimePlatform.Android) {
			if (Input.GetKey (KeyCode.Escape)) {
				Application.Quit ();
			}
		}
	}
}
