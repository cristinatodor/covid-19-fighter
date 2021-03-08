using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseDoorQuest: MonoBehaviour {

	public Animator openandclose1;
	public bool open;
	public Transform Player;

    public QuestGenerator questGenerator;

	/*void Awake() {
		
	}*/
	
	void Start (){
        Player = PlayerManager.instance.player.transform;
		open = false;
	}

	void OnMouseOver (){
		{
			if (Player) {
				float dist = Vector3.Distance(Player.position, transform.position);
                print("Player...");
                //print("Printing..." + questGenerator.GetComponent<QuestGenerator>().quest);
				if (dist < 15 && questGenerator.GetComponent<QuestGenerator>().quest.isComplete) {
					if (open == false) {
						if (Input.GetMouseButtonDown (0)) {
							StartCoroutine (opening ());
						}
					} else {
						if (open == true) {
							if (Input.GetMouseButtonDown (0)) {
								StartCoroutine (closing ());
							}
						}

					}

				}
			}

		}

	}

	IEnumerator opening(){
		print ("you are opening the door");
		openandclose1.Play("Opening 1");
		FindObjectOfType<AudioManager>().Play("Door2");
		open = true;
		yield return new WaitForSeconds (.5f);
	}

	IEnumerator closing(){
		print ("you are closing the door");
		openandclose1.Play("Closing 1");
		FindObjectOfType<AudioManager>().Play("Door2");
		open = false;
		yield return new WaitForSeconds (.5f);
	}


}

