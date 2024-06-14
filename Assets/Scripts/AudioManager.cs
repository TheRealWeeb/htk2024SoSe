using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header("Volume")]
    
    [Range(0, 1)]
    public float masterVolume = 1;

    [Range(0, 1)]
    public float musicVolume = 1;
    
    [Range(0, 1)]
    public float ambienceVolume = 1;
    
    [Range(0, 1)]
    public float sfxVolume = 1;

    private Bus masterBus;

    private Bus musicBus;

    private Bus sfxBus;

    private Bus ambienceBus;
    
    public static AudioManager instance { get; private set; }

    private List<EventInstance> eventInstances;

    private EventInstance atmoEventInstance;

    private EventInstance musicEventInstance;

    private int scene;
    
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Audio Manager in the scene.");
        }

        instance = this;

        eventInstances = new List<EventInstance>();

        scene = SceneManager.GetActiveScene().buildIndex;

        masterBus = RuntimeManager.GetBus("bus:/");
        musicBus = RuntimeManager.GetBus("bus:/Music");
        ambienceBus = RuntimeManager.GetBus("bus:/Ambience");
        sfxBus = RuntimeManager.GetBus("bus:/SFX");
    }

    private void Start()
    {
        InitializeAtmo(FMODEvents.instance.atmo); 
        InitializeMusic(FMODEvents.instance.music);
    }

    private void Update()
    {
        masterBus.setVolume(masterVolume);
        musicBus.setVolume(musicVolume);
        ambienceBus.setVolume(ambienceVolume);
        sfxBus.setVolume(sfxVolume);
    }

    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }

    private void InitializeAtmo(EventReference atmoEventReference)
    {
        atmoEventInstance = CreateEventInstance(atmoEventReference);

        if (scene == 1)
        {
            atmoEventInstance.start();
        }
    }

    private void InitializeMusic(EventReference musicEventReference)
    {
        musicEventInstance = CreateEventInstance(musicEventReference);
        musicEventInstance.start();
    }

    public void SetAtmoParameter(string parameterName, float parameterValue)
    {
        atmoEventInstance.setParameterByName(parameterName, parameterValue);
    }

    public void SetMusic(Music scene)
    {
        musicEventInstance.setParameterByName("Scene", (float)scene);
    }

    public EventInstance CreateEventInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        eventInstances.Add(eventInstance);
        return eventInstance;
    }

    private void CleanUp()
    {
        foreach (EventInstance eventInstance in eventInstances)
        {
            eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            eventInstance.release();
        }
    }

    private void OnDestroy()
    {
        CleanUp();
    }
}
