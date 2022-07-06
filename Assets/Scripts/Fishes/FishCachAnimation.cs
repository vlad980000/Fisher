using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Fish))]
public class FishCachAnimation : State
{
    [SerializeField] private float _speed;
    [SerializeField] private AnimationCurve _yAnimation;

    private float _animationTime;
    public GameObject _target;
    public void Start()
    {
        StartCoroutine(BounseAnimation());
    }

    private IEnumerator BounseAnimation()
    {
        var waitOneSecond = new WaitForSecondsRealtime(1f);

        while (transform.position != _target.transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);

            yield return waitOneSecond;
        }
       
    }
}
