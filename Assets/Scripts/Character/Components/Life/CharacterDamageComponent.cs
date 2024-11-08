using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDamageComponent : IDamageComponent
{
    public float Damage => 10f;

    public void MakeDamage(Character characterTarget)
    {
        if (characterTarget.LifeComponent != null)
             characterTarget.LifeComponent.SetDamage(Damage);
    }

}
