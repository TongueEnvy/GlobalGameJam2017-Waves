using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour {
    public Rigidbody playerRigidBody;
    public float moveSpeedFactor;
    public float jumpForce;
    public Collider groundedCheck;
	
    private float speedH;
    private float speedV;
    private Vector3 playerVelocity;
    private float speedUP;
    private bool grounded;

    // Use this for initialization
    void Start () {
        //Identify player's rigidbody
        playerRigidBody = gameObject.GetComponent<Rigidbody>();
        //Player is on ground
        grounded = true;
        //Identify groundedCheck
        groundedCheck = gameObject.transform.Find("playerGroundedCheck").gameObject.GetComponent<Collider>();

    }

    void OnCollisionStay(Collision groundedCheck) {
        //Player is on ground
        grounded = true;
    }

    // Update is called once per frame
    void Update () {
        //"X" component of player movement
        speedH = (Input.GetAxisRaw("Horizontal") * moveSpeedFactor);
        //"Z" component of player movement
        speedV = (Input.GetAxisRaw("Vertical") * moveSpeedFactor);
        //Final walk direction
        playerVelocity = new Vector3(speedH, 0, speedV);
        //"Y" component of player movement(for jumping)
        if((grounded == true) && (Input.GetButtonDown("Jump"))) {
            speedUP = jumpForce;
            //Make the player jump
            playerRigidBody.AddRelativeForce(0, speedUP, 0, ForceMode.Impulse);
            grounded = false;
        }
    }
    void FixedUpdate() {
        //Make the player walk
        playerRigidBody.AddRelativeForce(playerVelocity, ForceMode.Impulse);
    }
}
