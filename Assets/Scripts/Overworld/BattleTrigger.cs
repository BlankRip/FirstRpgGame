using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTrigger : MonoBehaviour
{
    [SerializeField] GameObject theOverWorld;
    [SerializeField] GameObject battleArea;
    [SerializeField] GameObject enemyTypeToSpawn;                     // Prefab of the enemy type which is to be spawned

    [SerializeField] Transform enemyBattlePosition;                   // Position the enemy is instanciate in the battle area
    [SerializeField] BattleManager manager;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")                                    // Checking if player collied with enemy then moving to battle area and spawnin enemy
        {
            theOverWorld.SetActive(false);
            battleArea.SetActive(true);
            Instantiate(enemyTypeToSpawn, enemyBattlePosition.position, enemyBattlePosition.rotation);
            manager.Start();                                         // Running start functionin the manager which will set up the battle stats
            Destroy(gameObject);
        }
    }
}
