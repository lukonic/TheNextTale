using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainTexture : MonoBehaviour
{
    Renderer rend;
    public Material[] mats;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        if ((PlayerPrefs.GetInt("MLVL4", 0)) != 0)
        {
            GetComponent<Renderer>().materials = mats;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
