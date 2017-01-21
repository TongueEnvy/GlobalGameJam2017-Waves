﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour {
    public float moveSpeedFactor;

    private float speedH;

    private float speedV;

    public float speedUP;

    public float turnSpeedFactor;

    private float turnH;

    private float turnV;

    private Vector3 playerVelocity;

    private Vector3 turnPlayer;

    private Vector3 turnShoulder;

    public float jumpForce;

    public Collider groundedCheck;

    private bool grounded;

    public Rigidbody playerRigidBody;

    public GameObject player;

    public GameObject playerShoulder;

    // Use this for initialization
    void Start () {
        //Identify player's rigidbody
        playerRigidBody = gameObject.GetComponent<Rigidbody>();
        //identify player
        player = gameObject;
        //Identify player's shoulder (gun & camera's parent)
        playerShoulder = player.transform.Find("playerShoulder").gameObject;
        //Player is on ground
        grounded = true;
        //Identify groundedCheck
        groundedCheck = player.transform.Find("playerGroundedCheck").gameObject.GetComponent<Collider>();
    }

    void OnCollisionStay(Collision groundedCheck) {
        grounded = true;
    }

        // Update is called once per frame
        void Update () {
        //"X" component of player movement
        speedH = (Input.GetAxisRaw("Horizontal") * moveSpeedFactor);
        //"Z" component of player movement
        speedV = (Input.GetAxisRaw("Vertical") * moveSpeedFactor);
        //"Y" component of player movement (for jumping)
        if ((grounded == true) && (Input.GetButtonDown("Jump"))){
            speedUP = jumpForce;
            grounded = false;
        }
        else {
            speedUP = 0;
            grounded = false;
        }
        //"Y" component of player aim
        turnH = (Input.GetAxisRaw("Mouse X") * turnSpeedFactor);
        //"X" component of player aim
        turnV = (Input.GetAxisRaw("Mouse Y") * (turnSpeedFactor * -1));

        //Final walk direction
        playerVelocity = new Vector3(speedH, 0, speedV);
        //Final aim direction (Player)
        turnPlayer = new Vector3(0,turnH,0);
        //Final aim direction (Gun)
        turnShoulder = new Vector3(turnV,0,0);
        //Lock Mouse Cursor
        Cursor.lockState = CursorLockMode.Locked;
        //Make the player jump
        playerRigidBody.AddForce(0, speedUP, 0, ForceMode.Impulse);
    }

    void FixedUpdate () {
        //Make the player walk
        playerRigidBody.AddRelativeForce(playerVelocity,ForceMode.Impulse);
        //Aim the player left and right
        transform.Rotate(turnPlayer);
        //Aim the gun up & down
        playerShoulder.transform.Rotate(turnShoulder);
    }
}
