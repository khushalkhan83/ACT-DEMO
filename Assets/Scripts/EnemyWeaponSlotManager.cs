﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponSlotManager : MonoBehaviour
{
    public EnemyManager enemyManager;
    public WeaponItem weaponItem;
    [SerializeField] GameObject UnequipWeapon;

    public WeaponSlot equippedSlot;
    public DamageCollider weaponDamageCollider;
    public Damager flyingObjectDamager;

    private void Awake()
    {
        enemyManager = GetComponentInParent<EnemyManager>();
        WeaponSlot[] weaponSlots = GetComponentsInChildren<WeaponSlot>();
        foreach (WeaponSlot weapon in weaponSlots)
        {
            equippedSlot = weapon;
        }
    }
    private void Start()
    {
        //if (weaponItem != null)
        //{
        //    LoadWeaponOnSlot(weaponItem);
        //}
    }
    public void LoadWeaponOnSlot(WeaponItem weaponItem)
    {
        equippedSlot.LoadWeaponModel(weaponItem);
        LoadWeaponDamageCollider();
    }

    private void LoadWeaponDamageCollider()
    {
        weaponDamageCollider = equippedSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
    }


    private void OpenWeaponDamageCollider() //在animator里管理开启武器伤害碰撞器
    {
        weaponDamageCollider.EnableDamageCollider();
    }

    private void CloseWeaponDamageCollider() //在animator里管理关闭武器伤害碰撞器
    {
        weaponDamageCollider.DisableDamageCollider();
    }

    private void RangeAttack() 
    {
        enemyManager.HandleRangeAttack();
    }

    private void RangeAttack2()
    {
        enemyManager.HandleRangeAttack2();
    }

    private void AttackOver()
    {
        enemyManager.isImmuneAttacking = false;
    }

    void WeaponEquip() 
    {
        if (equippedSlot.currentWeaponModel == null)
        {
            LoadWeaponOnSlot(weaponItem);
            enemyManager.isEquipped = true;
            if (UnequipWeapon != null) 
            {
                UnequipWeapon.SetActive(false);
            }
        }
        else 
        {
            equippedSlot.UnloadWeapon();
            enemyManager.isEquipped = false;
            if (UnequipWeapon != null)
            {
                UnequipWeapon.SetActive(true);
            }
        }
    }
}
