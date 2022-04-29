using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bark : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip[] clips;
    public bool manualActive;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clips[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (manualActive)
        {
            BarkOnce();
            manualActive = false;
        }
    }

    public void BarkOnce()
    {
        audioSource.Play();
    }

    public void ChangeVoice()
    {
        audioSource.clip = clips[Random.Range(0, clips.Length)];
    }
}
