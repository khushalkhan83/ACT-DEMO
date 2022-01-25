﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatStanceState : State
{
    public IdleState idleState;
    public AttackState attackState;
    public PursueState pursueState;
    public EnemyAttackAction[] enemyAttacks;
    public CombatCooldownManager combatCooldownManager;

    //特殊条件处理
    public List<SpecialCondition> conditionList;
    public bool specialConditionTriggered;

    bool canCounterAttack;
    public float walkingTimer;
    [SerializeField] bool notFirstWalking;
    [SerializeField] bool isWalkingStop;
    float distanceFromTarget;
    public bool randomDestinationSet = false;
    float verticalMovementVaule = 0;
    float horizontalMovementVaule = 0;

    [SerializeField] float defendRandomNum;

    public override State Tick(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
    {
        //确认单位与目标间的距离
        distanceFromTarget = Vector3.Distance(enemyManager.curTarget.transform.position, enemyManager.transform.position);
        enemyAnimatorManager.animator.SetFloat("Vertical", verticalMovementVaule, 0.2f, Time.deltaTime);
        enemyAnimatorManager.animator.SetFloat("Horizontal", horizontalMovementVaule, 0.2f, Time.deltaTime);
        attackState.hasPerformedAttack = false;
        SpecialActionWatcher(enemyManager);

        //if (enemyManager.curTarget.currHealth <= 0) //玩家死亡(临时的, 之后要改)
        //{
        //    enemyAnimatorManager.PlayTargetAnimation("Unarm", true, true);
        //    enemyManager.curTarget = null;
        //    return idleState;
        //}

        if (enemyManager.isInteracting) //首先确认是否处在互动状态
        {
            enemyAnimatorManager.animator.SetFloat("Vertical", 0);
            enemyAnimatorManager.animator.SetFloat("Horizontal", 0);
            return this;
        }

        if (distanceFromTarget > enemyManager.maxAttackRange && !enemyManager.isFirstStrike)//距离大于攻击范围后退回追踪状态
        {
            if (enemyManager.firstStrikeTimer <= 0)
            {
            }
            return pursueState;
        }

        if (specialConditionTriggered)
        {
            randomDestinationSet = false;
            return attackState;
        }

        DamageTakenWindow(enemyManager);

        if (!randomDestinationSet && !enemyManager.isFirstStrike) //如果不在踱步状态, 那就进入踱步状态(这块可以再优化)
        {
            randomDestinationSet = true;
            DecideCirclingAction(enemyManager, enemyAnimatorManager);
        }

        if (walkingTimer > 0) //实时改变行走逻辑
        {
            if (enemyManager.curRecoveryTime <= 0.5f && !isWalkingStop)//临攻击前0.5s会停止走路
            {
                GetNewAttack(enemyManager);
                ReadyToAttack(enemyManager);
            }
            else 
            {
                walkingTimer -= Time.fixedDeltaTime;
            }
        }
        else
        {
            WalkAroundTarget(enemyManager, enemyAnimatorManager);
        }

        HandleRotateTowardsTarger(enemyManager); //保持面对目标的朝向

        if (enemyManager.curRecoveryTime <= 0 && attackState.curAttack != null && !enemyManager.curTarget.GetComponent<PlayerManager>().cantBeInterrupted) //当踱步阶段结束, 当前无攻击，且玩家在非正在攻击状态时，进入攻击状态
        {
            walkingTimer = 0f;
            randomDestinationSet = false;
            notFirstWalking = false;
            isWalkingStop = false;
            return attackState;
        }

        return this;
    }

    public void HandleRotateTowardsTarger(EnemyManager enemyManager) //快速转向
    {
        Vector3 direction = enemyManager.curTarget.transform.position - transform.position;
        direction.y = 0;
        direction.Normalize();

        if (direction == Vector3.zero)
        {
            direction = transform.forward;
        }

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        enemyManager.transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, enemyManager.rotationSpeed);
    }
    private void DecideCirclingAction(EnemyManager enemyManager, EnemyAnimatorManager enemyAnimator)
    {
        WalkAroundTarget(enemyManager, enemyAnimator);
    }
    private void WalkAroundTarget(EnemyManager enemyManager, EnemyAnimatorManager enemyAnimator)
    {
        walkingTimer = 2f;
        defendRandomNum = Random.Range(0.001f, 1);
        Debug.Log(defendRandomNum);
        EnemyStats enemyStats = enemyManager.GetComponent<EnemyStats>();
        float defendProbility = (1-enemyStats.currHealth / enemyStats.maxHealth) * 0.5f * enemyManager.defensiveRatio;

        if (defendProbility >= 1)
        {
            defendProbility = 0.9f;
        }
        //无防御踱步
        if (!enemyManager.canDefend || defendRandomNum >= defendProbility)
        {
            if (!notFirstWalking)
            {
                //需要精修距离与最大攻击距离间的关系
                if (distanceFromTarget >= 0 && distanceFromTarget <= 3)
                {
                    verticalMovementVaule = -0.5f;
                }
                else if (distanceFromTarget > 3 && distanceFromTarget < 7f)
                {
                    verticalMovementVaule = 0;
                }
                else if (distanceFromTarget > 7f)
                {
                    verticalMovementVaule = 0.5f;
                }

                horizontalMovementVaule = Random.Range(-1, 1);
                if (horizontalMovementVaule <= 1 && horizontalMovementVaule >= 0)
                {
                    horizontalMovementVaule = 0.5f;
                }
                else if (horizontalMovementVaule >= -1 && horizontalMovementVaule < 0)
                {
                    horizontalMovementVaule = -0.5f;
                }
                notFirstWalking = true;
            }
            else
            {
                float randomNum = Random.Range(0.001f, 1f);
                if (randomNum <= 0.4f && !isWalkingStop)
                {
                    horizontalMovementVaule = 0f;
                    verticalMovementVaule = 0f;
                    isWalkingStop = true;
                    walkingTimer = 1f;
                }
                else 
                {
                    if (verticalMovementVaule < 0f)
                    {
                        if (distanceFromTarget > 3f)
                        {
                            verticalMovementVaule = 0f;
                        }
                    }
                    else if (verticalMovementVaule > 0f)
                    {
                        if (distanceFromTarget <= 7f)
                        {
                            verticalMovementVaule = 0f;
                        }
                    }
                    else if (verticalMovementVaule == 0f)
                    {
                        if (distanceFromTarget > 3f)
                        {
                            verticalMovementVaule = 0.5f;
                        }
                        else if (distanceFromTarget <= 3f)
                        {
                            verticalMovementVaule = -0.5f;
                        }
                    }

                    horizontalMovementVaule = Random.Range(-1, 1);
                    if (horizontalMovementVaule <= 1 && horizontalMovementVaule >= 0)
                    {
                        horizontalMovementVaule = 0.5f;
                    }
                    else if (horizontalMovementVaule >= -1 && horizontalMovementVaule < 0)
                    {
                        horizontalMovementVaule = -0.5f;
                    }

                    isWalkingStop = false;
                }
            }
        }
        else if (enemyManager.canDefend && defendRandomNum < defendProbility)
        //防御踱步
        {
            if (!notFirstWalking)
            {
                //需要精修距离与最大攻击距离间的关系
                if (distanceFromTarget >= 0 && distanceFromTarget <= 3)
                {
                    verticalMovementVaule = -0.5f;
                }
                else if (distanceFromTarget > 3 && distanceFromTarget < 7f)
                {
                    verticalMovementVaule = 0;
                }
                else if (distanceFromTarget > 7f)
                {
                    verticalMovementVaule = 0.5f;
                }

                horizontalMovementVaule = Random.Range(-1, 1);
                if (horizontalMovementVaule <= 1 && horizontalMovementVaule >= 0)
                {
                    horizontalMovementVaule = 2.5f;
                }
                else if (horizontalMovementVaule >= -1 && horizontalMovementVaule < 0)
                {
                    horizontalMovementVaule = 1.5f;
                }
                notFirstWalking = true;
            }
            else
            {
                float randomNum = Random.Range(0.001f, 1f);
                if (randomNum <= 0.4f && !isWalkingStop)
                {
                    horizontalMovementVaule = 2f;
                    verticalMovementVaule = 0f;
                    isWalkingStop = true;
                    walkingTimer = 1f;
                }
                else 
                {
                    if (verticalMovementVaule < 0f)
                    {
                        if (distanceFromTarget > 3f)
                        {
                            verticalMovementVaule = 0f;
                        }
                    }
                    else if (verticalMovementVaule > 0f)
                    {
                        if (distanceFromTarget <= 7f)
                        {
                            verticalMovementVaule = 0f;
                        }
                    }
                    else if (verticalMovementVaule == 0f)
                    {
                        if (distanceFromTarget > 3f)
                        {
                            verticalMovementVaule = 0.5f;
                        }
                        else if (distanceFromTarget <= 3f)
                        {
                            verticalMovementVaule = -0.5f;
                        }
                    }

                    horizontalMovementVaule = Random.Range(-1, 1);
                    if (horizontalMovementVaule <= 1 && horizontalMovementVaule >= 0)
                    {
                        horizontalMovementVaule = 2.5f;
                    }
                    else if (horizontalMovementVaule >= -1 && horizontalMovementVaule < 0)
                    {
                        horizontalMovementVaule = 1.5f;
                    }

                    isWalkingStop = false;
                }
            }
        }

    }
    private void ReadyToAttack(EnemyManager enemyManager) 
    {
        if (horizontalMovementVaule < 1) //普通走路
        {
            horizontalMovementVaule = 0f;
        }
        else //防御状态
        {
            horizontalMovementVaule = 2f;
        }

        verticalMovementVaule = 0f;
    }
    private void GetNewAttack(EnemyManager enemyManager) //根据距离和位置主动决策攻击(会进行权重测试)
    {
        Vector3 targetDirection = enemyManager.curTarget.transform.position - transform.position;
        float viewableAngle = Vector3.Angle(targetDirection, transform.forward);
        float distanceFromTarget = Vector3.Distance(enemyManager.curTarget.transform.position, transform.position);

        int maxScore = 0;

        if (!enemyManager.isFirstStrike) //非第一次攻击
        {
            for (int i = 0; i < enemyAttacks.Length; i++) //算总权重
            {
                EnemyAttackAction enemyAttackAction = enemyAttacks[i];

                if (distanceFromTarget <= enemyAttackAction.maxDistanceNeedToAttack && distanceFromTarget >= enemyAttackAction.minDistanceNeedToAttack)
                {
                    if (viewableAngle <= enemyAttackAction.maxAttackAngle && viewableAngle >= enemyAttackAction.minAttackAngle)
                    {
                        if (combatCooldownManager.regularAttackCooldownTimer[i] <= 0) //只算cd转好的攻击
                        {
                            maxScore += enemyAttackAction.attakPriority;
                        }
                    }
                }
            }

            int randomValue = Random.Range(0, maxScore);
            int tempScore = 0;

            for (int i = 0; i < enemyAttacks.Length; i++)
            {
                EnemyAttackAction enemyAttackAction = enemyAttacks[i];

                if (distanceFromTarget <= enemyAttackAction.maxDistanceNeedToAttack && distanceFromTarget >= enemyAttackAction.minDistanceNeedToAttack)
                {
                    if (viewableAngle <= enemyAttackAction.maxAttackAngle && viewableAngle >= enemyAttackAction.minAttackAngle)
                    {
                        if (combatCooldownManager.regularAttackCooldownTimer[i] <= 0) //只算cd转好的攻击
                        {
                            if (attackState.curAttack != null)
                                return;

                            tempScore += enemyAttackAction.attakPriority;

                            if (tempScore > randomValue)
                            {
                                attackState.curAttack = enemyAttackAction;
                                attackState.curRegularIndex = i;
                            }
                        }
                    }
                }
            }
        }
        else //第一次攻击
        {
            EnemyAttackAction enemyAttackAction = enemyAttacks[0];

            attackState.curAttack = enemyAttackAction;

            enemyManager.isFirstStrike = false;

            enemyManager.firstStrikeTimer = enemyManager.defaultFirstStrikeTime;
        }
    }
    void DamageTakenWindow(EnemyManager enemyManager) 
    {
        //受击后行动变化
        if (enemyManager.isDamaged)
        {
            enemyManager.isDamaged = false;
            //积累到一定程度后, 切换到格挡
            enemyManager.curRecoveryTime += 0.4f;
            horizontalMovementVaule = 2f;
            verticalMovementVaule = 0f;
            isWalkingStop = true;
            walkingTimer = 1f;
        }
        else if (enemyManager.isBlocking)
        {
            enemyManager.isBlocking = false;
            enemyManager.curRecoveryTime += 0.4f;
            horizontalMovementVaule = 2f;
            verticalMovementVaule = 0f;
            isWalkingStop = true;
            walkingTimer = 1f;
        }

    }
    void SpecialActionWatcher(EnemyManager enemyManager) 
    {
        if (conditionList != null) 
        {
            foreach (SpecialCondition specialCondition in conditionList) 
            {
                int index = conditionList.IndexOf(specialCondition);
                if (combatCooldownManager.specialAttackCooldownTimer[index] <= 0)
                {
                    if (specialCondition.condition == SpecialCondition.conditionType.距离型)
                    {
                        if (distanceFromTarget >= specialCondition.minRange && distanceFromTarget <= specialCondition.maxRange && enemyManager.curRecoveryTime>=specialCondition.requiredRecoveryTime)
                        {
                            attackState.curSpecialIndex = index;
                            attackState.curAttack = specialCondition;
                            specialConditionTriggered = true;
                        }
                    }
                    else if (specialCondition.condition == SpecialCondition.conditionType.玩家攻击型)
                    {
                        //if (randomDestinationSet && enemyManager.curTarget.GetComponent<PlayerManager>().isAttacking && canCounterAttack)
                        //{
                        //    enemyManager.isDodging = specialCondition.canDodge;
                        //    canCounterAttack = false;
                        //    attackState.curSpecialIndex = index;
                        //    attackState.curAttack = specialCondition;
                        //    specialConditionTriggered = true;
                        //}
                        if (randomDestinationSet && enemyManager.curTarget.GetComponent<PlayerManager>().isAttacking && distanceFromTarget <= 2.5f && !enemyManager.isParrying)
                        {
                            enemyManager.isDodging = specialCondition.canDodge;
                            canCounterAttack = false;
                            attackState.curSpecialIndex = index;
                            attackState.curAttack = specialCondition;
                            specialConditionTriggered = true;
                        }
                    }
                    else if (specialCondition.condition == SpecialCondition.conditionType.玩家蓄力硬直型)
                    {
                        if (randomDestinationSet && enemyManager.curTarget.GetComponent<PlayerManager>().isCharging && distanceFromTarget<=specialCondition.maxDistanceNeedToAttack) 
                        {
                            attackState.curSpecialIndex = index;
                            attackState.curAttack = specialCondition;
                            specialConditionTriggered = true;
                        }
                    }
                    else if (specialCondition.condition == SpecialCondition.conditionType.玩家防御型)
                    {

                    }
                    else if (specialCondition.condition == SpecialCondition.conditionType.飞行道具型)
                    {

                    }
                    else if (specialCondition.condition == SpecialCondition.conditionType.先制型) 
                    {
                        if (distanceFromTarget <= specialCondition.firstStrikeDistance && enemyManager.isFirstStrike) 
                        {
                            attackState.curSpecialIndex = index;
                            attackState.curAttack = specialCondition;
                            specialConditionTriggered = true;
                            enemyManager.firstStrikeTimer = enemyManager.defaultFirstStrikeTime;
                        }
                    }
                }
            }
        }
    }

}
