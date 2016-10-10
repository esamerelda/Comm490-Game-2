using UnityEngine;
using System.Collections;

public class Pauser : MonoBehaviour {

	//this script handles pausing, time, and cursor specifics

	//references to menu script, if player is viewing menu, game should be paused
	//private InterfaceScript interfaceScript;

	[HideInInspector]
	public bool worldPaused = false;
	public bool pauseButtonDown = false;
	[HideInInspector]

	// Use this for initialization

	void Awake(){
		//interfaceScript = GetComponent<InterfaceScript>();
	}

	
	void Start () {

		Time.timeScale = 1;
		worldPaused = false;
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Pause"))
		{
			pauseButtonDown = !pauseButtonDown;
		}

		if (worldPaused == true){
			Time.timeScale = 0;
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
		else{
			Time.timeScale = 1;
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		}

		//Debug.Log ("worldPaused = " + worldPaused + " & menuScript.playerViewingMenu = " + menuScript.playerViewingMenu);
	
	}

	public void pauseGame(){
		worldPaused = true;
	}
	public void unPauseGame(){
		worldPaused = false;
	}
}
