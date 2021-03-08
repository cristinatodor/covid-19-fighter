using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndTextLoader : MonoBehaviour {
    public Animator transition;
    public Animator titleTransition;
    //public GameObject continueButton;

    public float transitionTime = 15f;
    public float waitTime = 5f;

    void Start() {
        //StartCoroutine(StartStory());
        transition.SetTrigger("Start");
        StartCoroutine(StartTitle());
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.P)) {
            //LoadNextLevel();
            //StartTitle();
        }
    }

    IEnumerator StartTitle() {        
        yield return new WaitForSeconds(transitionTime);
        titleTransition.SetTrigger("Start");
    }

    /*IEnumerator StartStory() {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        //continueButton.SetActive(true);
    }*/
    

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

    public void QuitGame() {
       Debug.Log("Quit!");
       Application.Quit();
   }

   public void LoadMenu() {
       SceneManager.LoadScene("Scenes/Menu");
   }
}
