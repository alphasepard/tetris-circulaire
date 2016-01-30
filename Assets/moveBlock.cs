using UnityEngine;
using System.Collections;

public class moveBlock : MonoBehaviour {

    public int nbLine = 14;
    public int nbColone = 10;
    public float moveSpeed = 0.4f;

    public GameObject block;
    public GameObject blocke;
    public GameObject blockm;
        
     

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
	}
}
