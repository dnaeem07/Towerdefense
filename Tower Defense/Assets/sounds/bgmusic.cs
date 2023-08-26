using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgmusic : MonoBehaviour
{
    AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        music= gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        music.volume = soundmanager.instance.musicslider.value;

    }



}
