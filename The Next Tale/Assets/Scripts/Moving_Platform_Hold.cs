using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Platform_Hold : MonoBehaviour
{
    public Vector3[] points;
    public int point_number = 0;
    private Vector3 current_target;

    public float tolerance;
    public float speed;
    public float delay_time;

    private float delay_start;

    public bool ON;
    public bool Freeze;
    // Start is called before the first frame update
    void Start()
    {
        if (points.Length > 0)
        {
            current_target = points[0];
        }
        tolerance = speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!ON && !Freeze)
        {
            current_target = points[0];
            if (transform.position != current_target)
            {
                MovePlatform();
            }
        }
        if(ON)
        {

            current_target = points[1];
            if (transform.position != current_target)
            {
                MovePlatform();
            }
        }
    }

    void MovePlatform()
    {
        Vector3 heading = current_target - transform.position;
        transform.position += (heading / heading.magnitude) * speed * Time.deltaTime;
        if (heading.magnitude < tolerance)
        {
            transform.position = current_target;
            delay_start = Time.time;
        }
    }
    public void NextPlatform()
    {
        point_number++;
        if (point_number >= points.Length)
        {
            point_number = 0;
        }
        current_target = points[point_number];
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Box" )
        {
            collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            Freeze = true;
            print("Palietė");
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Box")
        {
            collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            Freeze = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        other.transform.parent = transform;
    }
    private void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;
    }

}
