using UnityEngine;
using System.Collections;
using System;

public class ControlBlock : MonoBehaviour {

    public int x, y;
    public GameObject type;
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
                type = doubleBlock;
                break;
            case 2:
                type = tripleBlock1;
                break;
            case 3:
                type = tripleBlock2;
                break;
        }
    }

    void orient(bool horaire)
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

<<<<<<< HEAD
=======

>>>>>>> 0c3e911c36d44eb691740f6d1a4faa35113d97bb
    void move(int x, int y)
    {

    }

	// Update is called once per frame
	void Update () {
	    
	}
}
