﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlotManager : MonoBehaviour
{
    PlayerManager playerManager;
    Animator animator;
    [SerializeField] Sample_VFX sample_VFX;

    public WeaponSlot mainWeapon_Unequipped;
    public WeaponSlot[] weaponSlots = new WeaponSlot[2];

    public DamageCollider weaponDamageCollider;
    [SerializeField] ParryCollider parryCollider;
    public GameObject mainArmedWeapon;
    [SerializeField] GameObject[] armedWeaponSlot = new GameObject[2];

    [SerializeField] GameObject greatSwordIcon;
    [SerializeField] GameObject katanaIcon;


    private void Awake()
    {
        playerManager = GetComponentInParent<PlayerManager>();
        animator = GetComponent<Animator>();
        weaponSlots = GetComponentsInChildren<WeaponSlot>();
        foreach(WeaponSlot weapon in weaponSlots) 
        {
            mainWeapon_Unequipped = weaponSlots[0];
        }
        mainArmedWeapon = armedWeaponSlot[0];
    }
    public void LoadWeaponOnSlot(WeaponItem weaponItem, int index) 
    {
        if (index == 0)
        {
            weaponSlots[0].LoadWeaponModel(weaponItem);
        }
        else 
        {
            weaponSlots[1].LoadWeaponModel(weaponItem);
        }
    }
    public void EquipeWeapon() 
    {
        mainWeapon_Unequipped.gameObject.SetActive(false);
        mainArmedWeapon.SetActive(true);
    }
    public void WeaponSwitch() 
    {
        if (playerManager.GetComponent<PlayerInventory>().unequippedWeaponItems.Length == 2 && playerManager.weaponSwitchCooldown <=0) 
        {
            if (!playerManager.isAttacking && !playerManager.isInteracting)
            {
                GetComponentInChildren<WeaponSlotManager>().mainArmedWeapon.SetActive(false);
                GetComponentInChildren<WeaponSlotManager>().mainWeapon_Unequipped.gameObject.SetActive(true);
                WeaponSwitchAnimatorController();
                playerManager.isWeaponSwitching = true;
            }
            else if(playerManager.isAttacking) 
            {
                GetComponentInChildren<WeaponSlotManager>().mainArmedWeapon.SetActive(false);
                GetComponentInChildren<WeaponSlotManager>().mainWeapon_Unequipped.gameObject.SetActive(true);
                WeaponSwitchAnimatorController();
                playerManager.isWeaponSwitching = true;
            }
        }
    }
    private void WeaponSwitchTimerSetup() 
    {
        playerManager.isWeaponSwitching = false;
        playerManager.WeaponSwitchTimerSetUp(2.5f);
    }
    public void WeaponSwitchAnimatorController() 
    {
        if (!playerManager.isGettingDamage) 
        {
            if (mainWeapon_Unequipped == weaponSlots[0])
            {
                playerManager.GetComponent<PlayerInventory>().currentWeaponIndex = 1;
                playerManager.perfectTimer = 1.1f;
                mainWeapon_Unequipped = weaponSlots[1];
                mainArmedWeapon = armedWeaponSlot[1];
                transform.GetComponent<Animator>().runtimeAnimatorController = playerManager.GetComponent<PlayerInventory>().unequippedWeaponItems[1].weaponAnimatorController;
                transform.GetComponent<AnimatorManager>().PlayTargetAnimation("WeaponSwitch(Equip)", true, true);
                //playerManager.isWeaponEquipped = true;
                sample_VFX.baGuaRelated_List[0].Play();
                greatSwordIcon.SetActive(false);
                katanaIcon.SetActive(true);
            }
            else
            {
                playerManager.GetComponent<PlayerInventory>().currentWeaponIndex = 0;
                playerManager.perfectTimer = 1.1f;
                mainWeapon_Unequipped = weaponSlots[0];
                mainArmedWeapon = armedWeaponSlot[0];
                transform.GetComponent<Animator>().runtimeAnimatorController = playerManager.GetComponent<PlayerInventory>().unequippedWeaponItems[0].weaponAnimatorController;
                transform.GetComponent<AnimatorManager>().PlayTargetAnimation("WeaponSwitch(Equip)", true, true);
                //playerManager.isWeaponEquipped = true;
                sample_VFX.baGuaRelated_List[0].Play();
                greatSwordIcon.SetActive(true);
                katanaIcon.SetActive(false);
            }
        }
    }
    #region Handle Weapon's Damage Collider
    private void LoadWeaponDamageCollider() //读取当前所使用的武器
    {
        weaponDamageCollider = mainArmedWeapon.GetComponentInChildren<DamageCollider>();
    }
    private void OpenWeaponDamageCollider() //在动画器中开启对应武器的碰撞器
    {
        weaponDamageCollider.EnableDamageCollider();
    }
    private void OpenParryCollider() //在动画器中开启对应武器的碰撞器
    {
        parryCollider.EnableParryCollider();
    }
    private void OpenVFXCollider (DamageCollider collider) //在动画器中开启对应VFX的碰撞器
    {
        collider.EnableDamageCollider();
    }
    private void CloseWeaponDamageCollider() //在动画器中关闭对应武器的碰撞器
    {
        weaponDamageCollider.DisableDamageCollider();
    }
    private void CloseParryCollider() //在动画器中关闭对应武器的碰撞器
    {
        parryCollider.DisableParryCollider();
    }
    private void PerfectParryOn() 
    {
        parryCollider.PerfectTiming();
    }
    private void CloseVFXCollider(DamageCollider collider) //在动画器中关闭对应VFX的碰撞器
    {
        collider.DisableDamageCollider();
    }
    private void AttackOver() //确定何时提前关闭玩家当前的攻击状态
    {
        animator.SetBool("cantBeInterrupted", false);
        playerManager.isImmuAttack = false;
    }
    private void ImmuOver() 
    {
        playerManager.isImmuAttack = false;
    }
    #endregion
}
