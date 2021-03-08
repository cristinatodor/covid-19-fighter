using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer_Pull_Z: MonoBehaviour {

	public Animator pull;
	public bool open;
	public Transform Player;

	void Start (){
		open = false;
		Player = PlayerManager.instance.player.transform;
	}

	void OnMouseOver (){
		{
			if (Player) {
				float dist = Vector3.Distance (Player.position, transform.position);
				if (dist < 10) {
                    print("object name");
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
		pull.Play ("openpull");
		FindObjectOfType<AudioManager>().Play("Squeak");
		open = true;
		yield return new WaitForSeconds (.5f);
	}

	IEnumerator closing(){
		print ("you are closing the door");
		pull.Play ("closepush");
		FindObjectOfType<AudioManager>().Play("Squeak");
		open = false;
		yield return new WaitForSeconds (.5f);
	}


}

