using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

    public List<Quest> questList = new List<Quest>();

    public void OnTriggerEnter(Collider other) {
        if (other.tag == "Item" && other.GetComponent<Item>().type == "Water") {
            AddWater();
        }
    }
    
    public void AddWater() {
        foreach(Quest quest in questList) {
        //print(quest.goal.type);
            if (quest.goal.type == "Water") {
                quest.goal.ItemCollected();
                print("Water collected");
            }
        }
    }
}
