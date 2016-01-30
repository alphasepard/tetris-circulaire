using UnityEngine;
using System.Collections;

public class Model : MonoBehaviour {

    public int nbLine = 14;
    public int nbColone = 10;
    public float moveSpeed = 0.4f;

    private ControlBlock[] poolBlock;

    int interval = 1;
    float nextTime = 0;

    // Use this for initialization
    void Start () {
        poolBlock = new ControlBlock[1000];
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time >= nextTime)
        {
            transform.position += new Vector3(0, -0.5f, 0);

            nextTime += interval;
        }
    }
}
