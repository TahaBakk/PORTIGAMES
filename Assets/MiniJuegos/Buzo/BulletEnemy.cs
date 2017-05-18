using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }

        if (coll.gameObject.tag == "Player")
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
