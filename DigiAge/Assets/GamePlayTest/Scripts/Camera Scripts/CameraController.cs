using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    public Animator animator;
    private AudioSource Music;
    private AudioSource MusicEffects;

    public float speedOfCamera = 10;
    private float musicVolume;
    private float effectsVolume;
    public Camera cam;
    void Start()
    {
        //Music = GetComponent<AudioSource>();
        //MusicEffects = GetComponent<AudioSource>();
    }
    void Update()
    {
        //Music.volume = musicVolume;
        if (cam.orthographicSize==200f)
        {
            SceneManager.LoadScene(1);
        }
        transform.Rotate(Vector3.up, speedOfCamera * Time.deltaTime);
    }
    public void startButton()
    {
        animator.SetTrigger("New Trigger");
    }
    //public void setVolumeOfMusic(float volume)
    //{
    //    musicVolume = volume;
    //}
    //public void setVolumeOfEffects(float volume)
    //{
    //    effectsVolume = volume;
    //}
}
