﻿using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour
{
    [SerializeField]
    private float tumble;

    
    void Start()
    {
        tumble = Random.Range(0,.8f);
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
    }
}