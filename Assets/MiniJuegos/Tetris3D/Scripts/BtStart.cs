using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtStart : MonoBehaviour {


  public  void onClick()
    {
        SceneManager.LoadScene("MainTetris3D");
    }
}
