using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour {
	public Transform Zombie;
	private int x;
	private int z;

	const int SMOKE_RAD = 60;
	int WAIT_TIME = 3;
	float timeLeft = 180.0f;
	float HardSpeed = 5.0f;

	// Use this for initialization
	void Start () {
       InvokeRepeating("Spawn", WAIT_TIME, WAIT_TIME);
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;

		if (timeLeft <= 120)
			WAIT_TIME = 4;
		if (timeLeft <= 60) {
			WAIT_TIME = 2;
			Zombie.Translate(Vector3.forward * HardSpeed * Time.deltaTime);
		}
			

		// wait time in between each spawn wave
	}

    public void Spawn()
    {
        x = Random.Range(-100, 100);
        z = Random.Range(-100, 100);
       Instantiate(Zombie, new Vector3(x, 3, z), Quaternion.identity);
    }
}
/**
while ((x > SMOKE_RAD || x < -(SMOKE_RAD)) && (z > SMOKE_RAD || z < -(SMOKE_RAD))) {
	x = Random.Range(-100,100);
	z = Random.Range(-100,100);			
}
**/