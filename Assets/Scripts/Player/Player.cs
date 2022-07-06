using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ShipMovement))]
public class Player : MonoBehaviour
{
    [SerializeField] private List<Fish> _catch = new List<Fish>();
    [SerializeField] private Fishnet _fishnet;

    ShipMovement _shipMovement;
    private BoxCollider _collider;
    private uint _money = 0;
    
    public UnityAction<Fishnet> CircleIsClosed;

    public event UnityAction<int> FishSold;

    private void Start()
    {
        _collider = GetComponent<BoxCollider>();
    }

    private void SellFish()
    {
        if(_catch.Count > 0)
        {
            for (int i = 0; i < _catch.Count; i++)
            {
                _catch.Remove(_catch[i]);
                FishSold(_catch[i].Cost);
            }
        }
        else
        {
            return;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.TryGetComponent<Fishnet>(out Fishnet fishnet))
        {
            CircleIsClosed?.Invoke(fishnet);   
            Debug.Log("столкновение с сетями");
        }
    }
}
