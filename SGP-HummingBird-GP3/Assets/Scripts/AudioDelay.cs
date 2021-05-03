using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDelay : MonoBehaviour

{
    AudioSource AudioClip;
    // Start is called before the first frame update
    void Start()
    {
        AudioClip = GetComponent<AudioSource>();
        AudioClip.PlayDelayed(20.0f);
    }

}
