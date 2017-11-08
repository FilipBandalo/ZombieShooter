using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public float fullHealth;

   
    public GameObject playerDeathFX;
    
    public Slider playerHealthSlider;
    public Image playerDmgScreen;
    public bool isAlive;

    private float currentHealth;
    private Color flashColor = new Color(255f, 255f, 255f, 1f);
    private float colorFadeAway = 5f;
    private bool isDamaged = false;
    AudioSource playerGruntOnDmag;
    


    void Start () {
        currentHealth = fullHealth;
        playerHealthSlider.maxValue = fullHealth;
        playerHealthSlider.value = currentHealth;
        playerGruntOnDmag = GetComponent<AudioSource>();
        isAlive = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (isDamaged)
        {
            playerDmgScreen.color = flashColor;
        }else
        {
            playerDmgScreen.color = Color.Lerp(playerDmgScreen.color, Color.clear, colorFadeAway*Time.deltaTime);
        }
        isDamaged = false;

	}

    public void AddDamage(float damage)
    {
        currentHealth -= damage;
        playerHealthSlider.value = currentHealth;
        isDamaged = true;
        if(currentHealth <= 0)
        {
            Death();
        }
        playerGruntOnDmag.Play();

    }

    public void Death()
    {
        Instantiate(playerDeathFX, transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
        playerDmgScreen.color = flashColor;
        isAlive = false;
        Destroy(gameObject);



    }
    public void AddHealth(int health)
    {
        currentHealth += health;
        if(currentHealth > fullHealth)
        {
            currentHealth = fullHealth;
        }
        playerHealthSlider.value = currentHealth;
    }
}
