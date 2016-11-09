using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
  private GameObject controller;
	private ControllerScript controllerScript;


	// Use this for initialization
	void Start () {
		controller = GameObject.Find("Controller");
		controllerScript = controller.GetComponent<ControllerScript> ();


	}

	// Update is called once per frame
	void Update () {

	}
	void OnCollisionEnter(Collision coll){
		GameObject collidedWith = coll.gameObject;
		if (collidedWith.tag == "Bullet") {
				controllerScript.ChangeLife(-1);
			}
	}


}
