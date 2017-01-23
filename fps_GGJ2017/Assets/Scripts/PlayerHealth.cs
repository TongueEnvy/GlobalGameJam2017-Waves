using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public int maxHealth = 100;
	
	private int currentHealth;

	// Use this for initialization
	void Awake() {
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update() {
		if(currentHealth <= 0) {
			Destroy(gameObject);
		}
	}
	
	public void TakeDamage(int damage) {
		currentHealth = currentHealth - damage;
	}
}
