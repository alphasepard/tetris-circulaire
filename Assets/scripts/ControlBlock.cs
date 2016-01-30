using UnityEngine;
using System.Collections;
using System;

public class ControlBlock : MonoBehaviour {

    public int x, y;
    public GameObject currentBlock;
    public GameObject doubleBlock;
    public GameObject tripleBlock1;
    public GameObject tripleBlock2;
    public int orientation;
    System.Random rnd = new System.Random();

    // Use this for initialization
    void Start()
    {
        orientation = rnd.Next(4);
        int randomType = rnd.Next(1, 4);
        switch (randomType)
        {
            case 1:
                currentBlock = doubleBlock;
                break;
            case 2:
                currentBlock = tripleBlock1;
                break;
            case 3:
                currentBlock = tripleBlock2;
                break;
        }
    }

   public void orient(bool horaire)
    {
        if (horaire)
        {
            orientation = (orientation + 1) % 4;
        }
        else
        {
            orientation = (orientation - 1) % 4;
        }
    }


    public void move(int x, int y)
    {

    }

	// Update is called once per frame
	void Update () {
	    
	}
}
