using UnityEngine;
using System.Collections;

public class zombie_move : MonoBehaviour {
	
	public Transform target;
	public float speed;

	// Use this for initialization
	void Start () {
		const int HEIGHT = 3;
		int x = Random.Range(200,400);
		int z = Random.Range(200,400);

		transform.position = new Vector3(x,HEIGHT,z);
	}

	void Update() {
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);
	}
}
