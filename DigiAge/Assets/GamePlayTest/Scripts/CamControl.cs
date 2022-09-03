using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CamControl : MonoBehaviour
{
    private GameObject TargetPlayer;
    [SerializeField] private Vector3 Distance;
    private float CamSpeed = 100f;

    static public bool ShakeStarter = false;
    private float ShakeDuration = 0.02f;

    private void Awake()
    {
        TargetPlayer = GameObject.FindWithTag("Player");
    }

    private void LateUpdate()
    {
        this.gameObject.transform.position = Vector3.Slerp(this.transform.position,
            TargetPlayer.transform.position + Distance, Time.deltaTime * CamSpeed);
    }

    private void Update()
    {
        if (ShakeStarter)
        {
            ShakeStarter = false;
            StartCoroutine((CameraShake()));
        }
    }

    IEnumerator CameraShake()
    {
        float elapsedTime = 0f;

        while (elapsedTime<ShakeDuration)
        {
            elapsedTime += Time.deltaTime;
            transform.position = transform.position + Random.insideUnitSphere;
            yield return null;
        }
    }
}
