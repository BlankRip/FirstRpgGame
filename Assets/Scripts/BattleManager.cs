using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public bool playerTurn;
    public bool enemyTurn;
    [HideInInspector] public int playerHealth;
    EnemyBattler currentBattler;
    [SerializeField] GameObject playerBattleUI;


    // Start is called before the first frame update
    public void Start()
    {
        playerTurn = true;
        enemyTurn = false;
        currentBattler = FindObjectOfType<EnemyBattler>();
        playerHealth = 100;
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
