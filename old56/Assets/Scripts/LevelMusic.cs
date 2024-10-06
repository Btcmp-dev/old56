using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class LevelMusic : MonoBehaviour
{
    private FMOD.Studio.EventInstance musicInstance;
    public float volume;
    private float stopState = 2f; // ��� fmod ���������

    void Start()
    {
        // �������� ��������� ������� ������
        musicInstance = RuntimeManager.CreateInstance("event:/Level1");
        musicInstance.start();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) // ������ ����� ����� ������� ����� �����.
        {
            StopMusic();
        }
        // ������������� �������� ���������
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
