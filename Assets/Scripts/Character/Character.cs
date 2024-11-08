using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField]
    private CharacterType characterType;

    [SerializeField]
    protected CharacterData characterData;

    public virtual Character CharacterTarget {  get; }
    public CharacterType CharacterType => characterType;
    public CharacterData CharacterData => characterData;
    public IMovable MovableComponent;
    public ILifeComponent LifeComponent;
    public IDamageComponent DamageComponent;

    public virtual void Initialize()
    {
        MovableComponent = new CharacterMovementComponent();
        
        MovableComponent.Initialize(characterData);
    }
    public abstract void Update();
}
