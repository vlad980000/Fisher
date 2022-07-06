using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ShopArea : MonoBehaviour
{
    [SerializeField] private Player _player;

    private BoxCollider _boxCollider;
    
    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }


}
