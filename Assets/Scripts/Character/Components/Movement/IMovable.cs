using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovable : ICharacterComponent
{
    public float Speed { get; set; }

    public void Initialize(CharacterData characterData);
    public void Move(Vector3 direction);

    public void Rotate(Vector3 direction);
}
