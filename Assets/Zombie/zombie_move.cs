using UnityEngine;
using System.Collections;

public class zombie_move : MonoBehaviour {
	
	public Transform target;
	public float speed;


	void Update() {		
		// emulates player moving past zombie
		Vector3 direction = speed*(target.forward+target.right);
		transform.position = transform.position - direction;

		// face player
		Vector3 targetPostition = new Vector3( target.position.x, 
                                        this.transform.position.y, 
                                        target.position.z ) ;
 		this.transform.LookAt( targetPostition ) ;

	}
}
