using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public int Value = 1;

    //public GameObject PickupExplosion;
    public AudioClip SFX;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.gm.Collect(Value);

            AudioSource.PlayClipAtPoint(SFX, transform.position,10f);

            //Instantiate(PickupExplosion, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
