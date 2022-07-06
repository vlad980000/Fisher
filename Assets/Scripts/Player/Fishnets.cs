using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fishnets : MonoBehaviour
{
    [SerializeField] private Fishnet[] _fishnets;
    [SerializeField] private Player _player;

    private void Awake()
    {
        AssignsNumber();
    }

    private void AssignsNumber()
    {
        for (int i = 0; i < _fishnets.Length; i++)
        {
            _fishnets[i].Number = i;
        }
    }

    private void OnCircleIsClosed(Fishnet fishnet)
    {
        for (int i = 0; i < fishnet.Number - 1; i++)
        {
            Ray ray = new Ray(fishnet.transform.position, _fishnets[i].transform.position);
            Debug.DrawRay(fishnet.transform.position, _fishnets[i].transform.position, Color.red);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider.TryGetComponent<Fish>(out Fish fish))
                {
                    fish.GetComponent<CachTransition>().NextState(_player.transform);
                }
            }
        }
    }

    private void OnEnable()
    {
        _player.CircleIsClosed += OnCircleIsClosed;
    }

    private void OnDisable()
    {
        _player.CircleIsClosed -= OnCircleIsClosed;
    }
}
