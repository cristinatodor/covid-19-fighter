using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGenerator : MonoBehaviour {

    public Quest quest;

    //public Player player;

    //public GameObject questGenerator;

    public QuestGiver questGiver;

    public GameObject activeQuestsWindow;

    private bool windowActive;
    private bool questFound = false;

    public void OpenActiveQuestsWindow() {
        windowActive = ! windowActive;

        if (windowActive) {
            activeQuestsWindow.SetActive(true);
        }
        else {
            activeQuestsWindow.SetActive(false);
        }
    }

    // check collision with quest giver
    // check if the player has already found the quest giver
    public void OnTriggerEnter(Collider other) {
        if (other.tag == "Player" && !questFound) {
            //print("collided generator");
            questGiver.quest = quest;
            questGiver.OpenQuestWindow();

            questFound = true;
        }
    }

    public void OnTriggerExit(Collider other) {
        //questFound = true;
    }
    
   
}
