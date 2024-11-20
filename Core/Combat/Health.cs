using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;


public class Health : NetworkBehaviour 
{
    [ field: SerializeField] public int MaxHealth {get; private set;} = 100;
    public NetworkVariable<int> CurrentHealth = new NetworkVariable<int>();

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

    }
    
}

