using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {
    private bool hovered;    
    public bool empty;

    public GameObject item;
    public Texture itemIcon; 

    private GameObject player;
    private GameObject[] enemies;

    void Start() {
        hovered = false;

        player = PlayerManager.instance.player;
        enemies = GameObject.FindGameObjectsWithTag("Virus");
    }

    void Update() {
        if (item) {
            empty = false;
            itemIcon = item.GetComponent<Item>().icon;
            this.GetComponent<RawImage>().texture = itemIcon;
        }
        else {
            empty = true;
            itemIcon = null;
            this.GetComponent<RawImage>().texture = null; 
        }
    }

    public void OnPointerEnter(PointerEventData eventData) {
        hovered = true; 
    }

    public void OnPointerExit(PointerEventData eventData) {
        hovered = false; 
    }

    public void OnPointerClick(PointerEventData eventData) {
        if (item) {
            Item thisItem = item.GetComponent<Item>();
            
            // check item type and adjust hunger, sanity, health
            if (thisItem.type == "Food") {
                player.GetComponent<Player>().Eat(thisItem.decreaseRate);
                Destroy(item);
            }
            
            /*if (thisItem.type == "Sanity") {
                player.GetComponent<Player>().StaySane(thisItem.decreaseRate);
                Destroy(item);
            }*/

            if (thisItem.type == "Health") {
                player.GetComponent<Player>().StayHealthy(thisItem.decreaseRate);
                Destroy(item);
            }

            if (thisItem.type == "DamageVirus") {
                foreach (GameObject enemy in enemies) {
                    enemy.GetComponent<Enemy>().TakeDamage(thisItem.decreaseRate);
                    Destroy(item);
                }
            }

            if (thisItem.type == "Weapon" && player.GetComponent<Player>().weaponEquipped == false) {
                //Debug.Log("Mask clicked");
                thisItem.equipped = true;
                item.SetActive(true);
            }

        }
    }
}
