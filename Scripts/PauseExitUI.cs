using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Android game Exit on backbutton for update version 1.1
//Complete new script for Pause/Resume which replaces PauseUI Script// on 03/28/2017
public class PauseExitUI : MonoBehaviour {

	public GameObject pauseMenu;
	public GameObject gameOverMenu;
	public GameObject exitMenu;

	public Button pauseButton;
	public Button yes;
	public Text ExitRestartText;
	public bool paused;
	public GameObject timerScript;

	void Start () {
		paused = false;
		timerScript.GetComponent<TimerScript> ().Start();

	}
		
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape) && 
			gameOverMenu.gameObject.activeInHierarchy == false && 
			timerScript.gameObject.activeInHierarchy == false) { //check if Escape key/Back key is pressed , game pauses only when count down is inactive

			if (paused) { 
				if (pauseMenu.gameObject.activeInHierarchy == true && 
					exitMenu.gameObject.activeInHierarchy == true)
					PauseOn ();
				else 
					PauseOff ();//paused = false;  //resume the game if paused
			}
				else
				PauseOn ();//paused = true;  //pause the game if not paused
		}
		if (paused)
			Time.timeScale = 0;  //all the objects and scripts are halted
			else
			Time.timeScale = 1;  //resume
		/*if(Input.GetKey(KeyCode.Home))
		{
			PauseOn();
		}*/
	}

	public void PauseOn()
	{
		paused = true;
		pauseMenu.gameObject.SetActive (true);
		pauseButton.gameObject.SetActive (false);
		if (exitMenu.gameObject.activeInHierarchy == true ) {
			exitMenu.gameObject.SetActive (false);
		}

	}

	public void PauseOff()
	{
		Start ();
		paused = false;
		pauseMenu.gameObject.SetActive (false);
		if (timerScript.gameObject.activeInHierarchy == false) {//added(03/29/2017) to make pause button inactive while count down is active 
			pauseButton.gameObject.SetActive (true);
		}
		if (exitMenu.gameObject.activeInHierarchy == true) {
			exitMenu.gameObject.SetActive (false);
		}

		//gameObject.GetComponent<TimerScript> ().Start ();
	}

	public void ExitOn()
	{
		exitMenu.gameObject.SetActive (true);
		ExitRestartText.text = "Exit Game?";
		yes.onClick.AddListener (ExitYes);
	}
	void ExitYes()
	{
		SceneManager.LoadScene ("Title");
	}
	public void RestartMenu()
	{
		exitMenu.gameObject.SetActive (true);
		ExitRestartText.text = "New Game?";
		yes.onClick.AddListener (RestartYes);
	}
	void RestartYes()
	{
		SceneManager.LoadScene ("Game");
	}
	public void RestartNo()
	{
		PauseOn ();
	}
	// added on 03/29/2017--------------------------------------
	/*void OnApplicationFocus()
	{
		if (!paused) {
			PauseOff ();
		} else {
			PauseOn ();
		}
		//paused = focus;
	}*/
	void OnApplicationPause(bool pauseStatus)
	{
		if (gameOverMenu.gameObject.activeInHierarchy == false) {
			if (pauseStatus == !paused) {
				PauseOn ();
			} 
		}

	}
	//-----------------------------------------------------------
}
	