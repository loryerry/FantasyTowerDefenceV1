using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class AudioSettings : MonoBehaviour
{
    public AudioMixer Mixer;
    public void SetVolumeMaster(float Volume)
    {
        Mixer.SetFloat("MasterVolume", Volume);
    }
    

    public void SetVolumeEffects(float Volume)
    {
        Mixer.SetFloat("Effects", Volume);
    }


    public void SetVolumeMusic(float Volume)
    {
        Mixer.SetFloat("Music", Volume);
    }
}
