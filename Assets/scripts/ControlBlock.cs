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
        if (espaceDispo(0, 0, sens, j)){
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
        if (espaceDispo(x, y, 0, j)) {
            this.x = this.x + x;
            this.y = this.y + y;
            notify(j);
        }
        return (!espaceDispo(x, y, 0, j));
    }

    public bool espaceDispo(int dx, int dy, int sens, int j)
    {
        Point[] res = new Point[3];
        if ((currentBlock.name.Equals(model.tripleBlock1.name+"(Clone)")) || (currentBlock.name.Equals(model.tripleBlock2.name + "(Clone)")))
        {
            switch ((orientation + sens)%4)
            {
                case 0:
                case 2:
                    res[0] = new Point(y+1, x);
                    res[1] = new Point(y-1, x);
                    res[2] = new Point(y  , x);
                    break;
                case 1:
                case 3:
                    res[0] = new Point(y, x+1);
                    res[1] = new Point(y, x-1);
                    res[2] = new Point(y, x  );
                    break;
            }
        }
        else if (currentBlock.name.Equals(model.doubleBlock.name + "(Clone)"))
        {
            switch ((orientation + sens)%4)
            {
                case 0:
                    res[0] = new Point(y+1, x);
                    res[1] = new Point(y  , x);
                    Array.Resize(ref res, 2);
                    break;
                case 1:
                    res[0] = new Point(y, x-1);
                    res[1] = new Point(y, x  );
                    Array.Resize(ref res, 2);
                    break;
                case 2:
                    res[0] = new Point(y-1, x);
                    res[1] = new Point(y  , x);
                    Array.Resize(ref res, 2);
                    break;
                case 3:
                    res[0] = new Point(y, x+1);
                    res[1] = new Point(y, x  );
                    Array.Resize(ref res, 2);
                    break;
            }
        }
        if (dx > 0)
        {
            return model.dep(res, 'd', j);
        }
        else if (dx < 0)
        {
            return model.dep(res, 'g', j);
        }
        else if (dy > 0)
        {
            return model.dep(res, 'b', j);
        }
        else if (sens != 0)
        {
            return model.dep(res, 'r', j);
        }
        else return true;
    }

}
