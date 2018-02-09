using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static float score;
	public static float bestScore;
	public static float barMinusScore;
	//public static float scoreToNextLevel;
	public static float coinbarScore;

	public Text scoreText;
	public Text barCountText;
	public Text CoinbarText;

	//private float spdchnge;


	void Start () {
		score = 0;
		//scoreToNextLevel = 20;
		bestScore = 0;
		barMinusScore = 0;
		coinbarScore = 5f;

		ScoreText ();
		//spdchnge = 1.5f;
		CoinBarText();

	
	}

	void Update () {
		//Debug.Log ((int)Time.timeSinceLevelLoad);

		/*if (GameObject.FindWithTag ("BarCentre") ||
			GameObject.FindWithTag ("BarLeft") || GameObject.FindWithTag ("BarRight")) {
			if (transform.position.y > BarController.maxY) {
				barCountMinus = barCountMinus + 1;*/
				barCountText.text = "Bars: " + ((int)barMinusScore).ToString ();// update version 1.1

			

		//if (score >= scoreToNextLevel) {
		//	LevelUp ();
		//}
		//score += Time.deltaTime;
		//bestScore = score;
		//ScoreText ();
	}

	void OnCollisionEnter(Collision other)//ball collides bars
	{

		if (other.gameObject.CompareTag ("BarCentre") || 
			other.gameObject.CompareTag("BarLeft") || other.gameObject.CompareTag("BarRight")){
			score = score + 1;
			bestScore = score;
			ScoreText ();
		}
		/*if (Time.timeSinceLevelLoad > 10 && Time.timeSinceLevelLoad < 30) 
		{
			BallController.ballspeed++;
			BarController.barspeed =  BarController.barspeed * spdchnge;
			BallController.gravitySpeed = BallController.gravitySpeed * spdchnge*2;
			rb.drag = rb.drag - 0.2f;
		}*/
		if (score > PlayerPrefs.GetInt("Best Score")) {
			PlayerPrefs.SetInt ("Best Score", ((int)bestScore));
		}
	

	}
	void OnTriggerEnter(Collider other) //added on 03/20/17
	{
		if (other.gameObject.tag == "Coin") {
			coinbarScore = coinbarScore + 1;
			CoinBarText ();
			//CoinbarText.text = "Coins:" + ((int)coinbar).ToString ();

		}

	}
	void ScoreText()
	{
		scoreText.text = "Score: " + ((int)score).ToString();		
	}

    void CoinBarText()//added on 03/20/17
	{
		CoinbarText.text = "Coins:" + ((int)coinbarScore).ToString ();
	}
}
