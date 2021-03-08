using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputUI : MonoBehaviour {

    public GameObject cube;
    public Text inputText;
    public int code;

    private GameObject miscWindow;

    void Start() {
        miscWindow = GameObject.FindWithTag("MiscWindow");
    }
    
    public void DestroyCube() {
        Destroy(cube);
        print("Cube destroyed");
    
    }

    public void CheckInput() {
       int inputCode = int.Parse(inputText.text);

       if (inputCode == code) {
           //this.GetComponent<MessageWindow>().OpenMessageWindow();
           miscWindow.GetComponent<MiscWindow>().UpdateText("Input code was correct!");

           Invoke("DestroyCube", 6.0f);
       }

       else {
           miscWindow.GetComponent<MiscWindow>().UpdateText("Wrong code");
       }
    }
}
