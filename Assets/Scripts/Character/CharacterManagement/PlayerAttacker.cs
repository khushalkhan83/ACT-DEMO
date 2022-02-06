﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    InputManager inputManager;
    PlayerManager playerManager;
    PlayerLocmotion playerLocmotion;
    AnimatorManager animatorManager;
    WeaponSlotManager weaponSlotManager;

    public Sample_VFX sample_VFX_R;
    public Sample_VFX sample_VFX_S;

    //处决
    public Collider[] colliders;
    public EnemyManager executionTarget;
    [SerializeField] Vector3 executionOffset;

    //普通攻击
    public int comboCount;
    public float attackTimer;
    public float internalDuration = 1.5f;
    //蓄力攻击
    public float chargingTimer;
    public int chargingLevel;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerManager = GetComponent<PlayerManager>();
        playerLocmotion = GetComponent<PlayerLocmotion>();
        animatorManager = GetComponentInChildren<AnimatorManager>();
        weaponSlotManager = GetComponentInChildren<WeaponSlotManager>();
    }
    private void Update()
    {
        AttackComboTimer();
        ChargingTimer();
        HoldingStatus();
        ExecutionHandler();
    }
    public void HandleRegularAttack(WeaponItem weapon) //左键普攻
    {
        //使用指定武器信息中的普通攻击
        if (!playerManager.cantBeInterrupted && playerManager.isGround && !playerManager.isGettingDamage) 
        {
            playerLocmotion.HandleRotateTowardsTarger();
            playerManager.cantBeInterrupted = true;
            animatorManager.animator.SetBool("isAttacking", true);
            attackTimer = internalDuration;

            //可处决
            if (executionTarget) //无消耗
            {
                animatorManager.PlayTargetAnimation(weapon.executionSkill[0].skillName, true, true); //处决
                weaponSlotManager.mainArmedWeapon.GetComponentInChildren<DamageCollider>().curDamage = weapon.executionSkill[0].damagePoint;
                executionTarget.HandleExecuted(weapon.executionSkill[1].skillName);
                //sample_VFX_R.curVFX_List[comboCount - 1].Play();
            }
            //普通攻击
            else 
            {
                comboCount++;
                if (comboCount > 3)
                {
                    comboCount = 1;
                }
                //播放指定的攻击动画
                animatorManager.PlayTargetAnimation(weapon.regularSkills[comboCount - 1].skillName, true, true);
                weaponSlotManager.mainArmedWeapon.GetComponentInChildren<DamageCollider>().curDamage = weapon.regularSkills[comboCount - 1].damagePoint;
                weaponSlotManager.mainArmedWeapon.GetComponentInChildren<DamageCollider>().energyRestoreAmount = weapon.regularSkills[comboCount - 1].energyRestore;
                playerManager.GetComponent<PlayerStats>().currStamina -= weapon.regularSkills[comboCount - 1].staminaCost;
                //sample_VFX_R.curVFX_List[comboCount - 1].Play();
            }
        }
    }
    public void HandleSpecialAttack(WeaponItem weapon) //右键特殊攻击
    {
        playerLocmotion.HandleRotateTowardsTarger();
        if (!playerManager.cantBeInterrupted && playerManager.isGround && !playerManager.isGettingDamage)
        {
            playerManager.cantBeInterrupted = true;
            animatorManager.animator.SetBool("isAttacking", true);
            attackTimer = internalDuration;
            if (comboCount == 0)
            {
                //右键的第一下就是普通的第一下
                animatorManager.PlayTargetAnimation(weapon.regularSkills[comboCount].skillName, true, true);
                comboCount++;
            }
            else
            {
                ////其余都播放特殊攻击的动作
                animatorManager.PlayTargetAnimation(weapon.specialSkills[comboCount - 1].skillName, true, true);
                weaponSlotManager.mainArmedWeapon.GetComponentInChildren<DamageCollider>().curDamage = weapon.regularSkills[comboCount - 1].damagePoint;
                weaponSlotManager.mainArmedWeapon.GetComponentInChildren<DamageCollider>().energyRestoreAmount = weapon.regularSkills[comboCount - 1].energyRestore;
                playerManager.GetComponent<PlayerStats>().currStamina -= weapon.regularSkills[comboCount - 1].staminaCost;
                sample_VFX_S.curVFX_List[comboCount - 1].Play();
                comboCount = 0;
            }
        }
        //rig.velocity = new Vector3(0, rig.velocity.y, 0);
    }
    public void HandleWeaponAbility(WeaponItem weapon) //武器技能
    {
        playerLocmotion.HandleRotateTowardsTarger();
        if (!playerManager.cantBeInterrupted && playerManager.isGround && !playerManager.isAttacking )  
        {
            playerManager.cantBeInterrupted = true;
            animatorManager.animator.SetBool("isAttacking", true);
            attackTimer = internalDuration;

            animatorManager.PlayTargetAnimation(weapon.weaponAbilities[0].skillName, true, true);
        }
    }
    public void AttackComboTimer() 
    {
        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0)
        {
            attackTimer = 0;
            comboCount = 0;
        }
    }
    public void ChargingTimer() //蓄力计时器(当前只针对特殊攻击1的情况进行了使用)
    {
        if (inputManager.spAttack_Input)
        {
            if (chargingLevel != 3)
            {
                if (playerManager.isCharging)
                {
                    chargingTimer += Time.deltaTime;
                    if (chargingTimer >= 1)
                    {
                        chargingTimer = 0;
                        animatorManager.PlayTargetAnimation("Combo_S_01(Enhance)", true, true);
                    }
                }
            }
            else 
            {
                //释放L3攻击
                animatorManager.PlayTargetAnimation("Combo_S_01(Level3Temp)", true, true);
                animatorManager.animator.SetBool("isCharging", false);
                chargingLevel = 0;
            }
        }
        else if(!inputManager.spAttack_Input && playerManager.isCharging)
        {
            chargingTimer = 0;
            if (chargingLevel > 0)
            {
                if (chargingLevel == 1)
                {
                    animatorManager.animator.SetBool("isCharging", false);
                    animatorManager.PlayTargetAnimation("Combo_S_01(Level1)", true, true);
                    chargingLevel = 0;
                }
                else if (chargingLevel == 2)
                {
                    animatorManager.animator.SetBool("isCharging", false);
                    animatorManager.PlayTargetAnimation("Combo_S_01(Level2)", true, true);
                    chargingLevel = 0;
                }
            }
            else 
            {
                animatorManager.animator.SetBool("isCharging", false);
                animatorManager.PlayTargetAnimation("Combo_S_01(End)", true, true);
            }
        }
    }

    public void HoldingStatus() 
    {
        if (!inputManager.weaponAbility_Input && playerManager.isHolding) 
        {
            animatorManager.animator.SetBool("isHolding", false);
            playerManager.cantBeInterrupted = false;
            //animatorManager.PlayTargetAnimation("WeaponAbility_01(End)", true, true);
        }
    }

    void ExecutionHandler() 
    {
        colliders = Physics.OverlapSphere(transform.position + executionOffset, 4f);

        if (colliders != null)
        {
            foreach (Collider collider in colliders) 
            {
                if (collider.GetComponent<EnemyManager>() != null) 
                {
                    EnemyManager enemyManager = collider.GetComponent<EnemyManager>();
                    if (enemyManager.isWeak)
                    {
                        executionTarget = enemyManager;
                    }
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + executionOffset, 4f);
    }
}
