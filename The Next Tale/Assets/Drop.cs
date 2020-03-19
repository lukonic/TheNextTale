using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public GameObject Paimta;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExecuteAfterTime2(0.5f));
    }
    IEnumerator ExecuteAfterTime2(float time)
    {
        yield return new WaitForSeconds(time);
        this.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other != Paimta)
        {
            Paimta.GetComponent<PickUpAble>().drop();
            print("Prilietė");
        }

    }
}
