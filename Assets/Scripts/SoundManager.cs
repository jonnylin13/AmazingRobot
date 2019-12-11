using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioSource button;
    public AudioSource computer;
    public AudioClip AClip;
    public AudioClip EClip;
    public AudioClip successClip;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void clickButton()
    {
        button.volume = Random.Range(0.8f, 1.0f);
        button.pitch = Random.Range(0.8f, 1.0f);
        button.Play();
    }

    public void playA()
    {
        computer.PlayOneShot(AClip);
    }

    public void playE()
    {
        computer.PlayOneShot(EClip);
    }

    public void pkaySuccess()
    {
        computer.PlayOneShot(successClip);
    }
}
