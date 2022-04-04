﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normalShots : MonoBehaviour
{
    [SerializeField]
    private GameObject explosion;
    private List<ParticleCollisionEvent> CollisionEvents;
    private ParticleSystem PSystem;
    

    void Start() {
        CollisionEvents = new List<ParticleCollisionEvent>();
        PSystem = this.GetComponent<ParticleSystem>();
    }
    void OnParticleCollision(GameObject other){
        ParticlePhysicsExtensions.GetCollisionEvents(PSystem, other, CollisionEvents);

        for(int i=0;i<CollisionEvents.Count;i++){
            EmitAtLocation(CollisionEvents[i]);
        }
    }

    void EmitAtLocation(ParticleCollisionEvent PCE){
        var effect = Instantiate(explosion,PCE.intersection,Quaternion.LookRotation(PCE.normal)) as GameObject;
    }
}