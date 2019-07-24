using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public bool playerTurn;
    public bool enemyTurn;
    [HideInInspector] public int playerHealth;
    EnemyBattler currentBattler;
    [SerializeField] GameObject playerBattleUI;
    public Slider playerHealthBar;
    public Slider enemyHealthBar;


    // Start is called before the first frame update
    public void Start()
    {
        playerTurn = true;
        enemyTurn = false;
        currentBattler = FindObjectOfType<EnemyBattler>();
        playerHealth = 100;
        playerHealthBar.maxValue = playerHealth;
        playerHealthBar.value = playerHealth;
        enemyHealthBar.maxValue = currentBattler.enemyHealth;
        enemyHealthBar.value = currentBattler.enemyHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTurn)
            playerBattleUI.SetActive(true);
        else
            playerBattleUI.SetActive(false);
    }
}
