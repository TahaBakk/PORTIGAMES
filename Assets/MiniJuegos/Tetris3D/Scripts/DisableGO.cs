using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableGO : MonoBehaviour {

    public GameObject obj;

    private void Start()
    {
        disable();
    }

    public void enable()
    {
        obj.SetActive( true );
    }

    public void disable()
    {
        obj.SetActive(false);
    }
}