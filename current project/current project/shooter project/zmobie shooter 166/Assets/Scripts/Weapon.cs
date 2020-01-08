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
    public int CurrentAmmo;

    public float ReloadTime = 1f;
    private bool isreloading = false;

    public AudioSource gunshot;
    //public AudioSource reloadSound;

    public Animator animator;

    public Text AmmoCounter;



    public void Playgunshot()
    {
        gunshot.Play();
    }


    //public void Playreload()
    //{
    //    reloadSound.Play();
    //}



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

        animator.SetBool("isfiring", true);

        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        CurrentAmmo--;

        Playgunshot();
        

        AmmoCounter.text = "Ammo: " + CurrentAmmo.ToString();

        if (GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().Play();
        }
        Invoke("SetFiring", FireTime);


        

    }

    void Update()
    {



        if (Input.GetKeyDown(KeyCode.R) && CurrentAmmo != MagSize)
        {

            StartCoroutine(Reload());
            //Playreload();
        }


        if (CurrentAmmo <= 0)
        {

            animator.SetBool("isfiring", false);
            //StartCoroutine(Reload());
            isFiring = false;
            isreloading = false;

            AmmoCounter.text = "RELOAD USING, R";

            return;

        }


        if (isreloading)
        {
            return;
        }












        if (Input.GetMouseButton(0))
        {

            if (!isFiring)
            {


                
                Fire();
                


            }



        }
        else
        {
            animator.SetBool("isfiring", false);
           
        }

        


        AmmoCounter.text = "Ammo: " + CurrentAmmo.ToString();




        IEnumerator Reload()
        {







            isreloading = true;

            



            Debug.Log("ReloadingSoundPlaying...");

            Debug.Log("Reloading...");
            animator.SetBool("isfiring", false);
            animator.SetBool("Reloading", true);

            
            

            yield return new WaitForSeconds(ReloadTime);

            

            animator.SetBool("Reloading", false);


            CurrentAmmo = MagSize;



            isreloading = false;








        }


    }
}
