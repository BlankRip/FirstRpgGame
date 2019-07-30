﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    [Header("Stuff requied to swithch back to Overworld")]
    [SerializeField] GameObject overWorld;
    [SerializeField] GameObject battleArea;
    [SerializeField] GameObject BattleWonScreen;
    AudioManager manageSounds;

    [Header("Stuff used in battle area")]
    //To track whos turn it is
    public bool playerTurn;
    public bool enemyTurn;

    //UI and stuff in battle
    [HideInInspector] public bool playerProtectionOn;                   //If the player is under the influance of the defence spell
    [HideInInspector] public int playerHealth;                          //Player's health value
    [HideInInspector] public int turnesProtected;                       // The number of turns the protection influance will last for at an instance
    [HideInInspector] public EnemyBattler currentBattler;               // The enemy gameobject
    [SerializeField] GameObject playerBattleUI;                         //Player's battle options

    // The health bars for the player and enemy
    public Slider playerHealthBar;
    public Slider enemyHealthBar;

    [Header("For Game over")]
    [SerializeField] Animator animate;
    [SerializeField] GameObject gameOverScreen;




    // Start is called before the first frame update
    public void Start()
    {
        playerTurn = true;
        enemyTurn = false;
        playerProtectionOn = false;
        currentBattler = FindObjectOfType<EnemyBattler>();
        manageSounds = GetComponent<AudioManager>();
        playerHealth = 100;
        playerHealthBar.maxValue = playerHealth;
        playerHealthBar.value = playerHealth;
        enemyHealthBar.maxValue = currentBattler.enemyHealth;
        enemyHealthBar.value = currentBattler.enemyHealth;
    }

    // Update is called once per frame
    void Update()
    {
        // Displaying the battle options if it is the player's turn
        if (playerTurn)
            playerBattleUI.SetActive(true);
        else
            playerBattleUI.SetActive(false);
    }


    //Function to check if the enemy is dead
    public void DidEnemyDie()
    {
        if(currentBattler.enemyHealth <= 0)
        {
            manageSounds.VictorySound();
            Destroy(currentBattler.gameObject);
            BattleWonScreen.SetActive(true);                     // Show victory screen if the enemy dies
        }
    }


    //Function to check if the player is dead
    public void DidPlayerDie()
    {
        if(playerHealth <= 0)
        {
            manageSounds.DeathSound();
            animate.SetBool("Died", true);
            gameOverScreen.SetActive(true);                       //Show game-over screen if the player dies
        }
    }


    //Function to return to the overworld after the battle
    public void BackToWorld()
    {
        BattleWonScreen.SetActive(false);
        overWorld.SetActive(true);
        battleArea.SetActive(false);
    }


    //Function to load maenu screen when it is game-over
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
