﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameObject player;
    public float m_moveSpeed = 2;

    private float m_currentV = 0;
    private float m_currentH = 0;

    private readonly float m_interpolation = 10;
    private readonly float m_walkScale = 0.75f;
    public bool tankas;
    public Vector3 m_currentDirection = Vector3.zero;
    private Vector3 direction;

    Animator m_Animator;
    Rigidbody m_Rigidbody;
    public float jumpHeight = 2f;
    public LayerMask groundLayers;
    public GameObject effect;
    public CapsuleCollider col;
    Vector3 m_Movement;
    public bool Carrying;
    public bool ON;
    Vector3 LastSpawn;
    bool landed;
    bool passed = true;
    [SerializeField]
    private AudioClip[] stoneClips;
    [SerializeField]
    private AudioClip jump;
    [SerializeField]
    private AudioClip hop;
    [SerializeField]
    private AudioClip land;

    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        Instantiate(effect, transform.position, transform.rotation);
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        GetComponent<BoxCollider>().enabled = false;
        GetLastSpawn();
        ON = true;
        // get the distance to ground
    }

    public void Step()
    {
        AudioClip clip = stoneClips[UnityEngine.Random.Range(0, stoneClips.Length)];

        audioSource.PlayOneShot(clip);
    }
    public void GetLastSpawn()
    {
        LastSpawn = this.transform.position;
    }
    public void TeleportToLastSpawn()
    {
        this.transform.position = LastSpawn+ new Vector3(0,1,0);
        Instantiate(effect, transform.position, transform.rotation);
        AudioSource.PlayClipAtPoint((AudioClip)Resources.Load("teleport"), this.transform.position);
    }
    void Update()
    {
        if (IsGrounded())
        {
            if (landed)
            {
                audioSource.PlayOneShot(land);
                landed = false;
                StartCoroutine(ExecuteAfterTime(1.0f));
                
            }
            m_Animator.SetBool("IsJumping", false);
            if (Input.GetButtonDown("Jump") && Carrying == false && ON == true && !tankas)
            {
                
                if (Input.GetButton("LeftShift"))
                {
                    print("HOP");

                    audioSource.PlayOneShot(hop);
                    player.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                    player.GetComponent<Rigidbody>().Sleep();
                    m_Rigidbody.AddForce((m_currentDirection / 3 + Vector3.up/1.25f) * jumpHeight, ForceMode.Impulse);
                    player.GetComponent<LevelInventory>().jumps++;

                }

                else
                {
                    print("JUMP");
                    audioSource.PlayOneShot(jump);
                    player.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                    player.GetComponent<Rigidbody>().Sleep();
                    m_Rigidbody.AddForce((Vector3.up) * jumpHeight, ForceMode.Impulse);
                    player.GetComponent<LevelInventory>().jumps++;
                }
            }
        }
        else
        {
            if (passed)
            {
                landed = true;
                passed = false;
            }
            m_Animator.SetBool("IsJumping", true);
        }
        DirectUpdate();
        
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        passed = true;
    }
    public bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * 0.75f, groundLayers);
    }
    private void DirectUpdate()
    {
        if (!tankas)
        {
            m_Animator.SetBool("IsSliding", false);
            float v = 0;
            float h = 0;
            if (ON)
            {
                v = Input.GetAxis("Vertical");
                h = Input.GetAxis("Horizontal");
            }
            Transform camera = Camera.main.transform;
            bool hasHorizontalInput = !Mathf.Approximately(v, 0f);
            bool hasVerticalInput = !Mathf.Approximately(h, 0f);
            bool isWalking = hasHorizontalInput || hasVerticalInput;
            m_Animator.SetBool("IsWalking", isWalking);
            if (Carrying)
            {
                v *= m_walkScale;
                h *= m_walkScale;
                m_Animator.SetBool("IsCarrying", true);
            }
            else if (!Carrying)
            {
                m_Animator.SetBool("IsCarrying", false);
            }
            m_currentV = Mathf.Lerp(m_currentV, v, Time.deltaTime * m_interpolation);
            m_currentH = Mathf.Lerp(m_currentH, h, Time.deltaTime * m_interpolation);

            direction = camera.forward * m_currentV + camera.right * m_currentH;

            float directionLength = direction.magnitude;
            direction.y = 0;
            direction = direction.normalized * directionLength;
            direction = Vector3.ClampMagnitude(direction, 1);

            if (direction != Vector3.zero)
            {

                m_currentDirection = Vector3.Slerp(m_currentDirection, direction, Time.deltaTime * m_interpolation);
                m_currentDirection = Vector3.ClampMagnitude(m_currentDirection, 1);
                transform.rotation = Quaternion.LookRotation(m_currentDirection);
                transform.position += m_currentDirection * m_moveSpeed * Time.deltaTime;
                //m_Rigidbody.AddForce(m_currentDirection * m_moveSpeed * Time.deltaTime);
            }
        }
        else
        {
            
            float v = 0;
            float h = 0;
            Transform camera = Camera.main.transform;
            bool hasHorizontalInput = !Mathf.Approximately(v, 0f);
            bool hasVerticalInput = !Mathf.Approximately(h, 0f);
            bool isWalking = hasHorizontalInput || hasVerticalInput;
            m_Animator.SetBool("IsSliding", true);
            if (Carrying)
            {
                v *= m_walkScale;
                h *= m_walkScale;
                m_Animator.SetBool("IsCarrying", true);
            }
            else if (!Carrying)
            {
                m_Animator.SetBool("IsCarrying", false);
            }
            m_currentV = Mathf.Lerp(m_currentV, v, Time.deltaTime * m_interpolation);
            m_currentH = Mathf.Lerp(m_currentH, h, Time.deltaTime * m_interpolation);

            direction = camera.forward * m_currentV + camera.right * m_currentH;

            float directionLength = direction.magnitude;
            direction.y = 0;
            direction = direction.normalized * directionLength;
            direction = Vector3.ClampMagnitude(direction, 1);

            if (direction != Vector3.zero)
            {

                m_currentDirection = Vector3.Slerp(m_currentDirection, direction, Time.deltaTime * m_interpolation);
                m_currentDirection = Vector3.ClampMagnitude(m_currentDirection, 1);
                transform.rotation = Quaternion.LookRotation(m_currentDirection);
                transform.position += m_currentDirection * m_moveSpeed * Time.deltaTime;
                //m_Rigidbody.AddForce(m_currentDirection * m_moveSpeed * Time.deltaTime);
            }
            if (Input.GetButton("A"))
            {
                transform.position += -transform.right * m_moveSpeed * Time.deltaTime;

            }
            if (Input.GetButton("D"))
            {
                transform.position += transform.right * m_moveSpeed * Time.deltaTime;

            }

        }
    }
    void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        // m_Rigidbody.MoveRotation(m_Rotation);
    }
}
