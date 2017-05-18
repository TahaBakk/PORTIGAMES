using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour {

	public GameObject[] groups;

    private GameObject obj;

    private float x;
    private float y;

    private int i;
    // Use this for initialization
    void Start () {

        create();
		spawnNext();
		
	}

    public void create()
    {
        i = Random.Range(0, groups.Length);
    }

	public void spawnNext() {
        obj = groups[i];

        if ( obj.name == "Igroup"){

            x = -0.5f;

            setXPosition(x);
            instantiate();
            resetXPosition(x);
        }else if ( obj.name == "Lgroup" )
        {
            x = 0.5f;

            setXPosition(x);
            instantiate();
            resetXPosition(x);
        }else if ( obj.name == "Jgroup" )
        {
            x = -0.5f;

            setXPosition(x);
            instantiate();
            resetXPosition(x);
        }else if ( obj.name == "Sgroup" )
        {
            x = -0.5f;

            setXPosition(x);
            instantiate();
            resetXPosition(x);
        }else if ( obj.name == "Zgroup")
        {
            x = 0.5f;

            setXPosition(x);
            instantiate();
            resetXPosition(x);
        }
        else if (obj.name == "Tgroup")
        {
            x = 0.5f;

            setXPosition(x);
            instantiate();
            resetXPosition(x);
        }else       //Ogroup
        {
            x = -0.5f;

            setXPosition(x);
            instantiate();
            resetXPosition(x);

		}

        create();
        FindObjectOfType<NextSpawn>().nextSpawn( groups[i].name );
    }

    private void instantiate()
    {
       GameObject aux = Instantiate(obj,
            transform.position,
            Quaternion.identity);
    }

    private void setXPosition(float f)
    {
        Vector3 temp = transform.position; // copy to an auxiliary variable...
        temp.x = temp.x + f; // modify the component you want in the variable...
        transform.position = temp; // and save the modified value 
    }

    private void resetXPosition(float f)
    {
        Vector3 temp = transform.position; // copy to an auxiliary variable...
        temp.x = temp.x - f; // modify the component you want in the variable...
        transform.position = temp; // and save the modified value 
    }
}
