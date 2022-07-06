using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(SphereCollider))]
public class Fishnet : MonoBehaviour
{
    [SerializeField] private float _stopDistance;
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;

    private SphereCollider _sphereCollider;

    public int Number;

    private void Start()
    {
        _sphereCollider = GetComponent<SphereCollider>();
    }

    private void Update()
    {
        transform.LookAt(_target);

        if(Vector3.Distance(transform.position,_target.position) > _stopDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position,_target.position,_speed * Time.deltaTime);
        } 
    }
}
