using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSpawn : MonoBehaviour {

    public GameObject[] groups;

    private GameObject aux;
    private GameObject obj;

	// Use this for initialization
	void Start () {
		
	}
	

    public void nextSpawn( string name )
    {
        destroy();
        foreach ( GameObject g in groups)
        {
            string str = g.name.Substring( 0, g.name.Length -4);
            if ( str.Equals( name ) )
            {
                obj = g;
                print("nextspawn" + str );

                switch (str)
                {

                    case "Igroup": setI();
                        break;
                    case "Tgroup":
                    case "Lgroup":
                    case "Jgroup": setJLT();
                        break;
                    case "Zgroup": setZ();
                        break;
                    case "Sgroup":
                    case "Ogroup": instantiate();
                        break;
                    default:
                        break;
                }
            }
        }
    }
    
    void instantiate()
    {
        aux = Instantiate(obj,
     transform.position,
     Quaternion.identity);
    }

    void destroy()
    {
        Destroy( aux );
    }

    private void setI()
    {
        float y = 1f;
        setYPosition(y);
        instantiate();
        resetYPosition(y);
    }

    private void setZ()
    {
        float x = 1f;
        setXPosition(x);
        instantiate();
        resetXPosition(x);
    }

    private void setJLT()
    {
        float y = 1f;
        float x = 0.5f;
        setXPosition(x);
        setYPosition(y);
        instantiate();
        resetXPosition(x);
        resetYPosition(y);
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

    private void setYPosition(float f)
    {
        Vector3 temp = transform.position; // copy to an auxiliary variable...
        temp.y = temp.y + f; // modify the component you want in the variable...
        transform.position = temp; // and save the modified value 
    }

    private void resetYPosition(float f)
    {
        Vector3 temp = transform.position; // copy to an auxiliary variable...
        temp.y = temp.y - f; // modify the component you want in the variable...
        transform.position = temp; // and save the modified value 
    }
}
