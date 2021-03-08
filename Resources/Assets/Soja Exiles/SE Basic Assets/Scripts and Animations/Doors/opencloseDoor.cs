﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opencloseDoor: MonoBehaviour {

	public Animator openandclose;
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
				if (dist < 15) {
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
		openandclose.Play ("Opening");
		FindObjectOfType<AudioManager>().Play("Door2");
		open = true;
		yield return new WaitForSeconds (.5f);
	}

	IEnumerator closing(){
		print ("you are closing the door");
		openandclose.Play ("Closing");
		FindObjectOfType<AudioManager>().Play("Door2");
		open = false;
		yield return new WaitForSeconds (.5f);
	}


}

