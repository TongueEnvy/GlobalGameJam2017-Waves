using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseGame : MonoBehaviour {
    public bool paused;
	// Use this for initialization
	void Start () {
        paused = false;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Pause")) {
            Object[] objects = FindObjectsOfType(typeof(GameObject));
            if (!paused) {
                foreach (GameObject go in objects) {
                    go.SendMessage("OnPauseGame",SendMessageOptions.DontRequireReceiver);
                    paused = true;
                }
            }
            else if(paused) {
                foreach (GameObject go in objects) {
                    go.SendMessage("OnResumeGame", SendMessageOptions.DontRequireReceiver);
                    paused = false;
                }
            }
        }
	}
}
