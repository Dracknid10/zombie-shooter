using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class findclosest : MonoBehaviour
 
{
    public float speed = 1;

    private Transform target;

    private Rigidbody rb;

    private void Start()
    {
        target = FindTarget();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            rb.MovePosition(transform.position + direction * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("zombie"))
        {
            collision.collider.gameObject.tag = "Untagged"; // Remove the tag so that FindTarget won't return it
            Destroy(collision.collider.gameObject);
            target = FindTarget();
        }
    }

    public Transform FindTarget()
    {
        GameObject[] candidates = GameObject.FindGameObjectsWithTag("zombie");
        float minDistance = Mathf.Infinity;
        Transform closest;

        if (candidates.Length == 0)
            return null;

        closest = candidates[0].transform;
        for (int i = 1; i < candidates.Length; ++i)
        {
            float distance = (candidates[i].transform.position - transform.position).sqrMagnitude;

            if (distance < minDistance)
            {
                closest = candidates[i].transform;
                minDistance = distance;
            }
        }
        return closest;
    }
}
