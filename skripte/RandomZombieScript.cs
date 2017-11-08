using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomZombieScript : MonoBehaviour {

    public Material[] zombieMaterials;


	void Start () {

        SkinnedMeshRenderer myRenderer = GetComponent<SkinnedMeshRenderer>();
        myRenderer.material = zombieMaterials[Random.Range(0, zombieMaterials.Length)];
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
