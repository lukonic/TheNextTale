using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    public bool IsFanOn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFanOn)
        {
            transform.Rotate(0, 0, 0.2f, Space.Self);
        }
    }
}
