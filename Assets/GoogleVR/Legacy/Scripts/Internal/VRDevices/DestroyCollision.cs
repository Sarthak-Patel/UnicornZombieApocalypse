using UnityEngine;
using System.Collections;

public class DestroyCollision : MonoBehaviour {

	void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Zombie")
        {
            Destroy(col.gameObject);
        }
    }
}
