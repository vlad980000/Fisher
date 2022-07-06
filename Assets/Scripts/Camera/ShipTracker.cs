using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipTracker : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Vector3 _offset;

    private void FixedUpdate()
    {
        transform.position = new Vector3( _player.transform.position.x - _offset.x, transform.position.y, _player.transform.position.z - _offset.z);
    }
}
