using UnityEngine;
using System.Collections;

public class Model : MonoBehaviour {

    public int nbLine = 14;
    public int nbColone = 10;
    public float moveSpeed = 0.4f;
    public controleurJ1 j1;
    public controleurJ2 j2;

    private ControlBlock[] poolBlock;

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
        for (int i = 0; i<999; i++)
        {
            poolBlock[i] = new ControlBlock(this);
        }
        j1 = new controleurJ1();
        j2 = new controleurJ2();
        start_partie();
	}

    void start_partie()
    {
        j1.setPieceCourante(poolBlock[0]);
        j2.setPieceCourante(poolBlock[0]);
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
