using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Quest {

    public bool isActive;
    public bool isComplete = false;

    public string title; 
    public string description;
    public float reward;

    public QuestGoal goal;

    //private GameObject questCompletedWindow;

   // public GameObject questCompletedWindow;

    public void Complete() {
        isActive = false;
        isComplete = true;
        
        Debug.Log(title + " was completed");
        //OpenQuestCompletedWindow();
    }
}
