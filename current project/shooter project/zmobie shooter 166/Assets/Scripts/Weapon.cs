using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

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


    private void Start()
    {
        currentammo = maxammo;
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

        if (GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().Play();
        }
        Invoke("SetFiring", fireTime);

    }

    void Update()
    {



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
