using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zeptomoby.OrbitTools;

public class OrbitToolsTest : MonoBehaviour
{
    [SerializeField] private GameObject satelliteGameObject;
    [SerializeField] private float speed = 1.0f;

    private Satellite satellite;

    void Start()
    {
        // random TLE
        string line1 = "1 75964C 23042Z   23085.04423611  .00220051  00000-0  86866-3 0   854";
        string line2 = "2 75964  43.0044 186.4429 0030833 349.6785 143.4678 15.84804581    19";
        TwoLineElements tle = new TwoLineElements("Test", line1, line2);
        
        // instantiate new satellite
        satellite = new Satellite(tle);
    }

    private void FixedUpdate()
    {
        // Eci object contains position and velocity vectors
        Eci eci = satellite.PositionEci(Time.time * speed);
        
        // TODO: don't do this
        // update position and ignore velocity cause lazy
        Vector3 position = new Vector3((float)eci.Position.X, (float)eci.Position.Y, (float)eci.Position.Z);
        satelliteGameObject.transform.position = position / 1000; // div 1000 for km to m
    }
}

