using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item : MonoBehaviour {

    public Texture icon;

    public string type;
    public float decreaseRate;

    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale; 
    
    public bool pickedUp; 
    public bool equipped;  

    private GameObject player;
    private GameObject miscWindow;

    public string message;

    public void Awake() {
        miscWindow = GameObject.FindWithTag("MiscWindow");
    }

    public void Start() {
        player = PlayerManager.instance.player;
    }

    public void Update() {
        if (equipped) {
            player.GetComponent<Player>().weaponEquipped = true;
        }
        else {
            player.GetComponent<Player>().weaponEquipped = false;
        }

        if (equipped) {
            if (Input.GetKeyDown(KeyCode.F)) {
                Unequip();
            }
        }

        if (Input.GetKeyDown(KeyCode.M)) {
            UpdateText();
        }
    }

    public void Unequip() {
        equipped = false;
        this.gameObject.SetActive(false);
    }

    /*public void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
               
        }
    }*/

    public void UpdateText() {
        print(message);
        miscWindow.GetComponent<MiscWindow>().UpdateText(message);
        
        //miscWindow.UpdateText();
    }
}
    
