using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class SoundTest : MonoBehaviour
{
    FMOD.Studio.EventInstance sound;
    public string soundPath;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>())
        {
            sound = RuntimeManager.CreateInstance(soundPath);
            sound.start();
            sound.release();
        }
    }

}
