using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireBullet : MonoBehaviour {

    public float timeBetweenBullets = 0.15f;
    public GameObject projectile;
    public Slider playerAmmoSlider;
    public int maxBullets;
    public int startingBullets;
    public AudioClip gunShootSound;
    public AudioClip gunReloadSound;
    

    private float nextBullet;
    private int remainingBullets;
    private AudioSource gunSound;


	void Awake () {
        nextBullet = 0.0f;
        remainingBullets = startingBullets;
        playerAmmoSlider.maxValue = maxBullets;
        playerAmmoSlider.value = remainingBullets;
        gunSound = GetComponent<AudioSource>();


	}
	
	
	void Update () {

        PlayerController myPlayer = transform.root.GetComponent<PlayerController>();
        if(Input.GetAxisRaw("Fire1") > 0 && nextBullet < Time.time && remainingBullets > 0)
        {
            nextBullet = Time.time + timeBetweenBullets;
            Vector3 rot;
           
            if(myPlayer.GetFacing() == -1f)
            {
                rot =new Vector3(0, -90, 0);
            }
            else { rot = new Vector3(0, 90, 0); }

            Instantiate(projectile, transform.position, Quaternion.Euler(rot));
            gunSound.clip = gunShootSound;
            gunSound.Play();
            remainingBullets -= 1;
            playerAmmoSlider.value = remainingBullets;

        }


	}

    public void AddAmmo()
    {
        remainingBullets = maxBullets;
        playerAmmoSlider.value = remainingBullets;
        gunSound.clip = gunReloadSound;
        gunSound.Play();
    }
}
