using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetSolider : MonoBehaviour
{

    public Transform Target;
    public float Speed = 1.0f;
    public float DistanceToKeep = 2.0f;

    private Transform _transform;

    void Awake()
    {
        _transform = transform;
       
    }

    void Update()
    {
        if (!Target)
        {
            Debug.Log("No target!");
            return;
        }

        _transform.LookAt(Target.position);

        float distance = Vector3.Distance(Target.position, _transform.position);

        if (distance >= DistanceToKeep)
            _transform.position += _transform.forward * Speed * Time.deltaTime;
    }

    public void SetTarget(Transform newTarget)
    {
        Target = newTarget;
    }
}