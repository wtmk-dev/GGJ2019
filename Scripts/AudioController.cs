using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    [SerializeField]
    private AudioClip aClip;

    private AudioSource audioSource;

    void Awake(){
        audioSource = GetComponent<AudioSource>();
    }

    void Start(){
        audioSource.clip = aClip;
        audioSource.Play();
    }


}
