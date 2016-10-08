using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour {
	public Transform Zombie;
	public float fieldOfView;
	private int x;
	private int z;
	const int SMOKE_RAD = 60;
	const int WAIT_TIME = 2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		for (int i = 0; i < 4; i++) {
			x = Random.Range(-100,100);
			z = Random.Range(-100,100);
			Instantiate(Zombie, new Vector3(x,2,100), Quaternion.identity);
		}

		// wait time in between each spawn wave
		new WaitForSeconds(WAIT_TIME);
	}
}
/**
while ((x > SMOKE_RAD || x < -(SMOKE_RAD)) && (z > SMOKE_RAD || z < -(SMOKE_RAD))) {
	x = Random.Range(-100,100);
	z = Random.Range(-100,100);			
}
**/