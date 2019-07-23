using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTrigger : MonoBehaviour
{
    [SerializeField] GameObject theOverWorld;
    [SerializeField] GameObject battleArea;
    [SerializeField] Transform enemyBattlePosition;
    [SerializeField] GameObject enemyTypeToSpawn;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            transform.position = enemyBattlePosition.position;
            theOverWorld.SetActive(false);
            battleArea.SetActive(true);
            Instantiate(enemyTypeToSpawn, enemyBattlePosition.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
