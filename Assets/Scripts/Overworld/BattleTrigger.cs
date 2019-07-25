using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTrigger : MonoBehaviour
{
    [SerializeField] GameObject theOverWorld;
    [SerializeField] GameObject battleArea;
    [SerializeField] Transform enemyBattlePosition;
    [SerializeField] GameObject enemyTypeToSpawn;
    [SerializeField] BattleManager manager;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag== "Player")
        {
            theOverWorld.SetActive(false);
            battleArea.SetActive(true);
            Instantiate(enemyTypeToSpawn, enemyBattlePosition.position, enemyBattlePosition.rotation);
            manager.Start();
            Destroy(gameObject);
        }
    }
}
