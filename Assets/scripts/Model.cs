using UnityEngine;
using System.Collections;

public class Model : MonoBehaviour {

    public int nbLine = 14;
    public int nbColone = 10;
    public float moveSpeed = 0.4f;
    public controleurJ1 j1;
    public controleurJ2 j2;
    public GameObject doubleBlock;
    public GameObject tripleBlock1;
    public GameObject tripleBlock2;

    private ControlBlock[] poolBlock;

    int interval = 1;
    float nextTime = 0;
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

    // Use this for initialization
    void Start () {

        poolBlock = new ControlBlock[1000];

        for(int i = 0; i < 999; i++)
        {
            poolBlock[i] = gameObject.AddComponent<ControlBlock>();
            poolBlock[i].setModel(this);
        }

        j1 = gameObject.AddComponent<controleurJ1>();
        j2 = gameObject.AddComponent<controleurJ2>();

        spawnJ1(0);
        spawnJ2(0);
        //start_partie();
    }

    void start_partie()
    {
        //while
        ControlBlock dupliq1;
        ControlBlock dupliq2;
       // dupliq1 = Instantiate((Object)poolBlock[0], new Vector3(-3.97f, 5.95f, 0), Quaternion.identity);
        dupliq2 = poolBlock[0];
        //j1.setPieceCourante(dupliq1);
        //j2.setPieceCourante(dupliq2);
       // j1.pieceCourante.transform.position = new Vector3(-3.97f, 5.95f, 0);

    }

    void spawnPiece(ControlBlock cb, int joueur)
    {
        float x = 0.0f, y = 0.0f;
        GameObject newPiece;
        if (joueur == 1)
        {
            x = -8.8f;
            y = 3.72f;
        }
        else if (joueur == 2) {
            x = 4.09f;
            y = 3.72f;
        }

        if (cb.currentBlock.name.Equals(doubleBlock.name))
        {
            newPiece = (GameObject)GameObject.Instantiate(doubleBlock, new Vector3(x, y, 0), cb.transform.rotation);
        }
        else if(cb.currentBlock.name.Equals(tripleBlock1.name))
        {
            newPiece = (GameObject)GameObject.Instantiate(tripleBlock1, new Vector3(x, y, 0), cb.transform.rotation);
        }
        else
        {
            newPiece = (GameObject)GameObject.Instantiate(tripleBlock2, new Vector3(x, y, 0), cb.transform.rotation);
        }
        newPiece.transform.Rotate(0, 0, cb.orientation * 90); 
    }

    void spawnJ1(int i)
    {

        spawnPiece(poolBlock[i].GetComponent<ControlBlock>(), 1);
    }

    void spawnJ2(int i)
    {
        spawnPiece(poolBlock[i].GetComponent<ControlBlock>(), 2);
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time >= nextTime)
        {
            //j1.pieceCourante.transform.position += new Vector3(0, -0.5f, 0);
            nextTime += interval;
        }
    } 
}
