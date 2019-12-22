using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float FireTime = 0.5f;
    private bool isFiring = false;


    public int MagSize = 10;
    private int CurrentAmmo;
   
    public float ReloadTime = 1f;
    private bool isreloading = false;
    

    

    public Animator animator;

    public Text AmmoCounter;
    


    private void Start()
    {
        CurrentAmmo = MagSize;





        AmmoCounter.text = "Ammo: " + CurrentAmmo.ToString();



    }

    public void SetFiring()
    {
        isFiring = false;
    }

    private void Fire()
    {

        isFiring = true;
        
        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        CurrentAmmo--;

        AmmoCounter.text = "Ammo: " + CurrentAmmo.ToString();

        if (GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().Play();
        }
        Invoke("SetFiring", FireTime);

    }

    void Update()
    {



        if (Input.GetKeyDown(KeyCode.R) && CurrentAmmo != 32)
        {
            StartCoroutine(Reload());
        }





        if (isreloading)
        {
            return;
        }




        if (CurrentAmmo <= 0)
        {


            StartCoroutine(Reload());
            isFiring = false;
            return;

        }


        if (CurrentAmmo != 0)
        {


            

            

            if (Input.GetMouseButton(0))
            {

                if (!isFiring)
                {
                    Fire();


                }


            }
        }

        AmmoCounter.text = "Ammo: " + CurrentAmmo.ToString();

    }


    IEnumerator Reload()
    {




        


            isreloading = true;



            Debug.Log("Reloading...");

            animator.SetBool("Reloading", true);

            yield return new WaitForSeconds(ReloadTime);

            animator.SetBool("Reloading", false);


            CurrentAmmo = MagSize;



            isreloading = false;



        




    }


}
