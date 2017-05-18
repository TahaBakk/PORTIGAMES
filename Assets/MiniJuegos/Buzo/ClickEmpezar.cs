using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClickEmpezar : MonoBehaviour {

    void Start()
    {
        
    }

	public void onClick(string  nivel)
    {
        SceneManager.LoadScene(nivel);
    }
}
