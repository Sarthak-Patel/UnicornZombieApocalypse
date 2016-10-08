using UnityEngine;
using UnityEngine.UI;
using System.Collections;


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
        countText2.text = "Count: " + count.ToString();
    }
	void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Zombie")
        {
            Destroy(col.gameObject);
            count = count + 1;
            countText.text = "Count: " + count.ToString ();
            countText2.text = "Count: " + count.ToString();
            GetComponent<AudioSource>().Play();
        }
    }

    public void resetCount()
    {
        count = 0;
        countText.text = "Count: " + count.ToString();
        countText2.text = "Count: " + count.ToString();
    }
}
