﻿using UnityEngine;
using System.Collections;
using UnityEditor;

public class Model : MonoBehaviour {

    public int nbLine = 14;
    public int nbColone = 10;
    public float moveSpeed = 0.4f;
    public controleurJ1 j1;
    public controleurJ2 j2;
    public GameObject doubleBlock;
    public GameObject tripleBlock1;
    public GameObject tripleBlock2;
    public float moveUnit = 0.75f;
    public float j1x0 = -11.84f;
    public float y0 = 3.64f;
    public float j2x0 = 1.09f;
    public int modifRotation = 0;
    public bool[,] blocksFixesj1;
    public bool[,] blocksFixesj2;
    public bool[,] symbole;
    public bool[,] matchingj1;
    public bool[,] matchingj2;

    private ControlBlock[] poolBlock;

    int interval = 1;
    float nextTime = 0;

    // Use this for initialization
    void Start()
    {
        poolBlock = new ControlBlock[10];

        for (int i = 0; i < 10; i++)
        {
            poolBlock[i] = new ControlBlock(this);

            poolBlock[i].model = this;
        }

        spawnJ1(0);
        spawnJ2(0);
    }

    void genereSymbole(int i)
    {
        for (int j = 0; j < 12; j++)
        {
            for (int k = 0; k < 12; k++)
            {
                symbole[j, k] = true;
            }
        }
        switch (i)
        {
            case 1:
                symbole[4, 6] = false;
                symbole[5, 5] = false;
                symbole[6, 4] = false;
                symbole[7, 4] = false;
                symbole[6, 6] = false;
                symbole[7, 6] = false;
                symbole[7, 7] = false;
                symbole[8, 7] = false;
                symbole[8, 9] = false;
                symbole[7, 9] = false;
                symbole[9, 9] = false;
                symbole[9, 8] = false;
                symbole[10, 8] = false;
                symbole[11, 8] = false;
                symbole[12, 8] = false;
                symbole[12, 7] = false;
                symbole[13, 7] = false;
                symbole[13, 6] = false;
                symbole[13, 5] = false;
                symbole[13, 4] = false;
                symbole[13, 3] = false;
                symbole[12, 4] = false;
                symbole[11, 4] = false;
                symbole[14, 3] = false;
                break;
            case 2:
                symbole[3, 6] = false;
                symbole[4, 5] = false;
                symbole[5, 4] = false;
                symbole[6, 4] = false;
                symbole[7, 4] = false;
                symbole[8, 5] = false;
                symbole[8, 7] = false;
                symbole[8, 8] = false;
                symbole[9, 8] = false;
                symbole[10, 8] = false;
                symbole[9, 6] = false;
                symbole[10, 6] = false;
                symbole[11, 7] = false;
                symbole[12, 7] = false;
                symbole[13, 8] = false;
                symbole[14, 9] = false;
                symbole[12, 6] = false;
                symbole[13, 5] = false;
                symbole[14, 4] = false;
                symbole[13, 3] = false;
                symbole[13, 2] = false;
                symbole[12, 1] = false;
                break;
            case 3:
                symbole[5, 4] = false;
                symbole[6, 5] = false;
                symbole[7, 6] = false;
                symbole[7, 7] = false;
                symbole[6, 8] = false;
                symbole[7, 9] = false;
                symbole[8, 9] = false;
                symbole[9, 8] = false;
                symbole[10, 9] = false;
                symbole[11, 8] = false;
                symbole[12, 7] = false;
                symbole[13, 6] = false;
                symbole[14, 5] = false;
                symbole[10, 7] = false;
                symbole[10, 6] = false;
                symbole[10, 5] = false;
                symbole[10, 4] = false;
                symbole[10, 3] = false;
                symbole[11, 5] = false;
                symbole[12, 4] = false;
                symbole[13, 3] = false;
                symbole[14, 2] = false;
                symbole[14, 3] = false;
                symbole[14, 4] = false;
                break;
            case 4:
                symbole[5, 2] = false;
                symbole[5, 3] = false;
                symbole[5, 4] = false;
                symbole[5, 5] = false;
                symbole[5, 6] = false;
                symbole[5, 7] = false;
                symbole[5, 8] = false;
                symbole[5, 9] = false;
                symbole[6, 9] = false;
                symbole[7, 8] = false;
                symbole[8, 7] = false;
                symbole[9, 6] = false;
                symbole[6, 10] = false;
                symbole[7, 9] = false;
                symbole[8, 8] = false;
                symbole[9, 7] = false;
                symbole[9, 2] = false;
                symbole[9, 3] = false;
                symbole[9, 4] = false;
                symbole[10, 3] = false;
                symbole[10, 5] = false;
                symbole[11, 5] = false;
                symbole[11, 4] = false;
                symbole[12, 3] = false;
                symbole[13, 2] = false;
                symbole[14, 1] = false;
                symbole[14, 2] = false;
                symbole[14, 3] = false;
                symbole[14, 4] = false;
                symbole[14, 5] = false;
                symbole[14, 6] = false;
                symbole[12, 6] = false;
                symbole[13, 7] = false;
                symbole[13, 8] = false;
                symbole[14, 8] = false;
                symbole[14, 9] = false;
                break;
        }
    }

