using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour {

    public Slider BarraVida;
    int vida;
    public static int nivel = 1;
    float speed = 2;
    int puntos;

    float force = 300;
    float forceRight = 1;

    // Use this for initialization
    void Start()
    {
        vida = 0;
        BarraVida.value = vida;
        // Fly towards the right
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }

    // Update is called once per frame
    public void Update()
    {
        BarraVida.value = vida;

        // Flap
        if (Input.GetKeyDown(KeyCode.Space))
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * force);

        if (Input.GetKeyDown(KeyCode.Q))
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * forceRight);
    }

    void Awake()
    {
        InvokeRepeating("UsingInvokeRepeat", 1f, 1f);
    }

    void UsingInvokeRepeat()
    {
        vida = vida + 10;
        BarraVida.value = vida;
        if (vida == 100)
          {    
            Application.LoadLevel(Application.loadedLevel);
          }
        }


    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.tag == "star")
        {
            nivel = nivel + 1;
            //string level = "Buzo "+nivel;
            string level = "BuzoInformacio"+nivel;
            SceneManager.LoadScene(level);
        }

        if (coll.collider.tag != "star" && coll.collider.tag != "Pacdot")
        {   
              Application.LoadLevel(Application.loadedLevel);   
        }
    }

    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.tag == "Pacdot")
        {
            puntos++;
            Destroy(co.gameObject);
            if (vida > 0)
            {
                vida = vida - 20;
            }
        }
    }

	public void saltar()
	{
		GetComponent<Rigidbody2D>().AddForce(Vector2.up * force);
	}


    }
