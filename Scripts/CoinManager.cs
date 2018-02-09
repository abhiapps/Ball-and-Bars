using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// added on 03/14/2017 for generating coins 
public class CoinManager : MonoBehaviour {

	//public Text CoinbarText;
	//public static float coinbar;

	float coinSpd;
	void Start()
	{
		coinSpd = 2f;
		//gameObject.GetComponent<ScoreManager>().CoinBarText ();
	}
	public void Update()
	{	
		if (Time.timeSinceLevelLoad > 5f) 
		{
			transform.Translate (0.0f, coinSpd * Time.deltaTime, 0.0f);
			/*if (transform.position.y > BarController.maxY) 
			{
				//transform.position = new Vector2(1f,-8f);
				gameObject.SetActive (false);
			}*/
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Ball") {
			gameObject.SetActive (false);
			//ScoreManager.coinbar = ScoreManager.coinbar + 1;
			//gameObject.GetComponent<ScoreManager>().CoinBarText ();
			//CoinbarText.text = "Coins:" + ((int)coinbar).ToString ();

		}
			
	}

	/*void CoinBarText()
	{
		CoinbarText.text = "Coins:" + ((int)coinbar).ToString ();
	}*/
}
