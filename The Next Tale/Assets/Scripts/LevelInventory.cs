using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInventory : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector]public string[] SecretArray;
    [HideInInspector]public int counter;

    public int TorchesLit;
    public int BarrelWithoutJump;
    public int Gems;
    public int secrets;
    public int jumps;
    public int KeyInTime;
    public float Level1Time;
    void Start()
    {
        TorchesLit = 0;





        counter = 0;
        SecretArray = new string[5];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
