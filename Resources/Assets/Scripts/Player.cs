using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    // variables
    public float maxHealth, maxHunger, minInfection, maxInfection; //maxSanity
    public float hungerIncreaseRate, healthIncreaseRate; //anityIncreaseRate
    private float health, hunger, infection; //sanity
    public bool dead;

    public HealthBar healthBar;
    public HungerBar hungerBar;
    //public SanityBar sanityBar;
    public InfectionBar infectionBar;

    public bool weaponEquipped;

    //public Quest quest;
    public List<Quest> questList = new List<Quest>();

    public float damage;
    public static bool triggeringWithAI;
    public static GameObject triggeringAI;

    //private int number;
    //public GameObject questItemManager;
    private GameObject levelLoader;

    private bool itemAdded;
    // functions
    public void Start() {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        hunger = maxHunger;
        hungerBar.SetMaxHunger(maxHunger);

        /*sanity = maxSanity;
        sanityBar.SetMaxSanity(maxSanity);
        */
        infection = minInfection;
        infectionBar.SetMinInfection(minInfection);

        levelLoader = GameObject.FindWithTag("LevelLoader");
    }

    public void Update() {
        if (!dead) {
            /*sanity -= sanityIncreaseRate * Time.deltaTime;
            sanityBar.SetSanity(sanity); 
            */

            hunger -= hungerIncreaseRate * Time.deltaTime;
            hungerBar.SetHunger(hunger);

            if (infection >= maxInfection || hunger <= 0) {
                health -= healthIncreaseRate * Time.deltaTime;
                healthBar.SetHealth(health);
            }
        }

        /*if (sanity <= 0) {
            Die();
        }*/
        
        if (hunger <= 0) {
            //Die();
        }

        if (health <= 0) {
            Die();
        }

        if (triggeringWithAI && triggeringAI) {
            if(Input.GetMouseButton(0)) {
                Attack(triggeringAI);
            }
        }

        if(Input.GetKeyDown(KeyCode.T)) {
            GetInfected(20);
        }
    }

    // function to check if the player is alive
    public void Die() {
        dead = true; 
        print("Player has died");
        levelLoader.GetComponent<LevelLoader>().ReloadLevel();
    }
   
    // functions to adjust hunger, health with inventory slot objects 
    public void Eat(float decreaseRate) {
       hunger += decreaseRate;
    }

    /*public void StaySane(float decreaseRate) {
        sanity += decreaseRate;
    }*/

    public void StayHealthy(float decreaseRate) {
        health += decreaseRate;
        healthBar.SetHealth(health);
    }

    public void Attack(GameObject target) {
        if (target.tag == "Animal") {
            Animal animal = target.GetComponent<Animal>();

            animal.health -= damage;
        }

        if(target.tag == "Virus") {
            Enemy virus = target.GetComponent<Enemy>();
            
            virus.TakeDamage(damage);
        }
    }

    /*public void GetHungry(int damage) {
        hunger += damage; 

        hungerBar.SetHunger(health); 
    }
    */

    public void TakeDamage(float damage) {
        health -= damage; 

        healthBar.SetHealth(health); 
    }

    public void GetInfected(float damage) {
        infection += damage;

        infectionBar.SetInfection(infection);
    }
     
    
    public void OnTriggerEnter(Collider other) {
        if (other.tag == "Animal" && weaponEquipped) {
            triggeringAI = other.gameObject;
            triggeringWithAI = true;
        }

        if (other.tag == "Virus" && weaponEquipped) {
            print("Triggering with Virus");
            triggeringAI = other.gameObject;
            triggeringWithAI = true;
        }

        /*if (other.tag == "QuestItem") {
            AddQuestItem(other.gameObject);
        }*/
        
    }

    public void OnTriggerExit(Collider other) {
        if(other.tag == "Animal") {
            triggeringAI = null;
            triggeringWithAI = false;
        }

        if(other.tag == "Virus") {
            triggeringAI = null;
            triggeringWithAI = false;
        }

        /*if (other.tag == "QuestItem") {
            itemAdded = false;
        }*/
    }

    /*public void AddQuestItem(GameObject questItem) {
        string questItemType = questItem.GetComponent<QuestItem>().type;

        foreach(Quest quest in questList) {
            if (quest.isActive && quest.goal.type == questItemType && itemAdded==false) {
                quest.goal.ItemCollected();
                print(questItemType + "collected");

                questItem.transform.parent = questItemManager.transform;
                questItem.transform.position = questItemManager.transform.position;

                if (questItem.GetComponent<MeshRenderer>())
                    questItem.GetComponent<MeshRenderer>().enabled = false;

                Destroy(questItem.GetComponent<Rigidbody>());                
            }

            if (quest.goal.IsReached()) {
                quest.Complete();
            }
        }
        itemAdded = true;
    }*/
   


}
