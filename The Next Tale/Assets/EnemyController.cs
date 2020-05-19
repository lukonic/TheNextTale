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
    public GameObject deadMonster;
    private AudioSource audioSource;
    public AudioClip die;
    public AudioClip actuallyfind;
    public AudioClip find;
    Vector3 hitDirection;
    public float pushBackForce = 8;
    bool found;
    bool allowkill;

    // Start is called before the first frame update
    void Start()
    {
        allowkill = true;
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
        if (other.gameObject == player && allowkill && (player.GetComponent<Rigidbody>().velocity.y < -1))
        {
            Kill();
        }
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        allowkill = true;
    }
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject == player && player.GetComponent<PlayerHealth>().invincibility == false)
        {
            allowkill = false;
            
            player.GetComponent<PlayerHealth>().TakeDamage(1);
            Instantiate(blood, player.transform.GetChild(1).gameObject.transform.position + new Vector3(0, 1, 0), player.transform.rotation);
            AudioSource.PlayClipAtPoint(find, this.transform.position);
            hitDirection = other.transform.position - transform.position;
            hitDirection = hitDirection.normalized*10;
            hitDirection.y = 5;
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            player.GetComponent<Rigidbody>().Sleep();
            other.gameObject.GetComponent<Rigidbody>().AddForce(hitDirection, ForceMode.VelocityChange);
            StartCoroutine(ExecuteAfterTime(.5f));

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
    public void KillBarrel()
    {
        Instantiate(deadMonster, transform.position, transform.rotation);
        this.gameObject.SetActive(false);
        AudioSource.PlayClipAtPoint(die, this.transform.position);
    }
}
