using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceMoveTowardsObject : MonoBehaviour
{
    // Start is called before the first frame update


    public Transform target;
    public float speed = 5.0f;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * 0.01f);
        }

    }
    public void SetTarget(Transform newTarget)
    {

        if (true)
        {

        }


        target = GameObject.FindGameObjectWithTag("zombie").transform;
    }

}
