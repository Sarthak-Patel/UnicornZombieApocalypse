using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerCollision : MonoBehaviour {
    public AudioClip death;
    public GameObject Object1;
    public GameObject Object2;

    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = death;
    }
	void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == "Hitbox")
        {
            Destroy(col.gameObject);
            GetComponent<AudioSource>().Play();
            Object1.SetActive(false);
            Object2.SetActive(true);
        }
    }
}
