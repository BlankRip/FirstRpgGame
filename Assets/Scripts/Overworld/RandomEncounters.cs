using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEncounters : MonoBehaviour
{
    [SerializeField] GameObject theOverWorld;
    [SerializeField] GameObject battleArea;
    [SerializeField] Transform enemyBattlePosition;
    [SerializeField] GameObject enemyTypeToSpawn;
    [SerializeField] BattleManager manager;
    int spawnChance;
    float gapBtwEncounters = 1.5f;
    bool recentlyencountered = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "TallGrass")
        {
            spawnChance = Random.Range(0, 100);
            if(recentlyencountered)
            {
                if (gapBtwEncounters > 0)
                    gapBtwEncounters -= Time.deltaTime;
                else if (gapBtwEncounters <= 0)
                {
                    gapBtwEncounters = 1.5f;
                    recentlyencountered = false;
                }
            }
            if ((spawnChance == 13||spawnChance == 53 || spawnChance == 93) && !recentlyencountered)
            {
                theOverWorld.SetActive(false);
                battleArea.SetActive(true);
                Instantiate(enemyTypeToSpawn, enemyBattlePosition.position, enemyBattlePosition.rotation);
                manager.Start();
                recentlyencountered = true;
            }
        }
    }
}
