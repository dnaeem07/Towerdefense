using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sfx : MonoBehaviour
{
    AudioSource effectsound;
    // Start is called before the first frame update
    void Start()
    {
        effectsound = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        effectsound.volume = soundmanager.instance.effectsldier.value;
        
    }
}
