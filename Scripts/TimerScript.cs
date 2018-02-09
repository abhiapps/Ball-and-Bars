using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//start a count down before the game starts
public class TimerScript : MonoBehaviour {


	public Text countDownText;
	public Button PauseButton;
	//public GameObject pauseScript;

	int CountDown;
	int time;

	public void Start () 
	{	
		gameObject.SetActive (true);
		countDownText = GetComponent<Text> ();
		//pauseScript.GetComponent<PauseExitUI> ().PauseOn ();
		GameObject.Find ("Ball").GetComponent<BallController> ().enabled = false;
		//GameObject.Find ("Ball").GetComponent<Rigidbody> ().useGravity = false;
		GameObject.Find ("Ball").GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezePositionY;
		GameObject.Find ("BarLeft").GetComponent<BarController> ().enabled = false;
		GameObject.Find ("BarRight").GetComponent<BarController> ().enabled = false;
		GameObject.Find ("BarCentre").GetComponent<BarController> ().enabled = false;
		//GameObject.Find ("ExitUI").GetComponent<ExitUI> ().enabled = false;
		//GameObject.Find ("Coin").GetComponent<CoinManager> ().enabled = false;
		StartCoroutine (CountDownWait ());

	}

	void Update()
	{		
	}
	IEnumerator CountDownWait()
	{
		
		for (CountDown = 3; CountDown > 0; CountDown--) {
			if (CountDown != 1) {
				countDownText.text = CountDown.ToString ();
				yield return new WaitForSeconds (1);
			} else {
				countDownText.text = "Go!";
				yield return new WaitForSeconds (1);
			}
		}
		GameObject.Find ("Ball").GetComponent<BallController> ().enabled = true;
		//GameObject.Find ("Ball").GetComponent<Rigidbody> ().useGravity = true;
		//GameObject.Find ("Ball").GetComponent<Rigidbody> ().constraints &= ~RigidbodyConstraints.FreezePositionY;
		//GameObject.Find ("Ball").GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezePositionZ;
		GameObject.Find ("Ball").GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotationZ;
		GameObject.Find ("BarLeft").GetComponent<BarController> ().enabled = true;
		GameObject.Find ("BarRight").GetComponent<BarController> ().enabled = true;
		GameObject.Find ("BarCentre").GetComponent<BarController> ().enabled = true;
		//GameObject.Find ("ExitUI").GetComponent<ExitUI> ().enabled = true;
		//GameObject.Find ("Coin").GetComponent<CoinManager> ().enabled = true;
		PauseButton.gameObject.SetActive (true);
		//Destroy (gameObject);
		gameObject.SetActive(false);
	}

}