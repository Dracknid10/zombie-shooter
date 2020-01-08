using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontdestroy : MonoBehaviour
{


    private void Awake()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("music");
        if (obj.Length > 1)
        
            Destroy(this.gameObject);
        
        
        
            DontDestroyOnLoad(this.gameObject);
        
    }


}
