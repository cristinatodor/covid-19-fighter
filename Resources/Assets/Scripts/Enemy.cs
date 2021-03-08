using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    public float lookRadius = 2f;
    public float damage;
    public float maxHealth = 200;
    public float health;
    public bool dead = false;

    public EnemyHealthBar enemyHealthBar; 

    Transform target;
    private GameObject player;
    NavMeshAgent agent;

    public Animator transition;
    public float transitionTime = 3f;

    public void Start() {
        health = maxHealth;
        enemyHealthBar.SetMaxHealth(maxHealth);

        agent = GetComponent<NavMeshAgent>();
        target = PlayerManager.instance.player.transform;
        player = PlayerManager.instance.player;

        transition = this.GetComponent<Animator>();
    }

    public void Update() {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius) {
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance) {
                FaceTarget();
                AttackTarget();
                //player.GetComponent<Player>().AttackEnemy();
                //GetAttacked();
            }
        }

        if (health <= 0) {
            Die();
        }

        /*if (Input.GetKeyDown(KeyCode.M)) {
            //TakeDamage(10);
            transition.SetTrigger("Start");
        }*/
    }

    private void FaceTarget() {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void AttackTarget() {
        //player.GetComponent<Player>().TakeDamage(damage);
        player.GetComponent<Player>().GetInfected(damage);

        FindObjectOfType<AudioManager>().Play("VirusHit");

    }

    void GetAttacked() {
        if (player.GetComponent<Player>().weaponEquipped) {
            TakeDamage(player.GetComponent<Player>().damage);
        }
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    public void TakeDamage(float damage) {
        health -= damage;
        enemyHealthBar.SetHealth(health);

        print("Virus taking: " + damage + " damage");
    }

    public void Die() {
        dead = true;

        StartCoroutine(EnemyDeath());        
        print("Virus has died");
    }

    IEnumerator EnemyDeath() {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        Destroy(this.gameObject);
    }
}
