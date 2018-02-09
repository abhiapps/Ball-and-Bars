using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// for functioning of the bars
public class BarController: MonoBehaviour 
{
	public static float barspeed;
	public static float minX, maxX, minY, maxY;
	public Renderer rend;



	void Start ()
	{
		barspeed=3.0f;

	}

	void Update () 
	{

		rend = GetComponent<Renderer> ();
		float barWidth = rend.bounds.size.x;
		barWidth = 3.0f;

		Vector2 bottomCorner = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		Vector2 upperCorner = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
		minX = bottomCorner.x;
		minY = bottomCorner.y;
		maxX = upperCorner.x;
		maxY = upperCorner.y;

		transform.Translate (0.0f, barspeed * Time.deltaTime, 0.0f);//bar movement
			if (transform.position.y > maxY) //recurring of the bars from bottom edge of screen
		{		
			ScoreManager.barMinusScore = ScoreManager.barMinusScore - 1;
			transform.position = new Vector2 (Random.Range (minX, maxX), minY);
			if (gameObject.CompareTag ("BarLeft"))
			{
				
				transform.position = new Vector2 (Random.Range (minX, maxX - barWidth), minY);
				if (Time.timeSinceLevelLoad > 40 && Time.timeSinceLevelLoad < 100) {
					transform.localScale = new Vector3 (Random.Range(barWidth * 0.75f,barWidth * 0.5f), 0.2f, 0.2f);
				} else {
					transform.localScale = new Vector3 (barWidth, 0.2f, 0.2f);
				}

			}
			if (gameObject.CompareTag ("BarCentre")) 
			{
				transform.position = new Vector2 (Random.Range (minX + (barWidth / 2), maxX - barWidth / 2), minY);
				if (Time.timeSinceLevelLoad > 80 && Time.timeSinceLevelLoad < 140) {
					transform.localScale = new Vector3 (Random.Range (barWidth * 0.5f, barWidth * 0.25f), 0.2f, 0.2f);
					barspeed = 4.0f;
					BallController.ballspeed = 14.0f;
					BallController.gravitySpeed = -14.0f;
				} else {
					transform.localScale = new Vector3 (barWidth, 0.2f, 0.2f);
					barspeed = 3.0f;
					BallController.ballspeed = 11.0f;
					BallController.gravitySpeed = -11.0f;
				}
			}
				
			if (gameObject.CompareTag ("BarRight")) {
				transform.position = new Vector2 (Random.Range (minX + barWidth, maxX), minY);
				if (Time.timeSinceLevelLoad > 100 && Time.timeSinceLevelLoad < 160) {
					transform.localScale = new Vector3 (Random.Range (barWidth * 0.5f, barWidth * 0.25f), 0.2f, 0.2f);
				} else {
					transform.localScale = new Vector3 (barWidth, 0.2f, 0.2f);
				}
			}

		}
		if (Time.timeSinceLevelLoad > 180) {

			barspeed = Random.Range (3.0f, 6.0f);
			BallController.rbdrag = 1.0f;
			BallController.ballspeed = 12.0f;
			BallController.gravitySpeed = -12.0f;
			}
		//if (ScoreManager.coinbarScore + ScoreManager.barMinusScore <= 0) {//added on 03/20/17
		//	gameObject.SetActive (false);
		//} 
	
	}
}



