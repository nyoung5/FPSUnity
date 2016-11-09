//Copyright Nathan Young & Alex Zaterka 2016
//@author azaterka
//@author nyoung
//@author sduvall

using UnityEngine;
using System.Collections;

/*
 * Adapter class for player shooting
 */
public class RayShooter : MonoBehaviour {

  [SerializeField] public GameObject bulletPrefab;
	[SerializeField] public GameObject gunPrefab;
	private PewPewScript gunScript;

	private Camera camera;

	void Start () {
		camera = GetComponent<Camera> ();
		Cursor.lockState = CursorLockMode.Locked;
		gunScript = gunPrefab.GetComponent<PewPewScript> ();
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			gunScript.Shoot();
			}
		}
}
