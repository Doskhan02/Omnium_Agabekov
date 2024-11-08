using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int scoreCost;
    [SerializeField] private float timeBetweenDamage;
    [SerializeField] private Transform characterTransform;
    [SerializeField] private CharacterController characterController;

    public float DefaultSpeed => speed;
    public int ScoreCost => scoreCost;
    public float TimeBetweenDamage => timeBetweenDamage;
    public Transform CharacterTransform => characterTransform;
    public CharacterController CharacterController 
    { 
        get 
        { 
            return characterController; 
        } 
    }
}
