using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatchSounds : MonoBehaviour

{
    public AudioSource source;
    public AudioClip closeSound;

    public void close()
    {
        source.PlayOneShot(closeSound);
    }
}
