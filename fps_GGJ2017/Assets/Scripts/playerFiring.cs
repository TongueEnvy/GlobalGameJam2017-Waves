using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFiring : MonoBehaviour {
    private bool paused;

	public int damagePerShot =			20;           // The damage inflicted by each bullet.
	public float timeBetweenBullets =	0.15f;        // The time between each shot.
	public float range =				100f;         // The distance the gun can fire.

    public float gunSpread;
    private float gunSpreadX;
    private float gunSpreadY;
    private Vector3 shotDirMod;

    private AudioSource speaker;

	private float timer;                              // A timer to determine when to fire.
	private int shootableMask;                        // A layer mask so the raycast only hits things on the shootable layer.
	private Ray shootRay;                             // A ray from the gun end forwards.
    private RaycastHit shootHit;                      // A raycast hit to get information about what was hit.
	private LineRenderer gunLine;                     // Reference to the line renderer.
	private float effectsDisplayTime = 0.2f;          // The proportion of the timeBetweenBullets that the effects will display for.

	// Use this for initialization
	void Awake() {
        paused = false;

        // Create a layer mask for the Shootable layer.
        shootableMask = LayerMask.GetMask ("Shootable");
		
		// Set up the references.
		gunLine = GetComponent <LineRenderer> ();

        //Identify audio source
        speaker = GameObject.Find("Player/playerShoulder/smg000(16,4,16)").GetComponent<AudioSource>();
    }

    void OnPauseGame(){
        paused = true;
    }

    void OnResumeGame() {
        paused = false;
    }
	
	// Update is called once per frame
	void Update() {
        if (!paused)
        {
            // Add the time since Update was last called to the timer.
            timer += Time.deltaTime;

            // If the Fire1 button is being press and it's time to fire...
            if ((Input.GetButton("Fire1") || (Input.GetAxis("Fire1") == 1)) && (timer >= timeBetweenBullets))
            {
                // ... shoot the gun.
                gunSpreadX = Random.Range(-gunSpread, gunSpread);
                gunSpreadY = Random.Range(-gunSpread, gunSpread);
                shotDirMod = new Vector3(gunSpreadX, gunSpreadY, 0);
                Shoot();
            }

            if (timer >= timeBetweenBullets * effectsDisplayTime)
            {
                // ... disable the effects.
                DisableEffects();
            }
        }
	}
	
	public void DisableEffects() {
        // Disable the line renderer and the light.
        gunLine.enabled = false;
        //gunLight.enabled = false;
    }

    void Shoot()
    {
        if (!paused)
        {
            // Reset the timer.
            timer = 0f;

            //Gun Recoil

            // Enable the line renderer and set it's first position to be the end of the gun.
            gunLine.enabled = true;
            gunLine.SetPosition(0, transform.position);

            // Set the shootRay so that it starts at the end of the gun and points forward from the barrel.
            shootRay.origin = transform.position;
            shootRay.direction = (transform.forward) + shotDirMod;
            speaker.Play();

            // Perform the raycast against gameobjects on the shootable layer and if it hits something...
            if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
            {
                // Try and find an EnemyHealth script on the gameobject hit.
                EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();

                // If the EnemyHealth component exist...
                if (enemyHealth != null)
                {
                    // ... the enemy should take damage.
                    enemyHealth.TakeDamage(damagePerShot, shootHit.point);
                }

                // Set the second position of the line renderer to the point the raycast hit.
                gunLine.SetPosition(1, shootHit.point);
            }
            // If the raycast didn't hit anything on the shootable layer...
            else
            {
                // ... set the second position of the line renderer to the fullest extent of the gun's range.
                gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
            }
        }
    }
    }