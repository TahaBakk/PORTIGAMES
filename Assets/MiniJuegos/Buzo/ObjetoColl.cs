using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoColl : MonoBehaviour
{


    public int Bullets { get; set; }

    public void Start()
    {
        Bullets = 0;
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Bullets =  1;
            Destroy(gameObject);
        } 
}

    
}
