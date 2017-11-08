using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUpController : MonoBehaviour {

    public int healthAmount;
    public AudioClip healthPickUpSound;
   


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == ("Player"))
        {
            
            other.GetComponent<PlayerHealth>().AddHealth(healthAmount);
            Destroy(transform.root.gameObject);
            AudioSource.PlayClipAtPoint(healthPickUpSound,transform.position,0.2f);
        }
    }
}
