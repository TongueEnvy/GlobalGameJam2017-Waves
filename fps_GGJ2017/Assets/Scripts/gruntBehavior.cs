using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gruntBehavior : MonoBehaviour {
	public float speed = 2.5f;
	public int damagePerHit = 20;
	public GameObject player;
	
	private Rigidbody rb3d;
	private Vector3 movement;
	
	// Use this for initialization
	void Awake () {
		rb3d = GetComponent <Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float h = (float)(player.transform.position.x - rb3d.position.x);
		float v = (float)(player.transform.position.z - rb3d.position.z);
		Move(h, v);		
	}
	
	void Move (float h, float v) {
		movement.Set(h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;
		rb3d.MovePosition(rb3d.position + movement);
	}
	
	void OnCollisionEnter(Collision other) {
		//Debug.Log("I'm working!");
		GameObject something = other.gameObject;
		PlayerHealth playerHealth = something.GetComponent <PlayerHealth> ();
		if(playerHealth != null) {
			//Debug.Log("BulletMechanics issued a TakeDamage command!");
			playerHealth.TakeDamage(damagePerHit);
		}
	}
	
	public void SetPlayer(GameObject currentPlayer) {
		player = currentPlayer;
	}
}
