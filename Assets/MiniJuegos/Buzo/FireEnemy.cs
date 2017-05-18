using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEnemy : MonoBehaviour {

    public GameObject bullet;

    public float interval = 2;

    void Start()
    {
        InvokeRepeating("Fire", interval, interval);
    }

    void Fire()
    {
        GameObject g = (GameObject)Instantiate(bullet,
            transform.position,
            Quaternion.identity);

        Physics2D.IgnoreCollision(g.GetComponent<Collider2D>(),
            transform.parent.GetComponent<Collider2D>());
    }
}
