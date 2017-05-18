using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class enemigo : MonoBehaviour {

	public GameObject efectoEnemigo;

	public GameObject shark1;
	public GameObject shark2;
	public GameObject shark3;
	public GameObject panelPuntuacion;
	public GameObject star1,star2,star3,star0;
	public int stars1;



	public float health = 4f;

	public static int vidas = 0;
	//public GameObject proximo;


 	void Start() {
		vidas++;
    }

	void OnCollisionEnter2D (Collision2D colInfo)
	{
		if (colInfo.relativeVelocity.magnitude > health)
		{
			muere();
		}
	}

	void muere ()
	{
		Instantiate(efectoEnemigo, transform.position, Quaternion.identity);
		vidas--;
		Destroy(gameObject);
		if(vidas<=0)
		{//Controlar el fin de partida
			Debug.Log("Gola partida finalizada");
			//SceneManager.LoadScene("MenuLevel");
			gestionarPuntuacion();
		}

	}



    
	public void gestionarPuntuacion()
	{
		

		if(!shark1.activeSelf && shark2.activeSelf && !shark3.activeSelf)
		{
			//Time.timeScale = 0;
			Debug.Log("3 estrellas");
			panelPuntuacion.SetActive(true);
			star3.SetActive(true);
			stars1=3;

		}else if(!shark1.activeSelf && !shark2.activeSelf && shark3.activeSelf)
		{
			//Time.timeScale = 0;
			Debug.Log("2 estrellas");
			panelPuntuacion.SetActive(true);
			star2.SetActive(true);
			stars1=2;

		}else if (!shark1.activeSelf && !shark2.activeSelf && !shark3.activeSelf)
		{
			//Time.timeScale = 0;
			Debug.Log("1 estrellas");
			panelPuntuacion.SetActive(true);
			star1.SetActive(true);
			stars1=1;
		
		}else{
			Debug.Log("1 estrellas");
			panelPuntuacion.SetActive(true);
			star1.SetActive(true);
			stars1=1;
		}

	}

}
