using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Model))]
public class controleurJ1 : MonoBehaviour {

    public int speedDelay;
    public int n;
    public int decompte;
    public ControlBlock pieceCourante;
    public bool toucherLeFond;

    // Use this for initialization
    void Start () {
        n = 0;
        decompte = 60;
        speedDelay = 60;
    }

    // Update is called once per frame
    void Update () {
        decompte--;
        if (decompte <= 0)
        {
            decompte = speedDelay;
            toucherLeFond = pieceCourante.move(0, 1, 1);
        }
        if (Input.GetKeyDown("d"))
        {
            pieceCourante.move(1, 0, 1);
        }
        else if (Input.GetKeyDown("q"))
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

        if (Input.GetKey(KeyCode.Space))
            speedDelay = 5;
        else
            speedDelay = 60;
    }
}
