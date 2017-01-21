using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFiring : MonoBehaviour {
	public int damagePerShot =			20;           // The damage inflicted by each bullet.
	public float timeBetweenBullets =	0.15f;        // The time between each shot.
	public float range =				100f;         // The distance the gun can fire.

	private float timer;                              // A timer to determine when to fire.
	private int shootableMask;                        // A layer mask so the raycast only hits things on the shootable layer.
	private Ray shootRay;                             // A ray from the gun end forwards.
    private RaycastHit shootHit;                      // A raycast hit to get information about what was hit.

	
	// Use this for initialization
	void Awake() {
        // Create a layer mask for the Shootable layer.
        shootableMask = LayerMask.GetMask ("Shootable");
    }
	
	// Update is called once per frame
	void Update() {
		// Add the time since Update was last called to the timer.
        timer += Time.deltaTime;

        // If the Fire1 button is being press and it's time to fire...
        if((Input.GetButton("Fire1")) && (timer >= timeBetweenBullets)) {
            // ... shoot the gun.
            Shoot();
        }
	}
	
	void Shoot() {
        // Reset the timer.
        timer = 0f;

        // Set the shootRay so that it starts at the end of the gun and points forward from the barrel.
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        // Perform the raycast against gameobjects on the shootable layer and if it hits something...
        if(Physics.Raycast(shootRay, out shootHit, range, shootableMask)) {
            // Try and find an EnemyHealth script on the gameobject hit.
            EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();

            // If the EnemyHealth component exist...
            if(enemyHealth != null) {
                // ... the enemy should take damage.
                enemyHealth.TakeDamage (damagePerShot, shootHit.point);
            }

            // Set the second position of the line renderer to the point the raycast hit.
            //gunLine.SetPosition (1, shootHit.point);
        }
        // If the raycast didn't hit anything on the shootable layer...
        //else {
            // ... set the second position of the line renderer to the fullest extent of the gun's range.
            //gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
        //}
    }
}