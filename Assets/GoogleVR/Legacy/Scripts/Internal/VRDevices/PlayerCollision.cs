using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerCollision : MonoBehaviour {
    public AudioClip death;
    public GameObject Object1;
    public GameObject Spawner;
    public GameObject Zombie;

    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = death;

    }
	void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == "Hitbox")
        {
            GetComponent<AudioSource>().Play();
            Object1.transform.position = new Vector3(-39, 4, 110);
            Spawner.SetActive(false);
            Zombie.SetActive(false);
        }
    }
}
