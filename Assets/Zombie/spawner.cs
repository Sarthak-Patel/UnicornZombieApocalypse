using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour {
	public Transform Zombie;
	public float fieldOfView;
	private int x;
	private int z;
	const int SMOKE_RAD = 60;
	const int WAIT_TIME = 2;
    int j = 0;
	// Use this for initialization
	void Start () {
       InvokeRepeating("Spawn", WAIT_TIME, WAIT_TIME);
	}
	
	// Update is called once per frame
	void Update () {

		

		// wait time in between each spawn wave
	}

    public void Spawn()
    {
        x = Random.Range(-100, 100);
        z = Random.Range(-100, 100);
       Instantiate(Zombie, new Vector3(x, 2, z), Quaternion.identity);
    }
}
/**
while ((x > SMOKE_RAD || x < -(SMOKE_RAD)) && (z > SMOKE_RAD || z < -(SMOKE_RAD))) {
	x = Random.Range(-100,100);
	z = Random.Range(-100,100);			
}
**/