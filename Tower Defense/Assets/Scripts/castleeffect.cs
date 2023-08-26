using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class castleeffect : MonoBehaviour
{

    public static castleeffect instance;

    public ParticleSystem[] explosion;

    public AudioSource soundeffect;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    
    }


    IEnumerator delay()
    {
        yield return new WaitForSeconds(1.2f);
        for (int i = 0; i < explosion.Length; i++)
        {
            explosion[i].gameObject.SetActive(false);

            explosion[i].Stop();


        }

    }
    public void playeffect()
    {
        soundeffect.Play();
        StartCoroutine(delay());
        for (int i = 0; i < explosion.Length; i++)
        {
            explosion[i].gameObject.SetActive(true);
            explosion[i].Play();
        
        
        }
    
    
    }












    // Update is called once per frame
    void Update()
    {
        
    }
}
