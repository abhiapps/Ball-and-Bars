using UnityEngine;
using System.Collections;

public class PrefabScript : MonoBehaviour {

	float prefabSpd;
	void Start () {

		prefabSpd = Random.Range(5.0f,7.0f);
	}
	

	void Update () {
		
			transform.Translate (0.0f, prefabSpd * Time.deltaTime, 0.0f);
			
			if (transform.position.y > BarController.maxY) {
				Destroy (gameObject);
		
		}

		
	}
	/*void  onCollisionOther(Collision other)
	{
		if (other.gameObject.CompareTag ("Ball")) {
			Destroy(gameObject);
			//GetComponent<SpriteRenderer> ().enabled = false;
			BarController.barspeed = BarController.barspeed / 2;	

		}

	}*/
}
