﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : CharacterManager
{
    //PlayerManager统一管理所有当前所处的状态, 与locomotion, input, camera的update
    GameManager gameManager;
    Animator animator;
    InputManager inputManager;
    public CameraManager cameraManager;
    PlayerLocmotion playerLocmotion;
    PlayerStats playerStats;
    AnimatorManager animatorManager;
    WeaponSlotManager weaponSlotManager;
    [SerializeField] Sample_VFX sample_VFX;
    BaGuaManager baGuaManager;
    Rigidbody rig;

    [Header("运动状态")]
    public bool isInteracting;
    public bool isUsingRootMotion;

    public bool gameStart;
    public bool isFalling; //下落时
    public bool isGround; //在地面时
    public bool isCrouching; //下蹲时
    public bool isInGrass; //草丛里
    public bool isSprinting; 
    public bool isRolling;
    public bool isJumping; //跳跃上升阶段
    public bool inInteractTrigger;
    public bool interactObject;

    //通用
    public int keyNum;

    //战斗
    public bool isHitting;
    public bool attackRotate;
    public bool isAttacking;
    public bool isImmuAttack;
    public bool cantBeInterrupted;
    public bool isGettingDamage;
    public bool isDefending;
    float staminaRegenPauseTimer;
    public bool staminaRegenPause;
    public bool hitRecover;
    public bool isStunned;
    public bool damageAvoid;
    [SerializeField] ParryCollider parryCollider;

    //武器切换相关
    public bool katanaUnlock;
    public bool finalWeaponUnlock;
    public bool isWeaponSwitching;
    public float weaponSwitchCooldown;
    public Image cooldownTimer;
    float cooldownUnit;

    //太极系统
    int taiji_Guage;
    [SerializeField] TaijiDurationBar taijiDurationBar;
    [SerializeField] GameObject taijiBuff_VFX;
    float taijiBuffDuration;
    public float perfectTimer;
    public bool isPerfect;

    //蓄力攻击相关
    public bool isCharging;
    public bool isHolding;
    public bool isAttackDashing;

    //火球
    public FlyingObj fireBall;
    public Transform shootPos;
    public Transform target;
    public Transform nullTarget;

    //完美格挡ATField
    [SerializeField] GameObject aT_Field_Prefab;
    [SerializeField] Transform aT_position;

    [Header("TutorialRelated")]
    [SerializeField] GameObject wakeUp;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        cameraManager = FindObjectOfType<CameraManager>();
        animator = GetComponentInChildren<Animator>();
        inputManager = GetComponent<InputManager>();
        playerLocmotion = GetComponent<PlayerLocmotion>();
        playerStats = GetComponent<PlayerStats>();
        baGuaManager = GetComponent<BaGuaManager>();
        animatorManager = GetComponentInChildren<AnimatorManager>();
        weaponSlotManager = GetComponentInChildren<WeaponSlotManager>();
        parryCollider = GetComponentInChildren<ParryCollider>();
        rig = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (gameStart)
        {
            wakeUp.SetActive(true);
            playerStats.currHealth = 10;
            weaponSlotManager.mainWeapon_Unequipped.gameObject.SetActive(true);
            weaponSlotManager.mainArmedWeapon.SetActive(false);
            if (inputManager.interact_Input)
            {
                animator.SetTrigger("gameStart");
                inputManager.interact_Input = false;
                gameStart = false;
                wakeUp.SetActive(false);
            }
        }
        else 
        {
            weaponSlotManager.mainWeapon_Unequipped.gameObject.SetActive(false);
            weaponSlotManager.mainArmedWeapon.SetActive(true);
        }

        if (!isDead) 
        {
            inputManager.HandleAllInputs();
        }
        playerStats.StaminaRegen();
        GeneralTimerController();
        TaijiEffectController();
        PerfectTimer();
    }
    private void FixedUpdate()
    {
        if (!isDead)
        {
            if (!gameStart) 
            {
                playerLocmotion.HandleAllMovement();
            }
        }
        else 
        {
            rig.isKinematic = true;
            gameObject.GetComponent<Collider>().enabled = false;
            playerLocmotion.characterColliderBlocker.enabled = false;
            cameraManager.currentLockOnTarget = null;
            cameraManager.isLockOn = false;
            inputManager.lockOn_Flag = false;
            gameManager.PlayerDead();
        }
        cameraManager.HandleAllCameraMovement();
    }
    private void LateUpdate()
    {
        isInteracting = animator.GetBool("isInteracting");
        isAttacking = animator.GetBool("isAttacking");
        isUsingRootMotion = animator.GetBool("isUsingRootMotion");
        isCharging = animator.GetBool("isCharging");
        isHolding = animator.GetBool("isHolding");
        isWeak = animator.GetBool("isWeak");
        isDefending = animator.GetBool("isDefending");
        isGettingDamage = animator.GetBool("isGettingDamage");
        cantBeInterrupted = animator.GetBool("cantBeInterrupted");
        animator.SetBool("isStunned", isStunned);
        animator.SetBool("isGround", isGround); 
        animator.SetBool("isFalling", isFalling);
        inputManager.reAttack_Input = false;
        inputManager.interact_Input = false;
        inputManager.weaponSwitch_Input = false;
        HandleDefending();
        HoldingAction();
        ChargingAction();
    }
    private void GeneralTimerController() 
    {
        if (weaponSwitchCooldown > 0) 
        {
            weaponSwitchCooldown -= Time.deltaTime;
            cooldownTimer.fillAmount = weaponSwitchCooldown * cooldownUnit;
        }

        if (staminaRegenPauseTimer > 0)
        {
            staminaRegenPauseTimer -= Time.deltaTime;
            staminaRegenPause = true;
        }
        else 
        {
            staminaRegenPauseTimer = 0;
            staminaRegenPause = false;
        }

        if (taijiBuffDuration > 0)
        {
            taijiBuffDuration -= Time.deltaTime;
            taijiDurationBar.SetCurrentTime(taijiBuffDuration);
        }
        else 
        {
            taijiBuffDuration = 0;
            taijiDurationBar.SetCurrentTime(taijiBuffDuration);
            taiji_Guage = 0;
        }
    }
    public void GetDebuff(float duration) //当前只有stun
    {
        animatorManager.PlayTargetAnimation("StunTest", true);
        isStunned = true;
        rig.velocity = Vector3.zero;
        StartCoroutine(stunTimer(duration));
    }
    private void ChargingAction() //攻击蓄力
    {
        if (!isCharging)
        {
            inputManager.spAttack_Input = false;
        }
        else
        {
            inputManager.spAttack_Input = true;
        }
    }
    public void HandleRangeAttack()
    {
        var obj = Instantiate(fireBall, transform, false);
        obj.transform.SetParent(null);
        obj.gameObject.SetActive(true);
        obj.StartFlyingObj(target);
    }
    public void HandleDefending() 
    {
        if (isDefending)
        {
            parryCollider.EnableParryCollider();
        }
        else 
        {
            parryCollider.DisableParryCollider();
        }
    }
    public void HandleParryingCheck(int incomingDamage) 
    {
        float staminaDamage = (float)incomingDamage * 2f;
        if (staminaDamage <= playerStats.currStamina)
        {
            playerStats.currStamina -= staminaDamage;
            //animatorManager.PlayTargetAnimation("Defend(Success)", true, true);
            animator.SetTrigger("isDefendSuccess");
            staminaRegenPauseTimer = 1f;
        }
        else 
        {
            playerStats.currStamina = 0;
            //animatorManager.PlayTargetAnimation("Defend(Broken)", true, true);
            animator.SetTrigger("isDefendFailed");
            animatorManager.animator.SetBool("isDefending", false);
            inputManager.weaponAbility_Input = false;
        }
    }
    private void HoldingAction() //按键保持
    {
        //if (!isHolding)
        //{
        //    inputManager.weaponAbility_Input = false;
        //}
        //else 
        //{
        //    inputManager.weaponAbility_Input = true;
        //}
    }
    public void weaponEquiping(bool beDamaging = false) 
    {
        weaponSlotManager.EquipeWeapon();
    }
    public void WeaponSwitchTimerSetUp(float timer) 
    {
        weaponSwitchCooldown = timer;
        cooldownTimer.fillAmount = 1;
        cooldownUnit = 1 / timer;
    }
    public void PerfectTimer() 
    {
        if (perfectTimer>0) 
        {
            isPerfect = true;
            perfectTimer -= Time.deltaTime;
            if (perfectTimer <= 0) 
            {
                perfectTimer = 0;
                isPerfect = false;
            }
        }
    }
    void TaijiEffectController() 
    {
        if (taiji_Guage == 2)
        {
            taijiBuff_VFX.SetActive(true);
            //攻击模组变化
            //消耗减少
            //移动速度上升
        }
        else 
        {
            taijiBuff_VFX.SetActive(false);
        }
    }
    public void PerfectBlockCheck() 
    {
        if (taiji_Guage == 2)
        {
            isWeaponSwitching = false;
            animatorManager.PlayTargetAnimation("WeaponAbility_01(Success)", true, true);
            GameObject AT_Field_Temp = Instantiate(aT_Field_Prefab, aT_position.position, Quaternion.identity);
            sample_VFX.baGuaRelated_List[0].Stop();
            sample_VFX.baGuaRelated_List[1].Play();
            AT_Field_Temp.transform.SetParent(null);
            WeaponSwitchTimerSetUp(2.5f);
            taijiBuffDuration = 0;
            taiji_Guage = 0;
        }
        else 
        {
            taiji_Guage += 1;
            taijiBuffDuration = 10f;
            taijiDurationBar.SetMaxTime(taijiBuffDuration);
        }
    }
    public void Rest() 
    {
        if (isDead)
        {
            isDead = false;
            rig.isKinematic = false;
            gameObject.GetComponent<Collider>().enabled = true;
            playerLocmotion.characterColliderBlocker.enabled = true;
            playerStats.currHealth = playerStats.maxHealth;
            playerStats.currStamina = 150f;
            baGuaManager.curEnergyCharge = 0f;
            baGuaManager.energyGuage = 1;
        }
        else 
        {
            animatorManager.generalAudio.volume = 0.3f;
            animatorManager.generalAudio.clip = animatorManager.sample_SFX.checkPoint_Heal[0];
            animatorManager.generalAudio.Play();
            playerStats.currHealth = playerStats.maxHealth;
            playerStats.currStamina = 150f;
            if (baGuaManager.energyGuage < 1) 
            baGuaManager.energyGuage = 1;
        }
    }
    IEnumerator stunTimer(float dur) //播放器暂停
    {
        yield return new WaitForSecondsRealtime(dur);
        isStunned = false;
    }
}
