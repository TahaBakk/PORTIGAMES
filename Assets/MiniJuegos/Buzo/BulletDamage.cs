using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag != "enemy")
        {
            Destroy(gameObject);
        }


       if(coll.gameObject.tag == "enemy")
        {
            Destroy(coll.gameObject);
        }

       
    }
}
