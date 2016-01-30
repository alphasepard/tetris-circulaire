using UnityEngine;
using System.Collections;

public class controleurJ1 : MonoBehaviour {

    public int speedDelay;
    public int n;
    public ControlBlock pieceCourante;

    // Use this for initialization
    void Start () {
        n = 0;
        speedDelay = 60;
	}

    public void setPieceCourante(ControlBlock cb) {
        pieceCourante = cb;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown("Q")) { }
            //move left if possible
        else if (Input.GetKeyDown("D")) { }
            //move right if possible
        else if (Input.GetKeyDown("Z")) { }
            //rotate clockwise
        else if (Input.GetKeyDown("S")) { }
        //rotate anti-clockwise

        if (Input.GetKeyDown("Backspace"))
            speedDelay = 15;
        else
            speedDelay = 60;
    }
}
