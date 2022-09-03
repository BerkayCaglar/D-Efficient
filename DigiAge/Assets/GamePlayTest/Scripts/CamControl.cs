using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    private GameObject TargetPlayer;
    [SerializeField] private Vector3 Distance;
    [SerializeField] private float CamSpeed = 100f;

    private void Awake()
    {
        TargetPlayer = GameObject.FindWithTag("Player");
    }

    private void LateUpdate()
    {
        this.gameObject.transform.position = Vector3.Lerp(this.transform.position,
            TargetPlayer.transform.position + Distance, Time.deltaTime * CamSpeed);
    }
}
