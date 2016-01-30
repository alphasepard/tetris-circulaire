using UnityEngine;
using System.Collections;

public class Model : MonoBehaviour {

    public int nbLine = 14;
    public int nbColone = 10;
    public float moveSpeed = 0.4f;
    public controleurJ1 j1;
    public controleurJ2 j2;

    private ControlBlock[] poolBlock;

    int interval = 1;
    float nextTime = 0;

    // Use this for initialization
    void Start () {
        poolBlock = new ControlBlock[1000];
        for(int i = 0; i < 999; i++)
        {
            poolBlock[i] = gameObject.AddComponent<ControlBlock>();
        }

        j1 = gameObject.AddComponent<controleurJ1>();
        j2 = gameObject.AddComponent<controleurJ2>();
        start_partie();
	}

    void start_partie()
    {
        //while
        ControlBlock dupliq1;
        ControlBlock dupliq2;
        dupliq1 = poolBlock[0];
        dupliq2 = poolBlock[0];
        j1.setPieceCourante(dupliq1);
        j2.setPieceCourante(dupliq2);
       // j1.pieceCourante.transform.position = new Vector3(-3.97f, 5.95f, 0);

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
