using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour {

    public GameObject flipModel;


    public AudioClip[] idleSounds;
    public float idleSoundTime;
    public float detectionTime;

    private AudioSource enemeyMovmentSound;
    private float nextIdleSound = 0f;
    private float startRun;
    private bool firstDetection;
    //movment
    public float runSpeed;
    public float walkSpeed;
    public bool faceingRight = true;

    private float moveSpeed;
    private bool running;

    private Rigidbody zombieRB;
    private Animator zombieAnimator;
    private Transform detectedPlayer;
    private bool detected;



	void Start () {

        zombieRB = GetComponentInParent<Rigidbody>();
        zombieAnimator = GetComponentInParent<Animator>();
        enemeyMovmentSound = GetComponent<AudioSource>();

        running = false;
        detected = false;
        firstDetection = false;
        moveSpeed = walkSpeed;

        if (Random.Range(0, 10) > 5)
        {
            Flip();
        }
		
	}
	
	
	void FixedUpdate () {

        if (detected)
        {
            if (detectedPlayer.position.x < transform.position.x && faceingRight)
            {
                Flip();
            }
            else if (detectedPlayer.position.x > transform.position.x && !faceingRight)
            {
                Flip();
            }
        }
        if (!firstDetection)
        {
            startRun = Time.time + detectionTime;
            firstDetection = true;
        }
        if (detected && !faceingRight)
        {
            zombieRB.velocity = new Vector3((moveSpeed * -1), zombieRB.velocity.y, 0);
        }else if(detected && faceingRight)
        {
            zombieRB.velocity = new Vector3((moveSpeed * 1), zombieRB.velocity.y, 0);
        }

        if(!running && detected)
        {
            if(startRun < Time.time)
            {
                moveSpeed = runSpeed;
                zombieAnimator.SetTrigger("run");
                running = true;
            }
        }

        if(!running)
        {
            if(Random.Range(0,10)>5 && nextIdleSound < Time.time)
            {
                AudioClip tempClip = idleSounds[Random.Range(0, idleSounds.Length)];
                enemeyMovmentSound.clip = tempClip;
                enemeyMovmentSound.Play();
                nextIdleSound = idleSoundTime + Time.time; 
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !detected)
        {
            detected = true;
            detectedPlayer = other.transform;
            zombieAnimator.SetBool("detected", detected);
            if (detectedPlayer.position.x < transform.position.x && faceingRight)
            {
                Flip();
            }
            else if(detectedPlayer.position.x > transform.position.x && !faceingRight)
            {
                Flip();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            firstDetection = false;
            if(running)
            {
                zombieAnimator.SetTrigger("run");
                moveSpeed = walkSpeed;
                running = false;
            }
        }
    }

    void Flip() {
        faceingRight = !faceingRight;
        Vector3 theScale = flipModel.transform.localScale;
        theScale.z *= -1;
        flipModel.transform.localScale = theScale;
            }
}

