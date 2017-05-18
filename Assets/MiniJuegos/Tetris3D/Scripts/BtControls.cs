using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtControls : MonoBehaviour {

    public void onClick()
    {
        SceneManager.LoadScene("GuideTetris3D");
    }
}
