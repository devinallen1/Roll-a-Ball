using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingAudioMixer : MonoBehaviour
{
    private AudioSource m_RingCollected;

    // Start is called before the first frame update
    void Start()
    {
        m_RingCollected = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnDestroy()
    //{
    //    m_RingCollected.Play();
    //}
    private void OnTriggerEnter(Collider other)
    {
        m_RingCollected.Play();
    }
}
