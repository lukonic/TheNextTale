using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapult_Button : MonoBehaviour
{
    GameObject player;
    GameObject catapult;
    bool cooldown;
    public Material[] material;
    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        catapult = GameObject.FindGameObjectWithTag("Catapult");
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
        cooldown = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player && (player.GetComponent<Rigidbody>().velocity.y < -1))
        {
            if (cooldown == false)
            {
                catapult.GetComponent<Catapult>().IsON = true;
                print("VEIKIA");
                cooldown = true;
                rend.sharedMaterial = material[1];
                StartCoroutine(ExecuteAfterTime(2f));
            }

        }
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        cooldown = false;
        rend.sharedMaterial = material[0];
    }
}
