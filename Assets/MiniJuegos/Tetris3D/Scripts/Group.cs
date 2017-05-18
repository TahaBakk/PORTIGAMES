using System;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;
using UnityEngine.UI;

public class Group : MonoBehaviour {

	// Time since last gravity tick
	public float lastFall = 0;
    private float speed = 0.1f;
    private bool horizontalAxisInUse = false;
    private bool verticalAxisInUse = false;

    // Use this for initialization
    void Start () {
		if (!isValidGridPos()) {
       		Debug.Log("GAME OVER");
        	Destroy(gameObject);

            FindObjectOfType<DisableGO>().enable();

            Text cts = GameObject.Find("Canvas/GameObjectOver/CanvasTextScore").GetComponent<Text>();
            cts.text = Grid.getScore().ToString();
            //FbScore.saveScore( Grid.getScore() );
            //FbScore.getScore();
        }
    }

    // Update is called once per frame

    public void moveLeft()
    {
        // Modify position
        transform.position += new Vector3(-1, 0, 0);

        // See if valid
        if (isValidGridPos())
            // It's valid. Update grid.
            updateGrid();
        else
            // It's not valid. revert.
            transform.position += new Vector3(1, 0, 0);
    }

    public void moveRight()
    {
        // Modify position
        transform.position += new Vector3(1, 0, 0);

        // See if valid
        if (isValidGridPos())
            // It's valid. Update grid.
            updateGrid();
        else
            // It's not valid. revert.
            transform.position += new Vector3(-1, 0, 0);
    }

    public void rotate() {
        if (gameObject.name == "Igroup(Clone)")
        {

            if (transform.rotation.z == 0)
            {

                transform.Rotate(0, 0, 90);

                // See if valid
                if (isValidGridPos())
                    // It's valid. Update grid.
                    updateGrid();
                else
                    // It's not valid. revert.
                    transform.Rotate(0, 0, -90);

            }
            else
            {
                transform.Rotate(0, 0, 270);

                // See if valid
                if (isValidGridPos())
                    // It's valid. Update grid.
                    updateGrid();
                else
                    // It's not valid. revert.
                    transform.Rotate(0, 0, -270);
            }

        }
        else if (gameObject.name == "Sgroup(Clone)")
        {

            if (transform.rotation.z == 0)
            {
                transform.Rotate(0, 0, -90);

                // See if valid
                if (isValidGridPos())
                    // It's valid. Update grid.
                    updateGrid();
                else
                    // It's not valid. revert.
                    transform.Rotate(0, 0, 90);
            }
            else
            {
                transform.Rotate(0, 0, -270);

                // See if valid
                if (isValidGridPos())
                    // It's valid. Update grid.
                    updateGrid();
                else
                    // It's not valid. revert.
                    transform.Rotate(0, 0, 270);
            }

        }
        else if (gameObject.name == "Zgroup(Clone)")
        {

            if (transform.rotation.z == 0)
            {
                transform.Rotate(0, 0, 90);

                // See if valid
                if (isValidGridPos())
                    // It's valid. Update grid.
                    updateGrid();
                else
                    // It's not valid. revert.
                    transform.Rotate(0, 0, -90);
            }
            else
            {
                transform.Rotate(0, 0, 270);

                // See if valid
                if (isValidGridPos())
                    // It's valid. Update grid.
                    updateGrid();
                else
                    // It's not valid. revert.
                    transform.Rotate(0, 0, -270);
            }

        }
        else if (gameObject.name == "Lgroup(Clone)" ||
            gameObject.name == "Jgroup(Clone)" ||
            gameObject.name == "Tgroup(Clone)")
        {

            transform.Rotate(0, 0, -90);

            // See if valid
            if (isValidGridPos())
                // It's valid. Update grid.
                updateGrid();
            else
                // It's not valid. revert.
                transform.Rotate(0, 0, 90);

        }
    }


    public void moveDown()
    {
        // Modify position
        transform.position += new Vector3(0, -1, 0);

        // See if valid
        if (isValidGridPos())
        {

            // It's valid. Update grid.
            updateGrid();
        }
        else
        {
            // It's not valid. revert.
            transform.position += new Vector3(0, 1, 0);

            // Clear filled horizontal lines
            Grid.deleteFullRows();

            // Spawn next Group
            FindObjectOfType<Spawner>().spawnNext();

            // Disable script
            enabled = false;
        }
        int x = Grid.getLevel();
        lastFall = Time.time - (speed * x);
    }


    void Update() {

        float horiz = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");

        if (horiz < 0 && horizontalAxisInUse == false) { 
                horizontalAxisInUse = true;
                moveLeft();
        } else if (horiz > 0 && horizontalAxisInUse == false)
        {
                horizontalAxisInUse = true;
                moveRight();
        } else  if (horiz == 0) {
            horizontalAxisInUse = false;
        }
        if (vert > 0 && verticalAxisInUse == false)
        {
            verticalAxisInUse = true;
            rotate();
        }
        else if (vert < 0 && verticalAxisInUse == false)
        {
            verticalAxisInUse = true;
            moveDown();
        }
        else if (vert == 0)
        {
            verticalAxisInUse = false;
        }

       if (Time.time - lastFall >= 1)
        {
            moveDown();
        }
	}


    bool isValidGridPos() {        
    	foreach (Transform child in transform) {
        	Vector3 v = Grid.roundVec3(child.position);

        	// Not inside Border?
        	if (!Grid.insideBorder(v))
            	return false;

            // Block in grid cell (and not part of same group)?
            if (Grid.grid[(int)v.x, (int)v.y] != null &&
            	Grid.grid[(int)v.x, (int)v.y].parent != transform)
        	    return false;
    	}
    	return true;
	}

	void updateGrid() {
    	// Remove old children from grid
    	for (int y = 0; y < Grid.h; ++y)
        	for (int x = 0; x < Grid.w; ++x)
            	if (Grid.grid[x, y] != null)
                	if (Grid.grid[x, y].parent == transform)
                    	Grid.grid[x, y] = null;

    	// Add new children to grid
    	foreach (Transform child in transform) {
        	Vector2 v = Grid.roundVec3(child.position);
        	Grid.grid[(int)v.x, (int)v.y] = child;
    	}
	}
}