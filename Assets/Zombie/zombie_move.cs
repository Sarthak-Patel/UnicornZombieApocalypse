using UnityEngine;
using System.Collections;

public class zombie_move : MonoBehaviour {
	
	public Transform target;
	public float speed;
	public Camera m_Camera;



	// Use this for initialization
	void Start () {
<<<<<<< HEAD
		// spawn randomly
		const int HEIGHT = 2;
=======
		const int HEIGHT = 3;
>>>>>>> 7fa5d37d6457c5a8c3cce3cae6a083a8bbae119a
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
