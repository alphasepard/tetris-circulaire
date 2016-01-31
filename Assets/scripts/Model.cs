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
    public float moveUnit = 1f;
    public float j1x0 = 0.5f;
    public float y0 = -1.5f;
    public float j2x0 = 16.33f;
    public int modifRotation = 0;
    public bool[,] blocksFixesj1;
    public bool[,] symbolej1;
    public bool[,] blocksFixesj2;
    public bool[,] symbolej2;

    private ControlBlock[] poolBlock;

    public GameObject runej1, runej2;
    public GameObject sideRune1j1, sideRune2j1, sideRune3j1, sideRune4j1;
    public GameObject sideRune1j2, sideRune2j2, sideRune3j2, sideRune4j2;
    public int cmpRJ1 = 0 , cmpRJ2 = 0;
    Sprite runeEau, runeFeu, runeTerre, runeNuit;
    Sprite runeEauS, runeFeuS, runeTerreS, runeNuitS;
    Sprite runeEau1VS, runeFeu1VS, runeTerre1VS, runeNuit1VS;
    Sprite runeEau2VS, runeFeu2VS, runeTerre2VS, runeNuit2VS;
    public Sprite[] runesTab;
    public Sprite[] sideRunesTabJ1;
    public Sprite[] sideRunesVTabJ1;
    public Sprite[] sideRunesTabJ2;
    public Sprite[] sideRunesVTabJ2;

    int interval = 1;
    float nextTime = 0;
    

    // Use this for initialization
    void Start()
    {
        runej1.AddComponent<SpriteRenderer>();
        runej2.AddComponent<SpriteRenderer>();
        sideRune1j1.AddComponent<SpriteRenderer>();
        sideRune2j1.AddComponent<SpriteRenderer>();
        sideRune3j1.AddComponent<SpriteRenderer>();
        sideRune4j1.AddComponent<SpriteRenderer>();
        sideRune1j2.AddComponent<SpriteRenderer>();
        sideRune2j2.AddComponent<SpriteRenderer>();
        sideRune3j2.AddComponent<SpriteRenderer>();
        sideRune4j2.AddComponent<SpriteRenderer>();

        runeEau = Resources.Load<Sprite>("runeEau");
        runeFeu = Resources.Load<Sprite>("runeFeu");
        runeTerre = Resources.Load<Sprite>("runeTerre");
        runeNuit = Resources.Load<Sprite>("runeNuit");

        runeEauS = Resources.Load<Sprite>("RuneEauS");
        runeFeuS = Resources.Load<Sprite>("RuneFeuS");
        runeTerreS = Resources.Load<Sprite>("RuneTerreS");
        runeNuitS = Resources.Load<Sprite>("RuneNuitS");

        runeEau1VS = Resources.Load<Sprite>("runeEau1VS");
        runeFeu1VS = Resources.Load<Sprite>("runeFeu1VS");
        runeTerre1VS = Resources.Load<Sprite>("runeTerre1VS");
        runeNuit1VS = Resources.Load<Sprite>("runeNuit1VS");

        runeEau2VS = Resources.Load<Sprite>("runeEau2VS");
        runeFeu2VS = Resources.Load<Sprite>("runeFeu2VS");
        runeTerre2VS = Resources.Load<Sprite>("runeTerre2VS");
        runeNuit2VS = Resources.Load<Sprite>("runeNuit2VS");

        //arrangement "aléatoire" des 4 runes dans runesTab
        runesTab = new Sprite[4];
        sideRunesTabJ1 = new Sprite[4];
        sideRunesVTabJ1 = new Sprite[4];
        sideRunesTabJ2 = new Sprite[4];
        sideRunesVTabJ2 = new Sprite[4];
        System.Random rnd = new System.Random();
        int x = rnd.Next(0, 4);

        switch (x)
        {
            case 0:
                runesTab[0] = runeNuit;
                runesTab[1] = runeEau;
                runesTab[2] = runeFeu;
                runesTab[3] = runeTerre;

                sideRunesTabJ1[0] = runeNuitS;
                sideRunesTabJ1[1] = runeEauS;
                sideRunesTabJ1[2] = runeFeuS;
                sideRunesTabJ1[3] = runeTerreS;
                sideRunesVTabJ1[0] = runeNuit1VS;
                sideRunesVTabJ1[1] = runeEau1VS;
                sideRunesVTabJ1[2] = runeFeu1VS;
                sideRunesVTabJ1[3] = runeTerre1VS;

                sideRunesTabJ2[0] = runeNuitS;
                sideRunesTabJ2[1] = runeEauS;
                sideRunesTabJ2[2] = runeFeuS;
                sideRunesTabJ2[3] = runeTerreS;
                sideRunesVTabJ2[0] = runeNuit2VS;
                sideRunesVTabJ2[1] = runeEau2VS;
                sideRunesVTabJ2[2] = runeFeu2VS;
                sideRunesVTabJ2[3] = runeTerre2VS;
                break;
            case 1:
                runesTab[0] = runeEau;
                runesTab[1] = runeFeu;
                runesTab[2] = runeNuit;
                runesTab[3] = runeTerre;

                sideRunesTabJ1[0] = runeEauS;
                sideRunesTabJ1[1] = runeFeuS;
                sideRunesTabJ1[2] = runeNuitS;
                sideRunesTabJ1[3] = runeTerreS;
                sideRunesVTabJ1[0] = runeEau1VS;
                sideRunesVTabJ1[1] = runeFeu1VS;
                sideRunesVTabJ1[2] = runeNuit1VS;
                sideRunesVTabJ1[3] = runeTerre1VS;

                sideRunesTabJ2[0] = runeEauS;
                sideRunesTabJ2[1] = runeFeuS;
                sideRunesTabJ2[2] = runeNuitS;
                sideRunesTabJ2[3] = runeTerreS;
                sideRunesVTabJ2[0] = runeEau2VS;
                sideRunesVTabJ2[1] = runeFeu2VS;
                sideRunesVTabJ2[2] = runeNuit2VS;
                sideRunesVTabJ2[3] = runeTerre2VS;
                break;
            case 2:
                runesTab[0] = runeTerre;
                runesTab[1] = runeNuit;
                runesTab[2] = runeEau;
                runesTab[3] = runeFeu;

                sideRunesTabJ1[0] = runeTerreS;
                sideRunesTabJ1[1] = runeNuitS;
                sideRunesTabJ1[2] = runeEauS;
                sideRunesTabJ1[3] = runeFeuS;
                sideRunesVTabJ1[0] = runeTerre1VS;
                sideRunesVTabJ1[1] = runeNuit1VS;
                sideRunesVTabJ1[2] = runeEau1VS;
                sideRunesVTabJ1[3] = runeFeu1VS;

                sideRunesTabJ2[0] = runeTerreS;
                sideRunesTabJ2[1] = runeNuitS;
                sideRunesTabJ2[2] = runeEauS;
                sideRunesTabJ2[3] = runeFeuS;
                sideRunesVTabJ2[0] = runeTerre2VS;
                sideRunesVTabJ2[1] = runeNuit2VS;
                sideRunesVTabJ2[2] = runeEau2VS;
                sideRunesVTabJ2[3] = runeFeu2VS;
                break;
            case 3:
                runesTab[0] = runeFeu;
                runesTab[1] = runeTerre;
                runesTab[2] = runeEau;
                runesTab[3] = runeNuit;

                sideRunesTabJ1[0] = runeFeuS;
                sideRunesTabJ1[1] = runeTerreS;
                sideRunesTabJ1[2] = runeEauS;
                sideRunesTabJ1[3] = runeNuitS;
                sideRunesVTabJ1[0] = runeFeu1VS;
                sideRunesVTabJ1[1] = runeTerre1VS;
                sideRunesVTabJ1[2] = runeEau1VS;
                sideRunesVTabJ1[3] = runeNuit1VS;

                sideRunesTabJ2[0] = runeFeuS;
                sideRunesTabJ2[1] = runeTerreS;
                sideRunesTabJ2[2] = runeEauS;
                sideRunesTabJ2[3] = runeNuitS;
                sideRunesVTabJ2[0] = runeFeu2VS;
                sideRunesVTabJ2[1] = runeTerre2VS;
                sideRunesVTabJ2[2] = runeEau2VS;
                sideRunesVTabJ2[3] = runeNuit2VS;
                break;

        }

        genereSymbole(1,1);
        genereSymbole(1,2);

        runej1.GetComponent<SpriteRenderer>().sprite = runesTab[cmpRJ1];
        sideRune1j1.GetComponent<SpriteRenderer>().sprite = sideRunesTabJ1[cmpRJ1];
        sideRune2j1.GetComponent<SpriteRenderer>().sprite = sideRunesTabJ1[cmpRJ1+1];
        sideRune3j1.GetComponent<SpriteRenderer>().sprite = sideRunesTabJ1[cmpRJ1+2];
        sideRune4j1.GetComponent<SpriteRenderer>().sprite = sideRunesTabJ1[cmpRJ1+3];

        runej2.GetComponent<SpriteRenderer>().sprite = runesTab[cmpRJ2];
        sideRune1j2.GetComponent<SpriteRenderer>().sprite = sideRunesTabJ2[cmpRJ2];
        sideRune2j2.GetComponent<SpriteRenderer>().sprite = sideRunesTabJ2[cmpRJ2 + 1];
        sideRune3j2.GetComponent<SpriteRenderer>().sprite = sideRunesTabJ2[cmpRJ2 + 2];
        sideRune4j2.GetComponent<SpriteRenderer>().sprite = sideRunesTabJ2[cmpRJ2 + 3];

        //charger dans la matrice de match avec le .name

        poolBlock = new ControlBlock[100];

        for (int i = 0; i < 100; i++)
        {
            poolBlock[i] = new ControlBlock(this);

            poolBlock[i].model = this;
        }

        blocksFixesj1 = new bool[12,16];
        blocksFixesj2 = new bool[12,16];
        symbolej1 = new bool[12, 16];
        symbolej2 = new bool[12, 16];

        for (int i = 0; i < 12; i++)
            for (int j = 0; j < 16; j++)
            {
                blocksFixesj1[i, j] = false;
                blocksFixesj2[i, j] = false;
            }

        spawnJ1(0);
        spawnJ2(0);
    }

    public bool estFinieJ1() {
        for (int i=0; i<12; i++)
        {
            for (int j = 0; j < 16; j++)
            {
                if (!symbolej1[i,j]) { return false; }
            }
        }
        return true;
    }

    public bool estFinieJ2()
    {
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 16; j++)
            {
                if (!symbolej2[i, j]) { return false; }
            }
        }
        return true;
    }

    public void passerRuneJ1()
    {
        runej1.GetComponent<SpriteRenderer>().sprite = runesTab[cmpRJ1];
        sideRune1j1.GetComponent<SpriteRenderer>().sprite = sideRunesVTabJ1[cmpRJ1-1];
        //changer la miniature
    }
    public void passerRuneJ2()
    {
        runej2.GetComponent<SpriteRenderer>().sprite = runesTab[cmpRJ2];
        sideRune1j2.GetComponent<SpriteRenderer>().sprite = sideRunesVTabJ2[cmpRJ2 - 1];
    }

    void genereSymbole(int i, int joueur)
    {
        bool[,] symbole = new bool[16, 12];
        for (int j = 0; j < 16; j++)
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
        if(joueur == 1)
        {
            symbolej1 = symbole;
        }
        else
        {
            symbolej2 = symbole;
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
            Debug.Log(moveUnit);
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

        if (estFinieJ1())
        {
            cmpRJ1++;
            if (cmpRJ1 >= 4)
            {
                //victoryJ1();
            }
            else {
                passerRuneJ1();
            }
        }
        if (estFinieJ2())
        {
            cmpRJ2++;
            if (cmpRJ2 >= 4)
            {
                //victoryJ2();
            }
            else {
                passerRuneJ2();
            }
        }

        if (j1.toucherLeFond)
        {
            j1.n++;
            j1.pieceCourante = poolBlock[j1.n];
            spawnJ1(j1.n);
            j1.toucherLeFond = false;
        }

        if (j2.toucherLeFond)
        {
            j2.n++;
            j2.pieceCourante = poolBlock[j2.n];
            spawnJ2(j2.n);
            j2.toucherLeFond = false;
        }
    } 
    
    public bool dep(Point[] piece, char dir, int j)
    {
        bool[,] tmp = (j == 1) ? blocksFixesj1 : blocksFixesj2;
        int i = 0;
        switch (dir)
        {
            case 'd':
                for (i = 0;i<piece.Length; i++)
                {
                    if (piece[i].v2 >= 11)
                        return false;
                    if (tmp[piece[i].v2+1,piece[i].v1] == true)
                        return false;
                }
                break;
            case 'g':
                for (i = 0; i<piece.Length; i++)
                {
                    if (piece[i].v2 <= 0)
                        return false;
                    if (tmp[piece[i].v2-1,piece[i].v1] == true)
                        return false;
                }
                break;
            case 'b':
                for (i = 0; i<piece.Length; i++)
                {
                    if (piece[i].v1 > 15)
                        return false;
                    if (tmp[piece[i].v2,piece[i].v1+1] == true)
                        return false;
                }
                break;
            case 'r':
                for (i = 0; i < piece.Length; i++)
                {
                    if (tmp[piece[i].v2, piece[i].v1] == true)
                        return false;
                }
                break;
        }
        return true;
    }
}
