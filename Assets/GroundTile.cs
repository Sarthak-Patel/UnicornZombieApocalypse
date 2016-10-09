using UnityEngine;
using System.Collections;

public class GroundTile : MonoBehaviour {

	private int tileCount;

	// Use this for initialization
	void Start () {
		tileCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		float     speed           = 0.25f;
		Transform player          = GameObject.Find("Main Camera").GetComponent<Transform>();
		float     playerX         = player.position.x;
		float     playerZ         = player.position.z;
		float     xMin            = this.GetComponent<RectTransform>().rect.xMin;
		float     xMax            = this.GetComponent<RectTransform>().rect.xMax;
		float     xMed            = xMax - (xMax-xMin)/2;
		// for some reason yMin and yMax gets the z values, don't ask me
		float     zMin            = this.GetComponent<RectTransform>().rect.yMin;
		float     zMax            = this.GetComponent<RectTransform>().rect.yMax;
		float     zMed            = zMax - (zMax-zMin)/2;
		Vector3   playerDirection = (new Vector3(player.forward.x, 0, player.forward.z))*speed;
		transform.position = transform.position - playerDirection;

		if(xMin<=playerX&&playerX<=xMax&&zMin<=playerZ&&playerZ<=zMax){
			if (xMed <= playerX && playerX <= xMax && zMax >= playerZ && playerZ > zMed && tileCount<9) {
				// quadrant I
//				Instantiate (GameObject.Find ("GroundTilePrefab"),
//					transform.position + (new Vector3 (0, 0, 100)),
//					transform.rotation);
//				Instantiate (GameObject.Find ("GroundTilePrefab"),
//					transform.position + (new Vector3 (100, 0, 100)),
//					transform.rotation);
//				Instantiate (GameObject.Find ("GroundTilePrefab"),
//					transform.position + (new Vector3 (100, 0, 0)),
//					transform.rotation);
				tileCount += 3;
				print (tileCount);

			}else if(xMin <= playerX && playerX < xMed && zMax >= playerZ && playerZ >= zMed && tileCount<9){
				// quadrant II
//				Instantiate (GameObject.Find ("GroundTilePrefab"),
//					transform.position + (new Vector3 (0, 0, 100)),
//					transform.rotation);
//				Instantiate (GameObject.Find ("GroundTilePrefab"),
//					transform.position + (new Vector3 (-100, 0, 100)),
//					transform.rotation);
//				Instantiate (GameObject.Find ("GroundTilePrefab"),
//					transform.position + (new Vector3 (-100, 0, 0)),
//					transform.rotation);
				tileCount += 3;
				print (tileCount);

			}else if(xMin <= playerX && playerX <= xMed && zMed > playerZ && playerZ >= zMin && tileCount<9){
				// quadrant III
//				Instantiate (GameObject.Find ("GroundTilePrefab"),
//					transform.position + (new Vector3 (0, 0, -100)),
//					transform.rotation);
//				Instantiate (GameObject.Find ("GroundTilePrefab"),
//					transform.position + (new Vector3 (-100, 0, -100)),
//					transform.rotation);
//				Instantiate (GameObject.Find ("GroundTilePrefab"),
//					transform.position + (new Vector3 (-100, 0, 0)),
//					transform.rotation);
				tileCount += 3;
				print (tileCount);

			}else if(xMed < playerX && playerX <= xMax &&  zMed >= playerZ && playerZ >= zMin && tileCount<9){
				// quadrant IV
//				Instantiate (GameObject.Find ("GroundTilePrefab"),
//					transform.position + (new Vector3 (0, 0, -100)),
//					transform.rotation);
//				Instantiate (GameObject.Find ("GroundTilePrefab"),
//					transform.position + (new Vector3 (100, 0, -100)),
//					transform.rotation);
//				Instantiate (GameObject.Find ("GroundTilePrefab"),
//					transform.position + (new Vector3 (100, 0, 0)),
//					transform.rotation);
				tileCount += 3;
			}
		}
	}
}
