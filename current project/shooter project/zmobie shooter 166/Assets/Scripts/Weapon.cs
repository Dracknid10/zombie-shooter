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
    public float fireTime = 0.5f;
    private bool isFiring = false;


    public int maxammo = 10;
    private int currentammo;
    public float reloadtime = 1f;
    private bool isreloading = false;

    public Animator animator;

    public Text AmmoCounter;


    private void Start()
    {
        currentammo = maxammo;
        AmmoCounter.text = "Ammo: " + currentammo.ToString();

    }

    public void SetFiring()
    {
        isFiring = false;
    }

    private void Fire()
    {

        isFiring = true;
        
        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        currentammo--;

        AmmoCounter.text = "Ammo: " + currentammo.ToString();

        if (GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().Play();
        }
        Invoke("SetFiring", fireTime);

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && currentammo != 32)
        {
            StartCoroutine(Reload());
        }




        if (isreloading)
        {
            return;
        }
  

        if (currentammo <= 0)
        {
            StartCoroutine(Reload());
            isFiring = false;
            return;
               
        }

       


        if (Input.GetMouseButton(0))
        {

            if (!isFiring)
            {
                Fire();
                

            }
            
     
        }

        AmmoCounter.text = "Ammo: " + currentammo.ToString();

    }


    IEnumerator Reload()
    {

        isreloading = true;

        Debug.Log("Reloading...");
        animator.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadtime);

        animator.SetBool("Reloading", false);
        currentammo = maxammo;
        


        isreloading = false;

    }


}
