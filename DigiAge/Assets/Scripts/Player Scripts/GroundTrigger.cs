using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTrigger : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ground") || other.CompareTag("Wall"))
        {
            DashEx.dashSpeed = 15;
            //this.gameObject.GetComponent<DashEx>().dashSpeed *= 2f;
        }
    }
}