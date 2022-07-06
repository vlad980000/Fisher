using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Fish))]
public class FishMovementState : State
{
    [SerializeField] private float _timeToTarget;

    private Fish _fish;
    private void Start()
    {
        _fish = GetComponent<Fish>();

        Tween tween = transform.DOPath(_fish.Waypoints, _timeToTarget, PathType.CatmullRom).SetOptions(true).SetLookAt(0.01f);

        tween.SetLoops(-1);
    }
}
