using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingGun : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Vector3 grapplePoint;
    public LayerMask whatisGrapple;
    public Transform gunTip;
    public Transform camera;
    public Transform player;
    private float maxDistance = 100f;
    private SpringJoint Joint;

    private void Awake()
    {
        lineRenderer = this.gameObject.GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            StartGrapple();
        }
    }

    private void StartGrapple()
    {
        RaycastHit hit;

        if (Physics.Raycast(Input.mousePosition, camera.right, out hit, whatisGrapple))
        {
            grapplePoint = hit.point;
            Joint = player.gameObject.AddComponent<SpringJoint>();
            Joint.autoConfigureConnectedAnchor = false;
            Joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(Input.mousePosition, grapplePoint);
        }
    }
}
