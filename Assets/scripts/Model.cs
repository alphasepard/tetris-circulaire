using UnityEngine;
using System.Collections;

public class Model : MonoBehaviour {

    public int nbLine = 14;
    public int nbColone = 10;
    public float moveSpeed = 0.4f;

    private ControlBlock[] poolBlock;

    // Use this for initialization
    void Start () {
        poolBlock = new ControlBlock[1000];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
