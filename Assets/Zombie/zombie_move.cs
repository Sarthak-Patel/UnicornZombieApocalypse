using UnityEngine;
using System.Collections;

public class zombie_move : MonoBehaviour {
	
	public Transform target;
	public float speed;
	public Camera m_Camera;


	// Use this for initialization
	void Start () {
		// spawn randomly
		const int HEIGHT = 2;
		int x = Random.Range(300,500);
		int z = Random.Range(300,500);

		transform.position = new Vector3(x,HEIGHT,z);


	}

	void Update() {		
		// move towards player
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);

		// face player
		transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,m_Camera.transform.rotation * Vector3.up);

	}
}
