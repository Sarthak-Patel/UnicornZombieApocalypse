using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class DestroyCollision : MonoBehaviour {
    public Text countText;
    public Text countText2;
    private int count;
    public AudioClip nay;
    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = nay;
        count = 0;
        countText.text = "Count: " + count.ToString();
        countText2.text = "Final Score: " + count.ToString();
        DontDestroyOnLoad(countText2);
        DontDestroyOnLoad(countText);
    }
	void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Zombie(Clone)" || col.gameObject.name == "Zombie2(Clone)" || col.gameObject.name == "Zombie3(Clone)" || col.gameObject.name == "Zombie4(Clone)" || col.gameObject.name == "Zombie" || col.gameObject.name == "Zombie2" || col.gameObject.name == "Zombie3" || col.gameObject.name == "Zombie4")
        {
            Destroy(col.gameObject);
            count = count + 1;
            countText.text = "Count: " + count.ToString ();
            countText2.text = "Final Score: " + count.ToString();
            GetComponent<AudioSource>().Play();
            DontDestroyOnLoad(countText);
            DontDestroyOnLoad(countText2);
        }
    }


    public void resetCount()
    {
        count = 0;
        countText.text = "Count: " + count.ToString();
        countText2.text = "Final Score: " + count.ToString();
    }
}
