using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class soundmanager : MonoBehaviour
{
    public static soundmanager instance;

    public Slider musicslider, effectsldier;

    public static float musicvalue, sfxvalue;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        musicvalue = PlayerPrefs.GetFloat("music", 1);
        sfxvalue = PlayerPrefs.GetFloat("sfx", 1);


        musicslider.value = musicvalue;
        effectsldier.value = sfxvalue;


    }







    public void volumechange()
    {


        musicvalue = musicslider.value;
        sfxvalue = effectsldier.value;

        PlayerPrefs.SetFloat("music", musicvalue);
        PlayerPrefs.SetFloat("sfx", sfxvalue);
    }





    // Update is called once per frame
    void Update()
    {
        
    }
}
