using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MiscWindow : MonoBehaviour {

    //public TextMeshProUGUI windowText;
    public Text windowText;

    public void Awake() {
        UpdateText("Watch out for the virus!");
    }

    public void UpdateText(string message) {
        windowText.text = message;
        
    }
}
