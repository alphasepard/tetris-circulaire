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
        if (Input.GetKeyDown("Q"))
        {
            pieceCourante.move(1, 0);
        }
        else if (Input.GetKeyDown("D"))
        {
            pieceCourante.move(-1, 0);
        }
        else if (Input.GetKeyDown("Z"))
        {
            pieceCourante.orient(true);
        }
        else if (Input.GetKeyDown("S"))
        {
            pieceCourante.orient(false);
        }

        if (Input.GetKeyDown("Backspace"))
            speedDelay = 15;
        else
            speedDelay = 60;
    }
}
