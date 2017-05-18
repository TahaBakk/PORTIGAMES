using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour {

    // The Grid itself
    public static int w = 10;
    public static int h = 22;
    public static Transform[,] grid = new Transform[w, h];

    // Rows deleted
    private static int rowsDel;
    // Game level
    private static int level = 0;
    // Rows counter to level increment
    private static int rowsLvl;
    // Game score
    private static int score;
    // Text del Score
    private static Text textScore = GameObject.Find("TextScore").GetComponent<Text>();
    private static Text textLvl = GameObject.Find("TextLevel").GetComponent<Text>();


    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	public static Vector3 roundVec3(Vector3 v) {
    	return new Vector3(Mathf.Round(v.x),
        	               Mathf.Round(v.y),
                           Mathf.Round(v.z));
	}

	public static bool insideBorder(Vector3 pos) {
    	return ((int)pos.x >= 0 &&
        	    (int)pos.x < w &&
    	        (int)pos.y >= 0);
	}

	public static void deleteRow(int y) {
        for (int x = 0; x < w; ++x) {
        	Destroy(grid[x, y].gameObject);
        	grid[x, y] = null;
    	}
	}

	public static void decreaseRow(int y) {
    	for (int x = 0; x < w; ++x) {
        	if (grid[x, y] != null) {
            	// Move one towards bottom
            	grid[x, y-1] = grid[x, y];
            	grid[x, y] = null;

            	// Update Block position
            	grid[x, y-1].position += new Vector3(0, -1, 0);
        	}
    	}
	}

	public static void decreaseRowsAbove(int y) {
    	for (int i = y; i < h; ++i)
    	    decreaseRow(i);
	}

	public static bool isRowFull(int y) {
    	for (int x = 0; x < w; ++x)
        	if (grid[x, y] == null)
        	    return false;
    	return true;
	}

    // Devuelve la puntuacion de las lineas eliminadas
	public static void deleteFullRows() {
        rowsDel = 0;
    	for (int y = 0; y < h; ++y) {
        	if (isRowFull(y)) {
            	deleteRow(y);
            	decreaseRowsAbove(y+1);
            	--y;
                rowsDel++;
        	}
    	}
        countScore( rowsDel );
        rowsLvl += rowsDel;
        if ( rowsLvl >= 10)
        {
            rowsLvl = 0;
            level += 1;
            textLvl.text = "Level: " + level;
        }
    }

    // Añade puntuacion en funcion de las lineas eliminadas
    private static void countScore( int rows)
    {
        int c = 0;
        switch ( rows )
        {
            case 1: c = oneLine();
                break;
            case 2: c = twoLines();
                break;
            case 3: c = threeLines();
                break;
            case 4: c = fourLines();
                break;
            default:
                break;
        }
        score += c;
        textScore.text = "Score: " + score;
    }
    // 1 linea
    private static int oneLine()
    {
        return 40 * ( level + 1);
    }
    // 2 lineas
    private static int twoLines()
    {
        return 100 * ( level + 1);
    }
    // 3 lineas
    private static int threeLines()
    {
        return 300 * ( level + 1);
    }
    // 4 lineas
    private static int fourLines()
    {
        return 1200 * ( level + 1);
    }
    public static int getLevel()
    {
        return level;
    }

    public static int getScore()
    {
        return score;
    }
}
