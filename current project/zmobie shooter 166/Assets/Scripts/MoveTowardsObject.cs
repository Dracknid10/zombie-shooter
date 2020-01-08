using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsObject : MonoBehaviour
{
    // Start is called before the first frame update


    public Transform target;
    public float speed = 5.0f;


    public float smoothing = 5.0f;
    public float adjustmentAngle = 0.0f;

    public Animator PoliceAnimator;

    void Start()
    {
        PoliceAnimator.SetBool("IsWhacking", false);
        target = GameObject.FindGameObjectWithTag("Zombie").transform;
    }





    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Zombie")
        {
            PoliceAnimator.SetBool("IsWhacking", true);
        }

    }






    // Update is called once per frame
    void Update()
    {

     



        if (target != null)
        {

            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * 0.01f);
            Vector3 difference = target.position - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            Quaternion newRot = Quaternion.Euler(new Vector3(0.0f, 0.0f, rotZ + adjustmentAngle));
            transform.rotation = Quaternion.Lerp(transform.rotation, newRot, Time.deltaTime * smoothing);

        } else
        {
            target = GameObject.FindGameObjectWithTag("Zombie").transform;

        }



        //else
        //{

        //    target = GameObject.FindGameObjectWithTag("Zombie").transform;
        //}
        //else
        //{
        //    target = GameObject.FindGameObjectWithTag("player").transform;
        //}

        
       

        
      


    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

  


}
