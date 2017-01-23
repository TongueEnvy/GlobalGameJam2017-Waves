using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnWaves : MonoBehaviour {
	public float timeBetweenSpawns =	5f;
	public GameObject enemy;
	public GameObject player;

	private float timer = 				0f;
	private int mobsSpawned =			0;
	private int wave =					0;
//	private float randomPosition;
	private Vector3 spawnLocation;

	// Use this for initialization
	void Start () {
		Random.InitState(42);
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		
		if(timer >= timeBetweenSpawns) {
			pickSpawn();
			Spawn();
		}
	}
	
	void pickSpawn() {
		switch((int)(Mathf.Floor(Random.Range(0f, 4f)))) {
			case 0:
				spawnLocation.Set(-32f, 1f, -32f);
				break;
			case 1:
				spawnLocation.Set(32f, 1f, -42f);
				break;
			case 2:
				spawnLocation.Set(-40f, 1f, 40f);
				break;
  			case 3:
				spawnLocation.Set(30f, 1f, 40f);
				break;
			case 4:
				spawnLocation.Set(0f, 1f, -5f);
				break;
		}
	}
	
	void Spawn() {
		timer = 0f;
		
		//GameObject newBullet = bullet.instantiate;
		Instantiate(enemy, spawnLocation, transform.rotation);
		mobsSpawned++;
		//Grunt currentMonster = enemy.GetComponent <Grunt> ();
		//if(currentMonster != null) {
			//Debug.Log("BulletMechanics issued a TakeDamage command!");
			//enemyHealth.TakeDamage(damagePerShot);
		//	currentMonster.SetPlayer(player);
		//}
	}
}
