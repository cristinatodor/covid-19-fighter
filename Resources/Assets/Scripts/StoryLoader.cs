using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StoryLoader : MonoBehaviour {
  
    public Animator transition;
    public GameObject continueButton;

    public float transitionTime = 5f;
    public float waitTime = 5f;

    void Start() {
        StartCoroutine(StartStory());
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.P)) {
            //LoadNextLevel();
            //StartStory();
        }
    }

    IEnumerator StartStory() {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        continueButton.SetActive(true);
    }

    public void LoadNextLevel() {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1)) ;
    }

    public void ReloadLevel() {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    IEnumerator LoadLevel(int levelIndex) {
        //transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
