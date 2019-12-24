using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playonRkey : MonoBehaviour
{


    public AudioSource ReloadSFX;
    private int PassAmmo;


    // Start is called before the first frame update
    void Start()
    {




    }

    // Update is called once per frame
    void Update()
    {



        GameObject Mainchar = GameObject.Find("Main Char");
        Weapon weapon = Mainchar.GetComponent<Weapon>();


       PassAmmo = weapon.CurrentAmmo;



        if (Input.GetKeyDown(KeyCode.R) && PassAmmo != 32)
        {
            ReloadSFX.Play();
        }
    }
}
