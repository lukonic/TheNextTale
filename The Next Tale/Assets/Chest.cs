using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    public GameObject spawn;
    Animator m_Animator;
    private bool open;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        m_Animator = GetComponent<Animator>();
        open = false;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player && open == false)
        {
            Instantiate(spawn, transform.position + new Vector3(0, 0.5f), transform.rotation);
            m_Animator.SetBool("Atidaryta", true);
            open = true;
        }
    }
}
