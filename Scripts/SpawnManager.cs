using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour {

	public GameObject LowBound;
	//public GameObject[] BarCoins;

	private float spawnTime;
	//private float coinSpawnTimer = 6.0f;
	Vector2 position;

	//float elapsedTime = 0;
	//float spawnCycle =5f;
	void Start () {
		spawnTime = Random.Range (5f, 8f);
	
		//elapsedTime += Time.deltaTime;
		InvokeRepeating("SpawnObj", spawnTime, spawnTime);
		//if (elapsedTime == spawnCycle) {
			//Instantiate (LowBound);
		//WaitForSeconds (5f);
		//}
		//elapsedTime = 0;

	}
	

	void Update () {


	//	coinSpawnTimer -= Time.deltaTime;
	//	if (coinSpawnTimer < 0.01) {
	//		SpawnCoins ();
	//	}

			//GameObject temp;
			//temp = (GameObject)Instantiate(LowBound);
			//Vector3 pos = temp.transform.position;
			//temp.transform.position = new Vector3 (Random.Range (3, 3), pos.y, pos.z);
		
	}
	void SpawnObj()
	{
		if (Time.timeSinceLevelLoad > 60) {
			
			position = new Vector2 (Random.Range (BarController.minX, BarController.maxX), BarController.minY);
			Instantiate (LowBound, position, Quaternion.identity);
		}
	}
	/*void SpawnCoins()
	{
		Instantiate(BarCoins[(Random.Range(0,BarCoins.Length))],new Vector2(Random.Range(-3,3) ,Random.Range(-5,5)),Quaternion.identity);
		coinSpawnTimer = Random.Range (2.0f, 5.0f);
			
	}*/
}
