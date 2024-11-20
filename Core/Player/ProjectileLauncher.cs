using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class ProjectileLauncher : NetworkBehaviour
{
    [Header("References")]
    [SerializeField] private InputReader inputReader;
    [SerializeField] private Transform projectileSpawnPoint;
    [SerializeField] private GameObject serverProjectilePrefab;
    [SerializeField] private GameObject clientProjectilePrefab;

     
    [Header("Settings")]
    [SerializeField] private float projectileSpeed;

    private bool shouldFire;

    public override void OnNetworkSpawn()
    {
        if(!IsOwner) {
            return;
        }

        inputReader.PrimaryFireEvent += HandlePrimaryFire;

    }
    public override void OnNetworkDespawn()
    {
         if(!IsOwner) {
            return;
        }

            inputReader.PrimaryFireEvent -= HandlePrimaryFire;
    }


    // Update is called once per frame
    private void Update()
    {

        if(!IsOwner) {return;}
        if(!shouldFire) {return;}

        SpawnDummyProjectile(projectileSpawnPoint.position, projectileSpawnPoint.up);


        
    }

 

    private void HandlePrimaryFire(bool shouldFire) {
        this.shouldFire = shouldFire;
    }

       private void SpawnDummyProjectile(Vector3 spawnPos, Vector3 direction)
    {
        Instantiate(clientProjectilePrefab, spawnPos, Quaternion.identity);
    }
}
