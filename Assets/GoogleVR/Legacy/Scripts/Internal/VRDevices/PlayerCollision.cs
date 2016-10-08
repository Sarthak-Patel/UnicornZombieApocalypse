using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerCollision : MonoBehaviour {
    public AudioClip death;

    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = death;
        
    }
	void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == "PlayerHitbox")
        {
            Destroy(col.gameObject);
            GetComponent<AudioSource>().Play();
        }
    }
}
