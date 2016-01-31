using UnityEngine;
using System.Collections;

public class Point {

    public int x, y;
    public bool colored;

	public Point(int y, int x)
    {
        this.colored = false;
        this.y = y;
        this.x = x;
    }
}
