﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsObject : MonoBehaviour
{
    // Start is called before the first frame update


    public Transform target;
    public float speed = 5.0f;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("zombiesPolice").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * 0.01f);
        }
        else
        {

            target = GameObject.FindGameObjectWithTag("Zombie").transform;
        }
      


    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

}
