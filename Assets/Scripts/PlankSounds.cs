using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankSounds : MonoBehaviour
{

    public AudioClip[] sounds = { };
    int lastPlayed = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playSound()
    {
        var audioSrc = this.gameObject.GetComponent<AudioSource>();
        var selection = Mathf.RoundToInt(Random.Range(0, sounds.Length - 1));
        while (selection == lastPlayed)
        {
            selection = Mathf.RoundToInt(Random.Range(0, sounds.Length - 1));
        }
        audioSrc.clip = sounds[selection];
        lastPlayed = selection;
        audioSrc.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        playSound();
    }
}
