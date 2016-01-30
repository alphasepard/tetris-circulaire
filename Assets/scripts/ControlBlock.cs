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
    private Model model;
    System.Random rnd = new System.Random();
    

    public ControlBlock(Model model)
    {
        this.model = model;
    }

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
        this.x = 5;
        this.y = 0;
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
        this.x = x;
        this.y = y;
        bool down, left, right;
        int leftWide, rightWide, downWide;
        leftWide = 0;
        rightWide = 0;
        downWide = 0;
        down = model.down(this, downWide);
        left = model.left(this, leftWide);
        right = model.right(this, rightWide);
    }


	// Update is called once per frame
	void Update () {
	    
	}
}
