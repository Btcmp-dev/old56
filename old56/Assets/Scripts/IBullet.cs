using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBullet
{
    void Shooting();
    void OnCollisionEnter2D(Collision2D collision);
}
