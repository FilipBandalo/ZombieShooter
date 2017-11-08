using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigerer : MonoBehaviour {

    public GameObject enemy;
    public Transform enemypos;
    private float repatrate = 1.0f;

	void Start () {

       
	}
	
	// Update is called once per frame
	void FixedUpdate () {
     

	}

    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.tag == "Player")
        {
            InvokeRepeating("EnemySpawner", 0F, repatrate);
            Destroy(gameObject, 11F);
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    void EnemySpawner()
    {
        Instantiate(enemy, enemypos.position, Quaternion.Euler(new Vector3(0,90,0)));
    }
}
