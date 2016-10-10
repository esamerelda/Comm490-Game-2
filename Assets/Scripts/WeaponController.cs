using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {

	//weapon can't be used while paused
	private GameObject metaGame;
	private Pauser pauserScript;
	
	[HideInInspector]
	public bool armed;		//InterfaceScript depends on whether or not you are armed
	[HideInInspector]

	//testing...
	//float cannonBallSpeed = 4500.0f;
	float cannonBallSpeed = 1000.0f;


	public Rigidbody cannonBallPrefab;
	

	void Awake () 
	{
		//player = GameObject.FindGameObjectWithTag("Player");

		metaGame = GameObject.Find ("MetaGame");
		pauserScript = metaGame.GetComponent<Pauser>();
		//pauserScript = GetComponent<Pauser>();
	}

	void Start () 
	{
		armed = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!pauserScript.worldPaused)
		{
			if (Input.GetButtonDown("ArmedSheathed")){
				armed = !armed;
			}
			//If player presses LEFT CTRL button, instantiate cannonball prefab.
			if ((armed) && (Input.GetButtonDown("Fire1")))
			{
				//Rigidbody cannonBallInstance = Instantiate(cannonBallPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody;
				Rigidbody cannonBallInstance = Instantiate(cannonBallPrefab, transform.position, transform.rotation) as Rigidbody;

				//Physics.IgnoreCollision(cannonBallInstance.GetComponent<Collider>(), player.GetComponent<Collider>());

				//make cannonBallInstance move (Make cannonBallSpeed around 140)
				//cannonBallInstance.velocity = transform.TransformDirection(new Vector3(0, 0, cannonBallSpeed));

				//one source said to use the following code to launch the ball instead of the above, 
				//but it did not work properly, only if you crank the cannonBallSpeed @ 1400+.
	    		cannonBallInstance.AddForce(cannonBallInstance.transform.forward * cannonBallSpeed);
			}
		}
	}
}
