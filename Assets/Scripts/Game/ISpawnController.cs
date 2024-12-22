using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpawnController
{
    public float TimeBetweenSpawns {  get; set; }
    public float MinOffset { get; set; }
    public float MaxOffset { get; set; }

    public float GetOffset();
    public void Spawn();

}
