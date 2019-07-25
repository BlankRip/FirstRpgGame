using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    [Header("Stuff requied to swithch back to Overworld")]
    [SerializeField] GameObject overWorld;
    [SerializeField] GameObject battleArea;

    [Header("Stuff used in battle area")]
    public bool playerTurn;
    public bool enemyTurn;
    [HideInInspector] public int playerHealth;
    [HideInInspector] public bool playerProtectionOn;
    [HideInInspector] public int turnesProtected;
    [HideInInspector] public EnemyBattler currentBattler;
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

    public void DidEnemyDie()
    {
        if(currentBattler.enemyHealth <= 0)
        {
            Destroy(currentBattler.gameObject);
            overWorld.SetActive(true);
            battleArea.SetActive(false);
        }
    }

    public void DidPlayerDie()
    {
        if(playerHealth <= 0)
        {
            print("Here game over screen will happen");
        }
    }
}
