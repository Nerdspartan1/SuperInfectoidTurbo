using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            transform.position += new Vector3(0, Input.GetAxis("Vertical"), 0);
        }
    }
}
