using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ZombieSpawner : MonoBehaviour
{

    [System.Serializable]
    public struct IntervalValues
    {

        public float MinValue;
        public float MaxValue;

    }
    public GameObject ObjectToSpawn;

    // public IntervalValues TimeInterval;
    public bool IsActive = true;
   
    public Vector2 TimeInterval;
    public float Test = 1.0f;
    [Header("Optional")]
    public Transform TargetToChase;

    void Awake()
    {

        StartCoroutine(SpawnTimer());

        Test = TimeInterval.RandomValue();

    }

    public IEnumerator SpawnTimer()
    {
    
        

            while (IsActive)
            {


                float waitTime = TimeInterval.RandomValue();
                yield return new WaitForSeconds(waitTime);
                SpawnObject();
            }
        
    }
 

    public void SpawnObject()
    {

        

        GameObject objectClone = Instantiate(ObjectToSpawn, transform.position, Quaternion.Euler(new Vector3(0,90,0)));
       // objectClone.transform.SetParent(transform);
       


       // objectClone.GetComponent<FollowTargetSolider>().SetTarget(TargetToChase);
        //FollowTargetSolider followTarget = objectClone.GetComponent<FollowTargetSolider>();

      //  if (followTarget)
      //  {
      //      followTarget.SetTarget(TargetToChase);
       // }
    
    }

}