using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if ((PlayerPrefs.GetInt("MLVL2", 0)) == 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
