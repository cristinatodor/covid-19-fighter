using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MessageWindow : MonoBehaviour {

    public GameObject miscWindow;
    public TextMeshProUGUI windowTitle;
    public Text windowText;
    private bool isActive = false;

    public string messageTitle;
    public string messageText;

    public GameObject player;

    void Start() {
        Debug.Log(this.tag);

        player = PlayerManager.instance.player;
    }
    
    void Update() {
        /*if (Input.GetKeyDown(KeyCode.M)) {
            OpenMessageWindow();
        }*/
    }

    public void OpenMessageWindow() {
        miscWindow.SetActive(true);

        windowTitle.text = messageTitle;
        windowText.text = messageText;

        Invoke("CloseMessageWindow", 5.0f);
    }

    public void CloseMessageWindow() {
        miscWindow.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) {
        
        if (this.tag == "QuestItem") {
            bool activeQuest = false;

            foreach (Quest quest in player.GetComponent<Player>().questList) {
                if (quest.isActive && quest.goal.type == this.GetComponent<Item>().type) {
                    activeQuest = true;
                }
            }

            if (activeQuest && other.tag == "Player") {
                OpenMessageWindow();
            }
        }

        else {
            if (other.tag == "Player") {
                OpenMessageWindow();
            }   
        }     
    }
}

