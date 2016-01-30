using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Model))]
public class ControlBlock {

    public int x, y;
    public GameObject currentBlock;
    public int orientation;
    public Model model;
    static System.Random rnd = new System.Random();

    // Use this for initialization
    public ControlBlock(Model m)
    {
        model = m;
        orientation = rnd.Next(4);
        int randomType = rnd.Next(1, 4);
        //Debug.Log(randomType);
        switch (randomType)
        {
            case 1:
                currentBlock = model.doubleBlock;
                break;
            case 2:
                currentBlock = model.tripleBlock1;
                break;
            case 3:
                currentBlock = model.tripleBlock2;
                break;
        }
        this.x = 6;
        this.y = 0;
    }

   public void orient(bool horaire, int j)
    {
        int sens = 0;
        if (horaire) sens = 1;
        else sens = -1;
        if (espaceDispo(0, 0, sens)){
            if (horaire)
            {
                orientation = (orientation + 1) % 4;
                model.modifRotation = 1;
            }
            else {
                orientation = (orientation - 1) % 4;
                model.modifRotation = -1;
            }
            notify(j);
        }
    }

    public void notify(int j)
    {
        model.update_move(j);
    }

    public bool move(int x, int y, int j)
    {
        if (espaceDispo(x, y, 0)) {
            this.x = this.x + x;
            this.y = this.y + y;
            notify(j);
        }
        return (!espaceDispo(x, y, 0) & y > 0);
    }

    public bool espaceDispo(int x, int y, int sens)
    {
        /*bool down, left, right, up;
        int leftWide, rightWide, downWide, upWide;
        leftWide = 0;
        rightWide = 0;
        downWide = 0;
        upWide = 0;
        if (currentBlock.name.Equals(model.tripleBlock1.name))
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
        else if (currentBlock.name.Equals(model.tripleBlock2.name))
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
        else if (currentBlock.name.Equals(model.doubleBlock.name))
        {
            switch ((orientation + sens) % 4)
            {
                case 0:
                    downWide = 1;
                    break;
                case 1:
                    leftWide = 1;
                    break;
                case 2:
                    upWide = 1;
                    break;
                case 3:
                    rightWide = 1;
                    break;
            }
        }
        down = model.down(this, downWide);
        left = model.left(this, leftWide);
        right = model.right(this, rightWide);
        up = model.up(this, upWide);
        if (x > 0)
            return (true);
        else if (x > 0)
            return (true);
        else if (y > 0)
            return (true);
        else if (sens != 0)
            return (true);
        else return true;*/
        return true;
    }

}
