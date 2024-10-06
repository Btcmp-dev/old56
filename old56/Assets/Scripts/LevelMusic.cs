using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class LevelMusic : MonoBehaviour
{
    private FMOD.Studio.EventInstance musicInstance;
    public float volume;
    private float stopState = 2f; // дл€ fmod параметра

    void Start()
    {
        // —оздайте экземпл€р событи€ музыки
        musicInstance = RuntimeManager.CreateInstance("event:/Level1");
        musicInstance.start();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) // вместо спасе можно вызвать метод извне.
        {
            StopMusic();
        }
        // ”станавливаем значение параметра
        musicInstance.setParameterByName("Volume", volume);
    }

    public void StopMusic()
    {
        musicInstance.setParameterByName("Parameter 1", stopState);
        Invoke("OnDestroy", 3f);
    }

    private void OnDestroy()
    {
        musicInstance.release();
    }
}
