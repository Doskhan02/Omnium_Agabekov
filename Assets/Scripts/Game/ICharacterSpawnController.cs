using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterSpawnController : ISpawnController
{
    public void Spawn(Character character);
}
