using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//this code is for functioning of the ball
public class BallController : MonoBehaviour 
{
	public static float ballspeed;

	public Button Pause;
	public GameObject GameOverMenu;
	//public Image Busted;
	//public Button PlayAgain;
	//public Button Quit;
	public Renderer rend;
	public static float rbdrag;
	public static float gravitySpeed;

	private float minX, maxX, minY, maxY;


	Vector2 startPosTouch;
	Vector2 endPosTouch;

	float swipeTime;
	float startTouchTime;
	float endTouchTime;

	void Start ()
	{
		ballspeed = 11.0f;
		gravitySpeed = -11.0f;
		rbdrag = gameObject.GetComponent<Rigidbody>().drag;

	}
	
	void Update ()
	{	
		Physics.gravity = new Vector3 (0, gravitySpeed, 0);
		rend = GetComponent<Renderer> ();
		float ballWidth = rend.bounds.size.x;
		gameObject.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezePositionZ;//added 03/30/2017
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch (0);
			if (touch.phase == TouchPhase.Began) {
				startPosTouch = touch.position;
				endPosTouch = touch.position;		

			}
			if (touch.phase == TouchPhase.Moved) 
			{
				endPosTouch = touch.position;
				Vector2 distance = endPosTouch - startPosTouch;
				//float ballAngle = Mathf.Atan ((distance.y + 4.905f) / distance.x);
				//float totalVel = distance.x / Mathf.Cos (ballAngle);
				//float xVelo, yVelo;
				//xVelo = totalVel * Mathf.Cos (ballAngle);
				//yVelo = totalVel * Mathf.Sin (ballAngle);
				//Rigidbody2D rigid;
				//rigid = GetComponent<Rigidbody2D> ();
				//rigid.velocity = new Vector2 (xVelo, yVelo);

				if (distance.x > 0) 
				{
					transform.position += Vector3.right *  ballspeed * Time.deltaTime;

				}
				if (distance.x < 0) 
				{
					transform.position += Vector3.left * ballspeed * Time.deltaTime;
				}
			
			}
			if (touch.phase == TouchPhase.Ended)
			{
				endPosTouch = touch.position;
			}
		}
			
		Vector2 bottomCorner = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		Vector2 topCorner = Camera.main.ViewportToWorldPoint (new Vector2 (1,1));

		minX = bottomCorner.x;
		minY = bottomCorner.y;
		maxX = topCorner.x;
		maxY = topCorner.y;

		Vector2 pos = transform.position; //current position
		if (pos.y < minY || pos.y > maxY)
		{
			
			GameOver ();

		}
		if (pos.x+ballWidth > maxX || pos.x-ballWidth < minX) //ball does not go off the left and right edges
		{
			transform.position = new Vector2 (Mathf.Clamp(pos.x,minX+ballWidth/2,maxX-ballWidth/2),pos.y);
		}


	}
	void GameOver()
	{
		Destroy (gameObject);
		Pause.gameObject.SetActive (false);
		GameOverMenu.gameObject.SetActive (true);
		//Busted.gameObject.SetActive (true);
		//GameObject.Find ("ExitUI").GetComponent<ExitUI> ().enabled = false;
		//PlayAgain.gameObject.SetActive (true);
		//Quit.gameObject.SetActive (true);
	}


}



