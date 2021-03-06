﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Model))]
public class controleurJ2 : MonoBehaviour {

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
            toucherLeFond = pieceCourante.move(0, 1, 2);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            pieceCourante.move(1, 0, 2);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            pieceCourante.move(-1, 0, 2);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            pieceCourante.orient(true, 2);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            pieceCourante.orient(false, 2);
        }

        if (Input.GetKey("m"))
            speedDelay = 5;
        else
            speedDelay = 60;
    }
}
