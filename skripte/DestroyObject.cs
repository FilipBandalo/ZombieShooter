using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {

    public float aliveTime;
	
	void Awake () {
        Destroy(gameObject, aliveTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
