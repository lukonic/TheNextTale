using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float m_moveSpeed = 2;

    private float m_currentV = 0;
    private float m_currentH = 0;

    private readonly float m_interpolation = 10;
    private readonly float m_walkScale = 0.75f;

    private Vector3 m_currentDirection = Vector3.zero;
    private Vector3 direction;


    Animator m_Animator;
    Rigidbody m_Rigidbody;
    public float jumpHeight = 2f;
    public LayerMask groundLayers;
    public CapsuleCollider col;
    Vector3 m_Movement;
    public bool Carrying;
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        GetComponent<BoxCollider>().enabled = false;
        // get the distance to ground
    }
    void Update()
    {
        if (IsGrounded())
        {
            m_Animator.SetBool("IsJumping", false);
            if (Input.GetButtonDown("Jump") && Carrying == false)
            {
                print("VEIKIA");
                m_Rigidbody.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            }
        }
        else
        {
            m_Animator.SetBool("IsJumping", true);
        }
        DirectUpdate();
        
    }
    private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * .3f, groundLayers);
    }
    private void DirectUpdate()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

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
        else if(!Carrying)
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
    void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        // m_Rigidbody.MoveRotation(m_Rotation);
    }
}
