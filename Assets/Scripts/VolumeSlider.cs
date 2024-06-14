using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private enum VolumeType
    {
        Master,
        Music,
        Ambience,
        Sfx
    }

    [Header("Type")]
    
    [SerializeField] private VolumeType volumeType;

    private Slider volumeSlider;

    private void Awake()
    {
        volumeSlider = this.GetComponentInChildren<Slider>();
    }

    private void Update()
    {
        switch (volumeType)
        {
            case VolumeType.Master:
                volumeSlider.value = AudioManager.instance.masterVolume;
                break;
            case VolumeType.Music:
                volumeSlider.value = AudioManager.instance.musicVolume;
                break;
            case VolumeType.Ambience:
                volumeSlider.value = AudioManager.instance.ambienceVolume;
                break;
            case VolumeType.Sfx:
                volumeSlider.value = AudioManager.instance.sfxVolume;
                break;
            default:
                Debug.LogWarning("Volume Type not supported. " + volumeType);
                break;
        }
    }

    public void OnSliderValueChanged()
    {
        switch (volumeType)
        {
            case VolumeType.Master:
                AudioManager.instance.masterVolume = volumeSlider.value;
                break;
            case VolumeType.Music:
                AudioManager.instance.musicVolume = volumeSlider.value;
                break;
            case VolumeType.Ambience:
                AudioManager.instance.ambienceVolume = volumeSlider.value;
                break;
            case VolumeType.Sfx:
                AudioManager.instance.sfxVolume = volumeSlider.value;
                break;
            default:
                Debug.LogWarning("Volume Type not supported. " + volumeType);
                break;
        }
    }
}
