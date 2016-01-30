using UnityEngine;
using System.Collections;

public class controleurJ1 : MonoBehaviour {

    public int speedDelay;
    public int n;
    public int decompte;
    public ControlBlock pieceCourante;
    public bool toucherLeFond;

    // Use this for initialization
    void Start () {
        n = 0;
        speedDelay = 60;
        pieceCourante = gameObject.AddComponent<ControlBlock>();
    }

    public void setPieceCourante(ControlBlock cb) {
        pieceCourante = cb;
    }

    // Update is called once per frame
    void Update () {
        decompte--;
        if (decompte <= 0)
        {
            decompte = speedDelay;
            toucherLeFond = pieceCourante.move(0, 1, 1);
            
        }
        if (Input.GetKeyDown("q"))
        {
            pieceCourante.move(1, 0, 1);
        }
        else if (Input.GetKeyDown("d"))
        {
            pieceCourante.move(-1, 0, 1);
        }
        else if (Input.GetKeyDown("z"))
        {
            pieceCourante.orient(true, 1);
        }
        else if (Input.GetKeyDown("s"))
        {
            pieceCourante.orient(false, 1);
        }

        if (Input.GetKeyDown("backspace"))
            speedDelay = 15;
        else
            speedDelay = 60;
    }
}
