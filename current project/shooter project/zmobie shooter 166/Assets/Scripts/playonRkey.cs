using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playonRkey : MonoBehaviour
{


    public AudioSource ReloadSFX;
    private int PassAmmo;
    private int PassMagSize;


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
       PassMagSize = weapon.MagSize;



        if (Input.GetKeyDown(KeyCode.R) && PassAmmo != PassMagSize)
        {
            ReloadSFX.Play();
        }
    }
}
