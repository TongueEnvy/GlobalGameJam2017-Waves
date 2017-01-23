using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAim : MonoBehaviour {
    public GameObject player;
    public GameObject playerShoulder;

    public float turnSpeedFactor;

    private float turnH;
    private float turnV;
    
    private Vector3 turnPlayer;
    private Vector3 turnShoulder;

    
	
    // Use this for initialization
    void Start() {
        //Lock mouse cursor
        Cursor.lockState = CursorLockMode.Locked;
		//identify player
        player = gameObject;
		//Identify player's shoulder (gun & camera's parent)
        playerShoulder = player.transform.Find("playerShoulder").gameObject;
    }
	
	// Update is called once per frame
	void Update () {
		//"Y" component of player aim
        turnH = (Input.GetAxisRaw("Mouse X") * turnSpeedFactor);
		//"X" component of player aim
        turnV = (Input.GetAxisRaw("Mouse Y") * (turnSpeedFactor * -1));
		//Final aim direction (Player)
        turnPlayer = new Vector3(0, turnH, 0);
        //Aim the player left and right
        transform.Rotate(turnPlayer);
        //Final aim direction (Gun)
        turnShoulder = new Vector3(turnV, 0, 0);
	}

    void FixedUpdate () {
		//Aim the gun up & down
        playerShoulder.transform.Rotate(turnShoulder);
    }
}
