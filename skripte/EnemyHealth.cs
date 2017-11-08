using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {


    public float enemyMaxHealth;
    public float damageModifier;
    public GameObject damageParticles;
    
    public bool drops = false;
    public GameObject drop;
    public AudioClip deathSound;
    public bool canBurn;
    public float burnDamage;
    public GameObject burnFX;
    public float burnDuration;
    

    private bool onFire;
    private float nextBurn;
    private float burnInterval;
    private float endBurn;

    private float currentHealth;
    private AudioSource enemyAudioSource;

    public Slider enemeyHealthSlider;


    void Start () {

        currentHealth = enemyMaxHealth;
        enemeyHealthSlider.maxValue = enemyMaxHealth;
        enemeyHealthSlider.value = currentHealth;
        enemyAudioSource = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {
		
        if(onFire == true && Time.time > nextBurn)
        {
            
            AddDamage(burnDamage);
            nextBurn += burnInterval;
        }
        if(onFire == true && Time.time > endBurn)
        {
            onFire = false;
            burnFX.SetActive(false);
        }

	}

    public void AddDamage(float damage)
    {


        enemeyHealthSlider.gameObject.SetActive(true);

        damage = damage * damageModifier;
        if(damage<=0)
        {
            return;
        }
        else { currentHealth -= damage; }
        
       
        enemeyHealthSlider.value = currentHealth;
        enemyAudioSource.Play();
        if(currentHealth <= 0)
        {
            MakeDead();
        }
    }

    void MakeDead()
    {
        //turnoff movment and create ragdoll
        AudioSource.PlayClipAtPoint(deathSound, transform.position, 0.15f);
        Destroy(gameObject.transform.root.gameObject);
        if(drops == true)
        {
            Instantiate(drop, transform.position, Quaternion.Euler(new Vector3(0, 180, 0)));
        }
        
    }
    public void AddFire()
    {
        if (!canBurn) { return; }
        else
        {
            onFire = true;
            burnFX.SetActive(true);
            endBurn = Time.time + burnDuration;
            nextBurn = Time.time + burnInterval;
        }
    }

    public void DamageEffects(Vector3 point, Vector3 rotation)
    {
        Instantiate(damageParticles, point, Quaternion.Euler(rotation));
    }
}
