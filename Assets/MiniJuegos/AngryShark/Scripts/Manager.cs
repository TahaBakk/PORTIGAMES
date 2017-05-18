using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Manager : MonoBehaviour {
	//public GameObject i1star1, i1star2, i1star3, i1star0;
	public GameObject i2star1, i2star2, i2star3, i2star0, boton2, bloq2;
	public Image imagen;
	//public GameObject i3star1, i3star2, i3star3, i3star0, boton3, bloq3;
	//public GameObject i4star1, i4star2, i4star3, i4star0, boton4, bloq4;
	

	public void LlamarScene (string scena)
	{
		SceneManager.LoadScene(scena);
	}

	public void desBloquearLevel (string level)
	{
		boton2.GetComponent<Button> ().interactable = true;
		imagen.enabled = false;
	}

	public void bloquearLevel ()
	{
		boton2.GetComponent<Button> ().interactable = false;
		imagen.enabled = true;
	}

	public void activarPuntuacion (int etrella)
	{
		
	}
	
}
