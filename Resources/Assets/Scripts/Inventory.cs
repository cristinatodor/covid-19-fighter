using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public GameObject inventory;
    public GameObject slotHolder;
    public GameObject itemManager;
    private bool inventoryEnabled;

    private int slots;
    private Transform[] slot;

    private GameObject itemPickedUp;
    private bool itemAdded; 
    private bool itemAddedToQuest;

    private GameObject player;

    public void Start() {        
        // slots being detected
        slots = slotHolder.transform.childCount;
        slot = new Transform[slots];
        DetectInventorySlots();

        player = GameObject.FindWithTag("Player");
    }

    public void Update() {
        if (Input.GetKeyDown(KeyCode.I)) {
            inventoryEnabled = !inventoryEnabled;
        }

        if (inventoryEnabled) {
            inventory.GetComponent<Canvas>().enabled = true;
        }
        else {
            inventory.GetComponent<Canvas>().enabled = false;
        }
    }

    public void OnTriggerEnter(Collider other) {
        if (other.tag == "Item") {
            //print("Colliding");
            itemPickedUp = other.gameObject;
            AddItem(itemPickedUp);
            itemPickedUp.GetComponent<Item>().UpdateText();
        }
        if (other.tag == "QuestItem") {
            //print(player.GetComponent<Player>().questList);
            //AddQuestItem(other.gameObject);
            itemPickedUp = other.gameObject;
            
            if (CheckIfQuest(itemPickedUp)) {
                AddItem(itemPickedUp);
                itemPickedUp.GetComponent<Item>().UpdateText();
                print("Added quest item");
            }
        }

        if (other.tag == "FinalItem") {
            itemPickedUp = other.gameObject;

            if(CheckIfQuest(itemPickedUp)) {
                print("Final item added to quest");
            }
        }
    }

    public void OnTriggerExit(Collider other) {
        //Debug.Log("trigger exit");
        if (other.tag == "Item") {
            itemAdded = false;
            itemAddedToQuest = false;
        }

        if (other.tag == "QuestItem") {
            itemAddedToQuest = false;
            itemAdded = false;
        }

        if (other.tag == "FinalItem") {
            itemAddedToQuest = false;
            itemAdded = false;
        }
    }

    public void AddItem(GameObject item) {

        // add an item to inventory 
        for (int i = 0; i < slots; i++) {
            if (slot[i].GetComponent<Slot>().empty && itemAdded == false) {
                slot[i].GetComponent<Slot>().item = itemPickedUp;
                slot[i].GetComponent<Slot>().itemIcon = itemPickedUp.GetComponent<Item>().icon;

                item.transform.parent = itemManager.transform;
                item.transform.position = itemManager.transform.position;

                item.transform.localPosition = item.GetComponent<Item>().position;
                item.transform.localEulerAngles = item.GetComponent<Item>().rotation;
                item.transform.localScale = item.GetComponent<Item>().scale;

                /*if (item.GetComponent<MeshRenderer>())
                    item.GetComponent<MeshRenderer>().enabled = false;
                */

                //item.GetComponent<Item>().pickedUp = true;
                
                Destroy(item.GetComponent<Rigidbody>()); 
                itemAdded = true;
                item.SetActive(false);
            }
        }

        // check if item is part of quest
        /*string itemType = item.GetComponent<Item>().type;
        
        foreach (Quest quest in player.GetComponent<Player>().questList) {
            if (quest.isActive && quest.goal.type == itemType && itemAddedToQuest ==false) {
                quest.goal.ItemCollected();
                print(itemType + "collected");
            }

            if (quest.goal.IsReached()) {
                quest.Complete();
            }
        }
        itemAddedToQuest = true;
        */

    }

    public bool CheckIfQuest(GameObject item) {
        bool isPartOfQuest = false;

        string itemType = item.GetComponent<Item>().type;
        
        foreach (Quest quest in player.GetComponent<Player>().questList) {
            if (quest.isActive && quest.goal.type == itemType && itemAddedToQuest == false) {
                quest.goal.ItemCollected();
                print(itemType + "collected");

                isPartOfQuest = true;
            }

            if (quest.goal.IsReached()) {
                quest.Complete();
            }
        }

        itemAddedToQuest = true;

        return isPartOfQuest;
    }

    public void DetectInventorySlots() {

        for (int i = 0; i < slots; i++) {
            slot[i] = slotHolder.transform.GetChild(i);
            //print(slot[i].name);
        }
    }

    /*    
    public void AddQuestItem(GameObject questItem) {
        string questItemType = questItem.GetComponent<QuestItem>().type;

        foreach(Quest quest in player.GetComponent<Player>().questList) {
            if (quest.isActive && quest.goal.type == questItemType && itemAddedToQuest ==false) {
                quest.goal.ItemCollected();
                print(questItemType + "collected");

                /*for (int i = 0; i < slots; i++) {
                    if (slot[i].GetComponent<Slot>().empty) {
                        slot[i].GetComponent<Slot>().item = questItem;
                        slot[i].GetComponent<Slot>().itemIcon = questItem.GetComponent<QuestItem>().icon;
                        break;
                    }
                }

                questItem.transform.parent = itemManager.transform;
                questItem.transform.position = itemManager.transform.position;

                if (questItem.GetComponent<MeshRenderer>())
                    questItem.GetComponent<MeshRenderer>().enabled = false;

                Destroy(questItem.GetComponent<Rigidbody>());               
            }

            if (quest.goal.IsReached()) {
                quest.Complete();
            }
        }
        itemAddedToQuest = true;

        //AddItem(questItem);
    } */

    
}
