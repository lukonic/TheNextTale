using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInventory : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector]public string[] SecretArray;
    [HideInInspector]public int counter;
    void Start()
    {
        counter = 0;
        SecretArray = new string[5];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
