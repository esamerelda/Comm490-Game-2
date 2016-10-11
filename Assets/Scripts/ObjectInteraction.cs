using UnityEngine;
using System.Collections;

public class ObjectInteraction : MonoBehaviour {


	private bool armed;
	private bool canPickUp;
	private bool holdingE;

	private Camera cam;

	private float throwSpeed = 1000.0f;

	private GameObject hand;
	private GameObject weapon;

	private Rigidbody weaponRb;

	void Awake()
	{
		cam = GameObject.Find("Main Camera").GetComponent<Camera>();
		hand = GameObject.Find("Invisible Hand");
	}

	// Use this for initialization
	void Start () {
		armed = false;
		canPickUp = false;
	
	}
	
	void Update () {
		//if player has an item in hand...
		if (armed){
			//and holds E then clicks the mouse button...

			if ((Input.GetKey(KeyCode.E)) && (Input.GetMouseButtonDown(0)))
			//if (Input.GetKey(KeyCode.E))
			//if (Input.GetMouseButtonDown(0))
			{
				Debug.Log("You have thrown your weapon");

				//...set to not kinematic
				weaponRb.isKinematic = false;

				//...send item flying
				weaponRb.AddForce(cam.transform.forward * throwSpeed);
				//...remove parent
				weapon.transform.parent = null;
				//...nullify weapon and weaponRb
				weapon = null;
				weaponRb = null;

				//...set armed to false
				armed = false;
			}
			//if e + click{
			//throw item	
		}
		
		
		if (canPickUp)
		{
			Debug.Log("Click to pick this up");
			if (Input.GetMouseButtonDown(0))
			{
				//make object child of hand
				weapon.transform.parent = hand.transform;
				//reset rotation of object

				//set item to kinematic to prevent from flying around
				weaponRb = weapon.GetComponent<Rigidbody>();
				weaponRb.isKinematic = true;
				armed = true;
				canPickUp = false;
				Debug.Log("Picked up item!");
			}
		}
		else
		{
			Debug.Log("Can't pick up anything");
		}
	
	}

	//collision detection
	void OnTriggerEnter(Collider other)
	{
		if ((!armed) && (other.tag == "Item")) {
			canPickUp = true;
			weapon = other.gameObject;
			//display "Pick up item" notification
			//if left click
			//attach item to hand
			//armed = true
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.tag == "Item")
		{
			Debug.Log("Can't pick up anything");
			canPickUp = false;
		}
		//close info ui
	}
	
}
