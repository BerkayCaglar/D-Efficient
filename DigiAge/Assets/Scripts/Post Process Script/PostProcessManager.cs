using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessManager : MonoBehaviour
{
    static private PostProcessVolume postProcessVolume;
    private void Awake()
    {
        postProcessVolume = GetComponent<PostProcessVolume>();
    }

    private void Update()
    {
        if (postProcessVolume.isGlobal)
        {
            StartCoroutine(WaitSeconds());
        }
    }

    static public void PostProcessTrigger(bool enableOrDisable)
    {   
        postProcessVolume.isGlobal = enableOrDisable;
    }

    IEnumerator WaitSeconds()
    {
        yield return new WaitForSeconds(0.05f);
        postProcessVolume.isGlobal = false;
    }
}
