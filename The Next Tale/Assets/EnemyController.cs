using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public float lookRadius = 10f;
    GameObject player;
    Transform target;
    NavMeshAgent agent;
    public float boostup = 3;
    public GameObject blood;
    GameObject kraujas;
    public GameObject deadMonster;
    private AudioSource audioSource;
    public AudioClip die;
    public AudioClip actuallyfind;
    public AudioClip find;
    Vector3 hitDirection;
    public float pushBackForce = 8;
    bool found;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
        agent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
        found = false;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if(distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            if (found)
            {
                found = false;
                AudioSource.PlayClipAtPoint(actuallyfind, this.transform.position);
            }
        }
        else
        {
            found = true;
        }
    }
    void OnDrawGizmoSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            Kill();
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == player && player.GetComponent<PlayerHealth>().invincibility == false)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(1);
            kraujas = Instantiate(blood, player.transform.GetChild(1).gameObject.transform.position + new Vector3(0, 1, 0), player.transform.rotation);
            kraujas.transform.parent = player.transform;
            AudioSource.PlayClipAtPoint(find, this.transform.position);
            hitDirection = other.transform.position - transform.position;
            hitDirection = hitDirection.normalized * pushBackForce;
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            //player.GetComponent<Rigidbody>().Sleep();
            other.gameObject.GetComponent<Rigidbody>().AddRelativeForce(hitDirection * 500, ForceMode.VelocityChange);
        }
    }
    public void Kill()
    {
        Instantiate(deadMonster, transform.position, transform.rotation);
        this.gameObject.SetActive(false);
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        player.GetComponent<Rigidbody>().Sleep();
        player.GetComponent<Rigidbody>().AddForce(Vector3.up * boostup, ForceMode.VelocityChange);
        AudioSource.PlayClipAtPoint(die, this.transform.position);

    }
}
