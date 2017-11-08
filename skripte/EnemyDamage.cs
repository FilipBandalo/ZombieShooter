using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    public float damage;
    public float damageRate;
    public float pushBackForce;

    private float nextDamage;
    private bool playerInRange = false;

    GameObject thePlayer;
    PlayerHealth thePlayerHealth;


	void Start () {
        nextDamage = Time.time;
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        thePlayerHealth = thePlayer.GetComponent<PlayerHealth>();

	}
	
	// Update is called once per frame
	void Update () {
        if (playerInRange)
        {
            Attack();
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == ("Player"))
        {
            playerInRange = true;
        }
        if(other.tag == "Boss")
        {
            EnemyHealth theEnemyHealth = other.GetComponent<EnemyHealth>();
            if(theEnemyHealth != null)
            {
                theEnemyHealth.AddDamage(damage);
                theEnemyHealth.AddFire();
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            playerInRange = false;
        }
    }
    void Attack()
    {
        if(nextDamage <= Time.time)
        {
            thePlayerHealth.AddDamage(damage);
            nextDamage = Time.time + damageRate;
            PushBack(thePlayer.transform);
        }

    }

    void PushBack(Transform pushObject)
    {
        Vector3 pushDirection = new Vector3(0, pushObject.position.y - transform.position.y, 0).normalized;
        pushDirection *= pushBackForce;

        Rigidbody pushedRB = pushObject.GetComponent<Rigidbody>();
        pushedRB.velocity = Vector3.zero;
        pushedRB.AddForce(pushDirection, ForceMode.Impulse);
    }

}

