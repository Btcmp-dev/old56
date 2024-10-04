using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using FMODUnity;

public class FootstepSound : MonoBehaviour
{
    public Tilemap tilemap;
    private bool isPlayingFootstep = false;
    private float coolDown = 0.3f;
    //public AudioSource audioSource;

    FMOD.Studio.EventInstance footstepSound;


    void Update()
    {
        // ѕровер€ем, стоит ли игрок на земле (например, с помощью физики или контроллера)
        if (IsPlayerMoving() && !isPlayingFootstep)
        {
            StartCoroutine(PlayFootstepSound());
        }
    }

    IEnumerator PlayFootstepSound()
    {
        isPlayingFootstep = true;
        // ѕолучаем позицию игрока в координатах Tilemap
        Vector3 playerPosition = transform.position;
        Vector3Int tilePosition = tilemap.WorldToCell(playerPosition);

        // ѕолучаем тайл, на котором стоит игрок
        TileBase tile = tilemap.GetTile(tilePosition);

        // ≈сли это кастомный тайл, проигрываем соответствующий звук
        if (tile is GigaTile gigaTile && gigaTile.pathToSound != "")
        {
            footstepSound = RuntimeManager.CreateInstance(gigaTile.pathToSound);
            footstepSound.start();
            footstepSound.release();
        }

        yield return new WaitForSeconds(coolDown);

        isPlayingFootstep = false;
    }

    // ѕроверка, движетс€ ли игрок (можно использовать свою логику)
    
    
    
    bool IsPlayerMoving()
    {
        // ѕример проверки движени€ игрока (здесь должно быть движение от контроллера или физики)
        return Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;
    }
}
