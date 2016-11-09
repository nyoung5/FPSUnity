//Copyright Nathan Young & Alex Zaterka 2016
//@author azaterka
//@author nyoung

using UnityEngine;
using System.Collections;

/*
 * Child of Target, gives targets guns and points them at player
 */
public class EnemyScript : TargetScript {

	private Transform target;
	[SerializeField] public GameObject bulletPrefab;
	[SerializeField] public GameObject gunPrefab;
	private PewPewScript gunScript;


	//Calls start method of parent because this start method overwrites the old one. This may be what is causing the unity error/flag in console.
	 void Start () {
	    base.Start ();
		target = GameObject.Find ("Player").transform;
		gunScript = gunPrefab.GetComponent<PewPewScript> ();
		InvokeRepeating ("ShootThing", Random.Range(0f,1.5f), Random.Range(.5f,1.5f));
 	}

	 void Update () {
		if (!isDying) {
			transform.LookAt (target);
		}
 	 }

	//shoots gun and checks to see if there is a wall between the player and Enemy. If there is not, then it fires its weapon.
	void ShootThing(){
		//based on code from http://answers.unity3d.com/questions/547018/raycast-target-line-of-sight.html
		RaycastHit hit;
		if ((Physics.Raycast (this.transform.position, target.transform.position - this.transform.position, out hit) && hit.transform.tag == "Player") && !isDying) {
			gunScript.Shoot ();
		}
	}

}
