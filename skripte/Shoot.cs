using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public float range = 10.0f;
    public float rifleDamage = 5.0f;

    Ray shootRay;
    RaycastHit shootHit;
    int shootMask;
    LineRenderer gunLine;


	
	void Awake () {
        shootMask = LayerMask.GetMask("Shootable");
        gunLine = GetComponent<LineRenderer>();
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;
        gunLine.SetPosition(0, transform.position);
        if(Physics.Raycast(shootRay,out shootHit, range, shootMask))
        {
            if(shootHit.collider.tag == "Enemy")
            {
                EnemyHealth theenemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
                if(theenemyHealth != null)
                {
                    theenemyHealth.AddDamage(rifleDamage);
                    theenemyHealth.DamageEffects(shootHit.point, -shootRay.direction);
                }
            }
            gunLine.SetPosition(1, shootHit.point);
        }
        else
        {
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
