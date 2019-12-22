using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TopDownCharacterController2D : MonoBehaviour
{
    public int speed = 5;
    public int SprintSpeed = 7;

   

    

    Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {

        rigidbody2D = GetComponent<Rigidbody2D>();

   



    }

    // Update is called once per frame
    void Update()
    {
       

        float x = Input.GetAxis( "Horizontal" );
        float y = Input.GetAxis("Vertical");

        rigidbody2D.velocity = new Vector2(x, y) * speed;
        rigidbody2D.angularVelocity = 0.0f;





        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            
            speed = 5;


        }

        

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            
            speed = SprintSpeed;

            


           


          


        }

      

    }

   



}
