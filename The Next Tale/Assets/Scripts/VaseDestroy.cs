using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    public GameObject broken;
    public GameObject effect;
    public GameObject effect_wood;
    public GameObject spawn;
    public float boostup = 15;
    public bool TimeToDie;
    public bool TimeToDieStrong;
    private AudioSource audioSource;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = GetComponent<AudioSource>();
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
            Instantiate(effect_wood, transform.position + new Vector3(0, 1), new Quaternion(0, 0, 0, 0));
            Instantiate(spawn, transform.position+ new Vector3(0,0.5f), transform.rotation);
            print("Veikia");
            AudioSource.PlayClipAtPoint(audioSource.clip, this.transform.position);
            gameObject.SetActive(false);

        }
        if (other.gameObject != player)
        {
            if (GetComponent<Rigidbody>().velocity.y < -7 || TimeToDie || other.GetComponent<VaseDestroy>().TimeToDieStrong)
            {
                Instantiate(broken, transform.position, new Quaternion(180, 0, 0, 0));
                Instantiate(effect, transform.position + new Vector3(0, 1), new Quaternion(0, 0, 0, 0));
                Instantiate(spawn, transform.position + new Vector3(0, 0.5f), transform.rotation);
                Instantiate(effect_wood, transform.position + new Vector3(0, 1), new Quaternion(0, 0, 0, 0));
                print("Veikia");
                AudioSource.PlayClipAtPoint(audioSource.clip, this.transform.position);
                gameObject.SetActive(false);
                player.GetComponent<LevelInventory>().BarrelWithoutJump++;
            }
        }
    }
}
