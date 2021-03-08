using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour {

    public Quest quest;

    public Player player;
    //public QuestManager questManager;

    public GameObject questWindow;
    public Text titleText;
    public Text descriptionText;
    public Text rewardText;

    //public GameObject activeQuestsWindow;
    public Text title1, title2, title3, title4, title5, title6, title7;
    List<Text> titles = new List<Text>();

    private string titleid;

    public GameObject questCompletedWindow;
    public Text completedTitle;
    public Text completedReward;

    public void Start() {
        titles.Add(title1);
        titles.Add(title2);
        titles.Add(title3);
        titles.Add(title4);
        titles.Add(title5);
        titles.Add(title6);
        titles.Add(title7);
    }

    public void OpenQuestWindow() {
        questWindow.SetActive(true);

        titleText.text = quest.title;
        descriptionText.text = quest.description;
        rewardText.text = quest.reward.ToString();
    }

    //public void OpenActiveQuestsWindow()

    public void AcceptQuest() {
        questWindow.SetActive(false);
        quest.isActive = true;

        //player.quest = quest;
        player.questList.Add(quest);
        //questManager.questList.Add(quest);
        
        for (int i = 0; i < 7; i++) {
            if (titles[i].text == "") {
                titles[i].text = quest.title;
                titleid = (i+1).ToString();
                break;
            }
        }
        
    }

    public void DiscardQuest() {
        questWindow.SetActive(false);
    }

    private void OpenQuestCompletedWindow(Quest completedQuest) {
        questCompletedWindow.SetActive(true);

        completedTitle.text = completedQuest.title;
        completedReward.text = completedQuest.reward.ToString();

        player.StayHealthy(completedQuest.reward);

        Invoke("Discard", 10);

    }

    private void Discard(){
        questCompletedWindow.SetActive(false);
    }

    public void Update() {
        foreach (Quest playerquest in player.questList) {
            if (!playerquest.isActive) {
                for (int i=0; i < 7; i++) {
                    if (titles[i].text == playerquest.title) {
                        titles[i].text = "";

                        OpenQuestCompletedWindow(playerquest);
                    }
                }
            } 
            /*else {
                found = false;

            }*/
        }
    }

  
}
