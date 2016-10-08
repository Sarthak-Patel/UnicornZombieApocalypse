using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ResetListener : MagnetSensor {

	// Use this for initialization
	void Start () {
	
	}

	void OnCardboardTrigger(){
		SceneManager.LoadScene("Scene_Name");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
