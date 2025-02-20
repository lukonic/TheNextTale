﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColission : MonoBehaviour
{

    public float minDistance = 1.0f;
    public float maxDistance = 4.0f;
    public float smooth = 10.0f;
    Vector3 dollyDir;
    public Vector3 dollyDirAdjusted;
    public float distance;
    public GameObject camera;
    // Use this for initialization
    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("CameraFolder");
    }
    void Awake()
    {
        dollyDir = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        if (camera.GetComponent<CameraFollow>().ON)
        {
            var d = Input.GetAxis("Mouse ScrollWheel");
            if (d > 0 && maxDistance > 1.0f)
            {
                maxDistance = maxDistance - 1.0f;
            }
            if (d < 0 && maxDistance < 4.0f)
            {
                maxDistance = maxDistance + 1.0f;
            }
        }
        Vector3 desiredCameraPos = transform.parent.TransformPoint(dollyDir * maxDistance);
        RaycastHit hit;

        if (Physics.Linecast(transform.parent.position, desiredCameraPos, out hit))
        {
            distance = Mathf.Clamp((hit.distance * 0.8f), minDistance, maxDistance);

        }
        else
        {
            distance = maxDistance;
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, dollyDir * distance, Time.deltaTime * smooth);
    }
}
