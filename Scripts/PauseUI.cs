using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//for game pause and resume
public class PauseUI : MonoBehaviour {

	public GameObject pauseMenu;
	public Button Pause;
	public bool isPaused;
	public GameObject exitMenu;         
	public GameObject gameOverMenu;
	public static bool isExit;

	void Start () 
		{
		isPaused = false;
		isExit = false;
		}
	

	void Update () {
		if (isPaused) {
				PauseGame (true);
		} else {	
			PauseGame (false);
		}
		//added on 03/24/2017-------------------------------------------------
		//if (Input.GetKey (KeyCode.Escape) && gameOverMenu.gameObject.activeInHierarchy == false) {		
		//	if (!isPaused)
		//		PauseOn();

			//else //if (Input.GetKey(KeyCode.Escape)&& pauseMenu.gameObject.activeInHierarchy == true){
			//	PauseOff ();//exitMenu.gameObject.SetActive (true);
			

		//}		

		//--------------------------------------------------------------------
	}
	void PauseGame(bool state)
	{
		if (state) {
			
			Time.timeScale = 0.0f;//paused

		} else {	
			Time.timeScale = 1.0f;//Resumed
		}
			pauseMenu.gameObject.SetActive (state);
	}
	public void PauseOn()
	{
		if (!isPaused) 
		{
			isPaused = true;
			Pause.gameObject.SetActive (false);
		}
		if (exitMenu.gameObject.activeInHierarchy == true) {
			exitMenu.gameObject.SetActive (false);
		}
	}
	public void PauseOff()
	{
		if (isPaused) 
		{
			isPaused = false;
			//added on 03/24/2017------------------------------------------------------------
			//if (GameObject.FindWithTag("Respawn").GetComponent<TimerScript>().enabled == false) {
			Pause.gameObject.SetActive (true);
			//}
		}
				if (exitMenu.gameObject.activeInHierarchy == true) {
				exitMenu.gameObject.SetActive (false);	
		}
	}
	public void ExitOn()
	{
		exitMenu.gameObject.SetActive (true);

	}
	//--------------------------------------------------------------------------------------------
}