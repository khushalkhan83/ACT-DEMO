﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaGuaManager : MonoBehaviour
{
    PlayerManager playerManager;
    PlayerStats playerStats;
    [SerializeField] GameObject BaGuaZhen;
    Sample_VFX sample_VFX_Ability;
    InputManager inputManager;
    public List<int> commandHolder = new List<int>();
    public string commandString;
    public int curPiviot;

    public int energyGuage;
    public float curEnergyCharge;
    [SerializeField] Image energyChargeSlot;
    [SerializeField] Image energyGuage_1;
    [SerializeField] Image energyGuage_2;
    [SerializeField] Image energyGuage_3;


    public Vector2 curPos;
    public GameObject realPiviot;

    [SerializeField] GameObject[] BaGuaText;
    [SerializeField] Transform spawnPos;
    [SerializeField] float spawnTimer;
    public bool isCommandActive;

    public bool healUnlock;
    public bool fireBallUnlock;
    public bool immuUnlock;

    void Awake()
    {
        playerManager = GetComponent<PlayerManager>();
        playerStats = GetComponent<PlayerStats>();
        inputManager = GetComponent<InputManager>();
        sample_VFX_Ability = GetComponentInChildren<Sample_VFX>();
        curPos = realPiviot.transform.position;
    }

    void Update()
    {
        EnergySourceControl();

        if (inputManager.baGua_Input && !isCommandActive)
        {
            BaGuaZhen.SetActive(true);
            realPiviot.transform.position = new Vector2(curPos.x + (inputManager.cameraInputX * 100), curPos.y + (inputManager.cameraInputY * 100));
            if (commandHolder.Count <= 3) 
            {
                if (inputManager.cameraInputX >= 0.99 && inputManager.cameraInputY >= -0.13 && inputManager.cameraInputY <= 0.13)
                {
                    BaGuaCommand(2);
                }
                else if (inputManager.cameraInputX <= -0.99 && inputManager.cameraInputY >= -0.13 && inputManager.cameraInputY <= 0.13)
                {
                    BaGuaCommand(6);
                }
                else if (inputManager.cameraInputY >= 0.99 && inputManager.cameraInputX >= -0.13 && inputManager.cameraInputX <= 0.13)
                {
                    BaGuaCommand(0);
                }
                else if (inputManager.cameraInputY <= -0.99 && inputManager.cameraInputX >= -0.13 && inputManager.cameraInputX <= 0.13)
                {
                    BaGuaCommand(4);
                }
                else if (inputManager.cameraInputX > 0.61 && inputManager.cameraInputX < 0.79 && inputManager.cameraInputY > 0.61 && inputManager.cameraInputX < 0.79)
                {
                    BaGuaCommand(1);
                }
                else if (inputManager.cameraInputX < -0.61 && inputManager.cameraInputX > -0.79 && inputManager.cameraInputY > 0.61 && inputManager.cameraInputX < 0.79)
                {
                    BaGuaCommand(7);
                }
                else if (inputManager.cameraInputX > 0.61 && inputManager.cameraInputX < 0.79 && inputManager.cameraInputY < -0.61 && inputManager.cameraInputX > -0.79)
                {
                    BaGuaCommand(3);
                }
                else if (inputManager.cameraInputX < -0.61 && inputManager.cameraInputX > -0.79 && inputManager.cameraInputY < -0.61 && inputManager.cameraInputX > -0.79)
                {
                    BaGuaCommand(5);
                }
            }

            if (inputManager.lockOn_Input)
            {
                commandHolder.Clear();
            }
        }
        else 
        {
            BaGuaZhen.SetActive(false);
            if (commandHolder.Count >= 2)
            {
                isCommandActive = true;
            }
            else 
            {
                if (!isCommandActive) 
                {
                    commandHolder.Clear();
                }
            }
        }

        if (isCommandActive) 
        {
            CommandActive();
        }
    }
    private void FixedUpdate()
    {
        spawnTimer -= Time.fixedDeltaTime;
        if (spawnTimer <= 0) 
        {
            spawnTimer = 0;
        }
    }
    void BaGuaCommand(int index)
    {
        if (commandHolder.Count == 0)
        {
            commandHolder.Add(index);
        }
        else if(commandHolder.Count <= 3)
        {
            if (index != commandHolder[commandHolder.Count - 1])
            {
                commandHolder.Add(index);
            }
        }
    }
    void CommandActive()
    {
        if (commandHolder.Count != 0)
        {
            if (spawnTimer <= 0) //生成字特效
            {
                GameObject baguaText = Instantiate(BaGuaText[commandHolder[0]], new Vector3(spawnPos.position.x, spawnPos.position.y, spawnPos.position.z), Quaternion.identity);
                Destroy(baguaText, 1f);
                spawnTimer = 0.45f;
                commandString += commandHolder[0].ToString();
                commandHolder.Remove(commandHolder[0]);
            }
        }
        else 
        {
            if (commandString == "42" && healUnlock)
            {
                //SFX
                if (energyGuage >= 1) 
                {
                    sample_VFX_Ability.curVFX_List[0].Play();
                    playerStats.currHealth += 20;
                    playerStats.healthBar.SetCurrentHealth(playerStats.currHealth);
                    energyGuage -= 1;
                }
            }
            else if (commandString == "03" && fireBallUnlock)
            {
                if (energyGuage >= 1)
                {
                    Debug.Log("FireBall");
                }
            }
            else if (commandString == "732" && immuUnlock)
            {
                if (energyGuage >= 2)
                {
                    Debug.Log("Immu");
                }
            }
            else 
            {
                Debug.Log(commandString);
            }

            commandString = null;
            isCommandActive = false;
        }
    }
    void EnergySourceControl() 
    {
        energyChargeSlot.fillAmount = curEnergyCharge / 100;

        if (curEnergyCharge >= 100)
        {
            if (energyGuage == 3)
            {
                curEnergyCharge = 100;
            }
            else 
            {
                curEnergyCharge -= 100;
                energyGuage += 1;
            }
        }

        if (energyGuage == 1) 
        {
            energyGuage_1.fillAmount = 1;
            energyGuage_2.fillAmount = 0;
            energyGuage_3.fillAmount = 0;
        }
        else if(energyGuage == 2)
        {
            energyGuage_1.fillAmount = 1;
            energyGuage_2.fillAmount = 1;
            energyGuage_3.fillAmount = 0;
        }
        else if(energyGuage == 3)
        {
            energyGuage_1.fillAmount = 1;
            energyGuage_2.fillAmount = 1;
            energyGuage_3.fillAmount = 1;
        }
        else
        {
            energyGuage_1.fillAmount = 0;
            energyGuage_2.fillAmount = 0;
            energyGuage_3.fillAmount = 0;
        }
    }
}
