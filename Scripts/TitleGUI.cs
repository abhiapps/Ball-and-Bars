using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//code for switching scenes
public class TitleGUI : MonoBehaviour {

	public Text bestScoreText;

	void Start()
	{
		bestScoreText.text = "Best Score:" + (PlayerPrefs.GetInt ("Best Score")).ToString ();
	}


	public void LoadScene(int Game)
	{
		SceneManager.LoadScene (Game);
	}

}
