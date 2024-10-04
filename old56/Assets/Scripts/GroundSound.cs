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
        // ���������, ����� �� ����� �� ����� (��������, � ������� ������ ��� �����������)
        if (IsPlayerMoving() && !isPlayingFootstep)
        {
            StartCoroutine(PlayFootstepSound());
        }
    }

    IEnumerator PlayFootstepSound()
    {
        isPlayingFootstep = true;
        // �������� ������� ������ � ����������� Tilemap
        Vector3 playerPosition = transform.position;
        Vector3Int tilePosition = tilemap.WorldToCell(playerPosition);

        // �������� ����, �� ������� ����� �����
        TileBase tile = tilemap.GetTile(tilePosition);

        // ���� ��� ��������� ����, ����������� ��������������� ����
        if (tile is GigaTile gigaTile && gigaTile.pathToSound != "")
        {
            footstepSound = RuntimeManager.CreateInstance(gigaTile.pathToSound);
            footstepSound.start();
            footstepSound.release();
        }

        yield return new WaitForSeconds(coolDown);

        isPlayingFootstep = false;
    }

    // ��������, �������� �� ����� (����� ������������ ���� ������)
    
    
    
    bool IsPlayerMoving()
    {
        // ������ �������� �������� ������ (����� ������ ���� �������� �� ����������� ��� ������)
        return Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;
    }
}
