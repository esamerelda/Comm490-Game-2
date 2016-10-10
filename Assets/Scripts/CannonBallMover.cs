using UnityEngine;
using System.Collections;

public class CannonBallMover : MonoBehaviour {

	// Use this for initialization
	

	void Awake () {
	

	}
	void Start () {
		//Destroy cannonball if it doesn't hit anything after 5 seconds
		Destroy(gameObject, 10);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	
	
	}
}
