using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawnController : ISpawnController
{
    [SerializeField] private GameData gameData;
    [SerializeField] private CharacterFactory characterFactory;
    private ScoreSystem scoreSystem;


    public float TimeBetweenSpawns 
    { 
        get => gameData.TimeBetweenEnemySpawn; 
        set => TimeBetweenSpawns = value; 
    }
    public float MinOffset 
    {
        get => gameData.MinSpawnOffset; 
        set => MinOffset = value; 
    }
    public float MaxOffset 
    { 
        get => gameData.MaxSpawnOffset; 
        set => MaxOffset = value; 
    }

    public float GetOffset()
    {
        bool isPlus = Random.Range(0, 100) % 2 == 0;
        float offset = Random.Range(MinOffset, MaxOffset);
        return (isPlus) ? offset : (-1 * offset);
    }

    public void Spawn()
    {
        Character player = characterFactory.GetCharacter(CharacterType.Player);
        player.transform.position = Vector3.zero;
        player.gameObject.SetActive(true);
        player.Initialize();
        player.LifeComponent.Initialize(player);
        player.LifeComponent.OnCharacterDeath += CharacterDeathHandler;
    }
    private void CharacterDeathHandler(Character deathCharacter)
    {
        switch (deathCharacter.CharacterType)
        {
            case CharacterType.Player:
                GameManager.Instance.GameOver();
                break;

            case CharacterType.DefaultEnemy:
                scoreSystem.AddScore(deathCharacter.CharacterData.ScoreCost);
                break;
        }

        deathCharacter.gameObject.SetActive(false);
        characterFactory.ReturnCharacter(deathCharacter);

        deathCharacter.LifeComponent.OnCharacterDeath -= CharacterDeathHandler;
    }
}
