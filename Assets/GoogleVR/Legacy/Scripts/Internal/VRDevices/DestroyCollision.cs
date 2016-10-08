using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DestroyCollision : MonoBehaviour {
    public Text countText;
    private int count;

    void Start()
    {
        count = 0;
        countText.text = "Count: " + count.ToString();
    }
	void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Zombie")
        {
            Destroy(col.gameObject);
            count = count + 1;
            countText.text = "Count: " + count.ToString ();
        }
    }
}
