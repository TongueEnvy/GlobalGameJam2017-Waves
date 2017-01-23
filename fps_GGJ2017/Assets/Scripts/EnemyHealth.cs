using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    public int startingHealth =		100;        // The amount of health the enemy starts the game with.
//    public float sinkSpeed =		2.5f;       // The speed at which the enemy sinks through the floor when dead.
//    public int scoreValue =			10;         // The amount added to the player's score when the enemy dies.
//    public AudioClip deathClip;                 // The sound to play when the enemy dies.

    private int currentHealth;                   // The current health the enemy has.
//	private Animator anim;                      // Reference to the animator.
//    private AudioSource enemyAudio;             // Reference to the audio source.
//    private ParticleSystem hitParticles;        // Reference to the particle system that plays when the enemy is damaged.
//    private CapsuleCollider capsuleCollider;    // Reference to the capsule collider.
    private bool isDead;                        // Whether the enemy is dead.
//    private bool isSinking;                     // Whether the enemy has started sinking through the floor.


    void Awake() {
        // Setting the current health when the enemy first spawns.
        currentHealth = startingHealth;
    }

    //void Update() {
        // If the enemy should be sinking...
        //if(isSinking) {
            // ... move the enemy down by the sinkSpeed per second.
        //    transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
        //}
    //}


    public void TakeDamage (int amount, Vector3 hitPoint)
    {
        // If the enemy is dead...
        if(isDead) {
            // ... no need to take damage so exit the function.
            return;
		}

        // Reduce the current health by the amount of damage sustained.
        currentHealth -= amount;
            
        // If the current health is less than or equal to zero...
        if(currentHealth <= 0) {
            // ... the enemy is dead.
			isDead = true;
			Destroy(gameObject);
        }
    }


    //void Death() {
        // The enemy is dead.
        //isDead = true;

        // Turn the collider into a trigger so shots can pass through it.
        //capsuleCollider.isTrigger = true;
    //}

    //public void StartSinking() {
        // Increase the score by the enemy's score value.
        //ScoreManager.score += scoreValue;

        // After 2 seconds destory the enemy.
        //Destroy(gameObject);
    //}
}