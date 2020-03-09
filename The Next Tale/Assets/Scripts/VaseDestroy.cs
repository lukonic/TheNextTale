using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    public GameObject broken;
    public GameObject effect;
    public GameObject spawn;
    public float boostup = 15;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player && (player.GetComponent<Rigidbody>().velocity.y < -2))
        {
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            player.GetComponent<Rigidbody>().Sleep();
            player.GetComponent<Rigidbody>().AddForce(Vector3.up * boostup, ForceMode.VelocityChange);
            Instantiate(broken, transform.position, new Quaternion(180,0,0,0));
            Instantiate(effect, transform.position + new Vector3(0, 1), new Quaternion(0, 0, 0, 0));
            Instantiate(spawn, transform.position+ new Vector3(0,0.5f), transform.rotation);
            print("Veikia");
            gameObject.SetActive(false);

        }
        if (GetComponent<Rigidbody>().velocity.y < -7 || GetComponent<Rigidbody>().velocity.y > 5)
        {
            Instantiate(broken, transform.position, new Quaternion(180, 0, 0, 0));
            Instantiate(effect, transform.position + new Vector3(0, 1), new Quaternion(0, 0, 0, 0));
            Instantiate(spawn, transform.position + new Vector3(0, 0.5f), transform.rotation);
            print("Veikia");
            gameObject.SetActive(false);
        }
    }
}
