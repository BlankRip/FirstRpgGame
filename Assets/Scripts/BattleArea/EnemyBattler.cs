using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattler : MonoBehaviour
{
    BattleManager manager;
    AudioManager manageSounds;
    public int enemyHealth;
    [SerializeField] float attackDamage;
    float attackDamageCritical;
    int critChance;

    private void Start()
    {
        manager = FindObjectOfType<BattleManager>();
        manageSounds = FindObjectOfType<AudioManager>();
        attackDamageCritical = attackDamage + attackDamage * 0.25f;
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.enemyTurn == true)
        {
            if (manager.playerProtectionOn == false)
            {
                critChance = Random.Range(0, 10);
                if (critChance > 7)
                {
                    manager.playerHealth -= (int)attackDamageCritical;
                    manager.playerHealthBar.value = manager.playerHealth;
                    manager.DidPlayerDie();
                    print("<color=blue> my trun crit</color>");
                }
                else
                {
                    manager.playerHealth -= (int)attackDamage;
                    manager.playerHealthBar.value = manager.playerHealth;
                    manager.DidPlayerDie();
                    print("<color=blue> my trun</color>");
                }

            }
            else
                manageSounds.ProtectedSound();
                print("Protected");

            if (manager.turnesProtected > 0)
                manager.turnesProtected--;
            if (manager.turnesProtected <= 0)
                manager.playerProtectionOn = false;
            manager.playerTurn = true;
            manager.enemyTurn = false;
        }
    }
}
