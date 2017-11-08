using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUpController : MonoBehaviour {


   

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == ("Player"))
        {
            other.GetComponentInChildren<FireBullet>().AddAmmo();
            Destroy(transform.root.gameObject);
        }
    }
}
