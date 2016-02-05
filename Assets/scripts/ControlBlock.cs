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
        else sens = 3;
        if (espaceDispo(0, 0, sens, j)){
            if (horaire)
            {
                orientation = (orientation + 1) % 4;
                model.modifRotation = sens;
            }
            else {
                orientation = (orientation + 3) % 4;
                model.modifRotation = sens;
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
        bool found = false;
        int tmp_o = orientation;
        Point[] res = new Point[3];
        if ((currentBlock.name.Equals(model.tripleBlock1.name+"(Clone)")) || (currentBlock.name.Equals(model.tripleBlock2.name + "(Clone)")))
        {
            switch ((tmp_o + sens)%4)
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
            switch ((tmp_o + sens)%4)
            {
                case 0:
                    res[0] = new Point(y+1, x);
                    res[1] = new Point(y  , x);
                    Array.Resize(ref res, 2);
                    break;
                case 1:
                    res[0] = new Point(y, x+1);
                    res[1] = new Point(y, x  );
                    Array.Resize(ref res, 2);
                    break;
                case 2:
                    res[0] = new Point(y-1, x);
                    res[1] = new Point(y  , x);
                    Array.Resize(ref res, 2);
                    break;
                case 3:
                    res[0] = new Point(y, x-1);
                    res[1] = new Point(y, x  );
                    Array.Resize(ref res, 2);
                    break;
            }
        }
        if (currentBlock.name.Equals(model.tripleBlock2.name + "(Clone)"))
        {
            switch (orientation)
            {
                case 0:
                case 1:
                    res[0].colored = true;
                    break;
                case 2:
                case 3:
                    res[1].colored = true;
                    break;
            }
        }
        else if (currentBlock.name.Equals(model.tripleBlock1.name + "(Clone)"))
        {
            res[2].colored = true;
        }
        else if (currentBlock.name.Equals(model.doubleBlock.name + "(Clone)"))
        {
            res[1].colored = true;
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
            bool tmp = model.dep(res, 'b', j);
            if (!tmp)
            {
                if (j == 1)
                {
                    foreach (Point stuck in res)
                    {
                        if (model.enHaut(j))
                        {
                            clearSide(j);
                            model.redoSymbole(j);
                            return false;
                        }
                        else if (!(model.symbolej1[stuck.x, stuck.y]) & !(stuck.colored))
                        {
                            clearSide(j);
                            model.redoSymbole(j);
                            return false;
                        }
                        else if (!(model.symbolej1[stuck.x, stuck.y]) & stuck.colored)
                        {
                            model.symbolej1[stuck.x, stuck.y] = true;
                            model.soundMatch.GetComponent<AudioSource>().Play();
                            model.blocksFixesj1[stuck.x, stuck.y] = true;
                            found = true;
                        }
                        else
                        {
                            model.blocksFixesj1[stuck.x, stuck.y] = true;
                        }
                    }
                    
                }
                else
                {
                    foreach (Point stuck in res)
                    {
                        if (model.enHaut(j))
                        {
                            clearSide(j);
                            model.redoSymbole(j);
                            return false;
                        }
                        else if (!(model.symbolej2[stuck.x, stuck.y]) & !(stuck.colored))
                        {
                            clearSide(j);
                            model.redoSymbole(j);
                            return false;
                        }
                        else if (!(model.symbolej2[stuck.x, stuck.y]) & stuck.colored)
                        {
                            model.symbolej2[stuck.x, stuck.y] = true;
                            model.soundMatch.GetComponent<AudioSource>().Play();
                            model.blocksFixesj2[stuck.x, stuck.y] = true;
                            found = true;
                        }
                        else
                        {
                            model.blocksFixesj2[stuck.x, stuck.y] = true;
                        }
                    }
                }
                if (!found)
                    currentBlock.GetComponent<SpriteRenderer>().sprite = (res.Length == 2) ? model.empty2.GetComponent<SpriteRenderer>().sprite : model.empty3.GetComponent<SpriteRenderer>().sprite;
            }
            return tmp;
        }
        else if (sens != 0)
        {
            return model.dep(res, 'r', j);
        }
        else return true;
    }

    public void clearSide(int j) {
        model.clear.GetComponent<AudioSource>().Play();
        for (int i = 0; i < 12; i++)
        {
            for (int k = 0; k < 16; k++)
            {
                if (j == 1)
                    model.blocksFixesj1[i, k] = false;
                else
                    model.blocksFixesj2[i, k] = false;
            }
        }
        GameObject[] toBreak = GameObject.FindGameObjectsWithTag("j" + j);
        foreach (GameObject go in toBreak)
        {
            go.transform.tag = "dead";
        }
        GameObject[] kill = GameObject.FindGameObjectsWithTag("dead");
        foreach (GameObject dead in kill)
        {
            dead.AddComponent<Rigidbody2D>();
            dead.GetComponent<Rigidbody2D>().gravityScale = 5;
            GameObject.Destroy(dead, 5.0f);
        }
    }
}
