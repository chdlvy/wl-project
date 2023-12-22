using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private AudioSource player;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
       player = GetComponent<AudioSource>();
    }

    public void PlaySound(string name)
    {
        AudioClip audio = Resources.Load<AudioClip>(name);
        player.PlayOneShot(audio);
    }
}
