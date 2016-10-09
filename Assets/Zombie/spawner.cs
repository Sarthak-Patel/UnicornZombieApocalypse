using UnityEngine;
using System.Collections;
using System;

public class spawner : MonoBehaviour {
	public Transform Zombie;
    public Transform Zombie2;
    public Transform Zombie3;
    public Transform Zombie4;
    private Transform[] Zombies = new Transform[4];
	private int x;
	private int z;

	const int SMOKE_RAD = 60;
	int WAIT_TIME = 3;
	float timeLeft = 180.0f;
	float HardSpeed = 5.0f;

	// Use this for initialization
	void Start () {
        Zombies.SetValue(Zombie, 0);
        Zombies.SetValue(Zombie2, 1);
        Zombies.SetValue(Zombie3, 2);
        Zombies.SetValue(Zombie4, 3);
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
            Zombie2.Translate(Vector3.forward * HardSpeed * Time.deltaTime);
            Zombie3.Translate(Vector3.forward * HardSpeed * Time.deltaTime);
            Zombie4.Translate(Vector3.forward * HardSpeed * Time.deltaTime);
        }
			

		// wait time in between each spawn wave
	}

    public void Spawn()
    {
        x = UnityEngine.Random.Range(-100, 100);
        z = UnityEngine.Random.Range(-100, 100);
        int a = UnityEngine.Random.Range(0, 3);
       Instantiate(Zombies[a], new Vector3(x, 2, z), Quaternion.identity);
    }
}
/**
while ((x > SMOKE_RAD || x < -(SMOKE_RAD)) && (z > SMOKE_RAD || z < -(SMOKE_RAD))) {
	x = Random.Range(-100,100);
	z = Random.Range(-100,100);			
}
**/