using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//for update version 1.1 -- added on 03/16/2017
public class ObjectPool : MonoBehaviour {
	
	public static int coinPoolSize;
	public static float xPos;
	public GameObject coinPrefab;
	public float spawnRate = 2f;

	private float timeSinceLastSpawn;
	private Vector3 coinsPosition;
	private GameObject[] coins;
	private int currentCoin=0;

	void Start () {
		coinPoolSize = Random.Range (5, 10);
		xPos = Random.Range (-3f, 3f);
		float yCoinDist = -9f;
		//coinsPosition = new Vector3 (0f, yp, -0.2f);//(Random.Range (BarController.minX, BarController.maxX), 
									//Random.Range (BarController.minY, BarController.maxY),-0.2f);
		coins = new GameObject[coinPoolSize];

		for (int i = 0; i < coinPoolSize; i++) {
				coins [i] = (GameObject)Instantiate (coinPrefab);//, coinsPosition, Quaternion.identity);
				coins [i].transform.position = new Vector3 (xPos, yCoinDist, -0.2f);
				yCoinDist = yCoinDist + 0.8f;
		
		}

	}
	

	void Update () {
		//transform.Translate (0.0f, Time.deltaTime, 0.0f);

		timeSinceLastSpawn += Time.deltaTime;

		if (timeSinceLastSpawn >= spawnRate){// && transform.position.y>BarController.maxY) {
			timeSinceLastSpawn = 0;
			//float spawnYposition = 3f;

			coins [currentCoin].transform.position = new Vector3 (xPos,-9f , -0.2f);
			currentCoin++;
			if (currentCoin >= coinPoolSize) {
				currentCoin = 0;
			}
		}
	}

}
