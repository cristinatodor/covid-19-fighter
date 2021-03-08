using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour {

    public GameObject completeCanvas;
    public Animator transition;

    public GameObject lockdownWindow;

    //public bool lockdown = false;
    public Timer timer;

    void Start() {
        timer = FindObjectOfType<Timer>();
    }

    void Update() {
        if (timer.lockdownIsRunning) {
            //lockdown = true;
            print("Lockdown");
        }
    }

    public void OnTriggerEnter(Collider other) {
        if (!timer.lockdownIsRunning) {
            if (other.tag == "Player") {
                print("Colliding");

                StartCoroutine(Complete());   
            }
        }
        else {
            print("Lockdown! Need to survive");
            lockdownWindow.SetActive(true);
            Invoke("CloseWindow", 10);
        }
    }

    IEnumerator Complete() {
        // animation 
        //completeCanvas.SetActive(true);
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(10f);
        

        FindObjectOfType<LevelLoader>().LoadNextLevel();
    }

    public void CloseWindow() {
        lockdownWindow.SetActive(false);
    }
}
