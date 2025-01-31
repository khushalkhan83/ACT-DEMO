using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    CharacterManager characterManager;

    public int maxHealth;
    public int currHealth;
    public Transform eyePos;

    public float currStamina;
    public float maxStamina = 100;
    [SerializeField] protected float staminaRegen = 5;

    private void Update()
    {
        if (currHealth >= maxHealth) 
        {
            currHealth = maxHealth;
        }

        if (currStamina >= maxStamina) 
        {
            currStamina = maxStamina;  
        }
    }
}
