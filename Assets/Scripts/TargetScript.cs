//Copyright Nathan Young & Alex Zaterka 2016
//@author azaterka
//@author nyoung

using UnityEngine;
using System.Collections;

/*
 * Script for all targets, checks for collisions and if they are knocked out into space. Also calls updatescore method in controller
 */
public class TargetScript : MonoBehaviour {

	protected GameObject controller;
	protected ControllerScript controllerScript;
  	private const int SCOREINCREMENT = 100;
	protected bool isDying = false;
	private Vector3 bounds = new Vector3(150,30,150);

	// Use this for initialization
	public void Start () {
			controller = GameObject.Find("Controller");
			controllerScript = controller.GetComponent<ControllerScript> ();
	}
		
	void Update () {
		//if a target gets knocked out into space
		Vector3 pos = transform.position;
		if (Mathf.Abs (pos.x) > bounds.x || Mathf.Abs (pos.y) > bounds.y || Mathf.Abs (pos.z) > bounds.z) {
			controllerScript.ChangeScore (SCOREINCREMENT);
			Destroy (this.gameObject);
		}

	}
		
	//isDying exists so that you can only get credit for shooting targets once
	void OnCollisionEnter(Collision coll){
		GameObject collidedWith = coll.gameObject;
		if (collidedWith.tag == "Bullet" && !isDying) {
				Destroy (this.gameObject, 1f);
				controllerScript.ChangeScore(SCOREINCREMENT);
				isDying = true;
			}
	}
}
