using UnityEngine;
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
    public bool down(ControlBlock cb, int dw)
    {
        return (cb.y+dw < 15);
    }

    public bool left(ControlBlock cb, int lw)
    {
        return (cb.x+lw < 10);
    }

    public bool right(ControlBlock cb, int rw)
    {
        return (cb.x + rw > 0);
    }

    public bool up(ControlBlock cb, int uw)
    {
        return true;
    }
}
