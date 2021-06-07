using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip WinMusic, Hadouken, Jumpon, BeamSound, Nani, OMAE, RobDeath, tuturu, Coffin;
    static AudioSource audiosrc;
    // Start is called before the first frame update
    void Start()
    {
        WinMusic = Resources.Load<AudioClip>("cut_lonsooavi");
        Hadouken = Resources.Load<AudioClip>("hadouken_4");
        Jumpon = Resources.Load<AudioClip>("klonk");
        BeamSound = Resources.Load<AudioClip>("lightsaber_02");
        Nani = Resources.Load<AudioClip>("nani_mkANQUf");
        OMAE = Resources.Load<AudioClip>("omae-wa-mou-shindeiru");
        //Debug.Log((OMAE == null) ? "Sound is null" : "Sound is not null");
        RobDeath = Resources.Load<AudioClip>("roblox-death-sound-effect");
        tuturu = Resources.Load<AudioClip>("tuturu_1");
        Coffin = Resources.Load<AudioClip>("y2mate-mp3cut_sRzY6rh");

        audiosrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "Win":
                audiosrc.PlayOneShot(WinMusic);
                break;
            case "Fireball":
                audiosrc.PlayOneShot(Hadouken);
                break;
            case "Jumpon":
                audiosrc.PlayOneShot(Jumpon);
                break;
            case "Beam":
                audiosrc.PlayOneShot(BeamSound);
                break;
            case "Nani":
                audiosrc.PlayOneShot(Nani);
                break;
            case "OMAE":
                Debug.Log("Here");
                audiosrc.PlayOneShot(OMAE);
                break;
            case "TouchDMG":
                audiosrc.PlayOneShot(RobDeath);
                break;
            case "tuturu":
                audiosrc.PlayOneShot(tuturu);
                break;
            case "Lose":
                audiosrc.PlayOneShot(Coffin);
                break;
        }
    }
}