    void spawnJ1(int i)
    {
        spawnPiece(poolBlock[i], 1);
    }

    void spawnJ2(int i)
    {
        spawnPiece(poolBlock[i], 2);
    }

    void spawnPiece(ControlBlock cb, int joueur)
    {
        float x = 0.0f, y = 0.0f;
        GameObject newPiece;
        ControlBlock newControlBlock;
        if (joueur == 1)
        {
            x = j1x0 + 6 * moveUnit;
            y = y0;
        }
        else if (joueur == 2) {
            x = j2x0 + 6 * moveUnit;
            y = y0;
        }

        if (cb.currentBlock.name.Equals(doubleBlock.name))
        {
            newPiece = (GameObject)GameObject.Instantiate(doubleBlock, new Vector3(x, y, 0), cb.currentBlock.transform.rotation);


        }
        else if(cb.currentBlock.name.Equals(tripleBlock1.name))
        {
            newPiece = (GameObject)GameObject.Instantiate(tripleBlock1, new Vector3(x, y, 0), cb.currentBlock.transform.rotation);
        }
        else
        {
            newPiece = (GameObject)GameObject.Instantiate(tripleBlock2, new Vector3(x, y, 0), cb.currentBlock.transform.rotation);
        }
        newPiece.transform.Rotate(0, 0, cb.orientation * 90);
        newControlBlock = new ControlBlock(this);
        newControlBlock.currentBlock = newPiece;
        if (joueur == 1)
        {
            j1.pieceCourante = newControlBlock;
            j1.pieceCourante.model = this;
        }
        else
        {
            j2.pieceCourante = newControlBlock;
            j2.pieceCourante.model = this;
        }
    }

    public void update_move(int j)
    {
        int x, y, o;
        if(j == 1)
        {
            x = j1.pieceCourante.x;
            y = j1.pieceCourante.y;
            o = j1.pieceCourante.orientation;
            j1.pieceCourante.currentBlock.transform.position = new Vector3(j1x0 + x * moveUnit, y0 - y * moveUnit, 0);
            j1.pieceCourante.currentBlock.transform.Rotate(0, 0, modifRotation * 90);
        }
        else
        {
            x = j2.pieceCourante.x;
            y = j2.pieceCourante.y;
            o = j2.pieceCourante.orientation;
            j2.pieceCourante.currentBlock.transform.position = new Vector3(j2x0 + x * moveUnit, y0 - y * moveUnit, 0);
            j2.pieceCourante.currentBlock.transform.Rotate(0, 0, modifRotation * 90);
        }
        modifRotation = 0;
    }

    // Update is called once per frame
    void Update () {
        if (j1.toucherLeFond)
        {
            j1.n++;
            j1.pieceCourante = poolBlock[j1.n];
            spawnJ1(j1.n);
        }

        if (j2.toucherLeFond)
        {
            j2.n++;
            j2.pieceCourante = poolBlock[j2.n];
            spawnJ2(j2.n);
        }
    } 
    public bool down(ControlBlock cb, int dw)
    {
        return true;
    }

    public bool left(ControlBlock cb, int dl)
    {
        return true;
    }

    public bool right(ControlBlock cb, int dr)
    {
        return true;
    }

    public bool up(ControlBlock cb, int du)
    {
        return true;
    }
}
