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
        int sens = 0;
        if (horaire) sens = 1;
        else sens = -1;
        if (espaceDispo(0, 0, sens)){
            if (horaire)
            {
                orientation = (orientation + 1) % 4;
            }
            else {
                orientation = (orientation - 1) % 4;
            }
        }
    }

    public void move(int x, int y)
    {
        if (espaceDispo(x, y, 0)) {
            this.x += x;
            this.y += y;
        }
    }

    public bool espaceDispo(int x, int y, int sens)
    {
        bool down, left, right, up;
        int leftWide, rightWide, downWide, upWide;
        this.x = x;
        this.y = y;
        leftWide = 0;
        rightWide = 0;
        downWide = 0;
        upWide = 0;
        if (currentBlock.name.Equals(tripleBlock1.name))
        {
            switch ((orientation+sens)%4)
            {
                case 0:
                    downWide = 2;
                    break;
                case 1:
                    leftWide = 2;
                    break;
                case 2:
                    upWide = 2;
                    break;
                case 3:
                    rightWide = 2;
                    break;
            }
        }
        else if (currentBlock.name.Equals(tripleBlock2.name))
        {
            switch ((orientation + sens) % 4)
            {
                case 0:
                case 2:
                    upWide = 1;
                    downWide = 1;
                    break;
                case 1:
                case 3:
                    upWide = 1;
                    downWide = 1;
                    break;
            }
        }
        else if (currentBlock.name.Equals(doubleBlock.name))
        {
            switch ((orientation + sens) % 4)
            {
                case 0:
                    downWide = 2;
                    break;
                case 1:
                    leftWide = 2;
                    break;
                case 2:
                    upWide = 2;
                    break;
                case 3:
                    rightWide = 2;
                    break;
            }
        }
        down = model.down(this, downWide);
        left = model.left(this, leftWide);
        right = model.right(this, rightWide);
        up = model.up(this, upWide);
        if (x > 0)
            return right && down && up;
        else if (x > 0)
            return left && down && up;
        else if (y > 0)
            return down && left && right;
        else if (sens != 0)
            return up && down && left && right;
        else return false;
    }

	// Update is called once per frame
	void Update () {
	    
	}
}
