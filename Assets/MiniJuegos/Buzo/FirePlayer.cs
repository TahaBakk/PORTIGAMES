using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FirePlayer : MonoBehaviour {

    public GameObject bullet;
    public ObjetoColl obc = new ObjetoColl();
    public static int boll;
    
    // Use this for initialization
    void Start()
    {
        boll = 0;
    
    }

    // Update is called once per frame
    void Update()
    {
        boll = obc.Bullets;
        if (boll == 1) {
            if (Input.GetKeyDown(KeyCode.R))
            {
                GameObject g = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);

                Physics2D.IgnoreCollision(g.GetComponent<Collider2D>(), transform.parent.GetComponent<Collider2D>());
            }
        }
    }


	public void shot()
	{
		GameObject g = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);
		Physics2D.IgnoreCollision(g.GetComponent<Collider2D>(), transform.parent.GetComponent<Collider2D>());
	}

}
