using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeMovementManager : MonoBehaviour
{
    private float axeRotateSpeed = 2000f,axeParentMovementSpeed = 30f;
    public bool knifeHitsAnObject = false;
    void Update()
    {
        // Knife'ı döndürüyoruz
        //transform.Rotate(Vector3.down * Time.deltaTime * axeRotateSpeed);
        
        // Knife'ı hareket ettiriyoruz.
        if (!knifeHitsAnObject)
        {
            transform.parent.transform.Translate((Vector3.forward * Time.deltaTime *axeParentMovementSpeed));
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag(("Wall")) || other.gameObject.CompareTag(("Ground")))
        {
            knifeHitsAnObject = true;
        }
    }
}
