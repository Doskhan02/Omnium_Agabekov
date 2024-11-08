using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : Character
{

    [SerializeField] private AIState currentState;

    private float timeBetweenDamageCounter = 0;

    public override Character CharacterTarget => GameManager.Instance.CharacterFactory.Player;
    public float distanceToTarget
    {
        get => Vector3.Distance(CharacterTarget.transform.position, characterData.transform.position);

    }

    public override void Initialize()
    {
        base.Initialize();
        LifeComponent = new LifeComponent();
        DamageComponent = new CharacterDamageComponent();
    }


    public override void Update()
    {
        switch (currentState)
        {
            case AIState.None:
                break;

            case AIState.MoveToTarget:
                Vector3 direction = CharacterTarget.transform.position - transform.position;
                direction.Normalize();
                MovableComponent.Move(direction);
                CharacterTarget.MovableComponent.Rotate(direction);
                break;

            case AIState.MakingDamage:
                if (distanceToTarget < 3 && timeBetweenDamageCounter <= 0)
                {
                    DamageComponent.MakeDamage(CharacterTarget);
                    timeBetweenDamageCounter = characterData.TimeBetweenDamage;
                }
                if (timeBetweenDamageCounter > 0)
                    timeBetweenDamageCounter -= Time.deltaTime;
                break;
        }
    }
}
