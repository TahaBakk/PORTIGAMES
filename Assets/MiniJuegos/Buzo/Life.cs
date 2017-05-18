using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour {


    public Slider BarraVida;
    public int vida = 100;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void Update () {
        BarraVida.value = vida;
	}
}
