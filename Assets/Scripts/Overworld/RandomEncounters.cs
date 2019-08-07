using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEncounters : MonoBehaviour
{
    [SerializeField] GameObject theOverWorld;
    [SerializeField] GameObject battleArea;
    [SerializeField] GameObject enemyTypeToSpawn;                     // Prefab of the enemy type which is to be spawned

    [SerializeField] Transform enemyBattlePosition;                   // Position the enemy is instanciate in the battle area
    [SerializeField] BattleManager manager;
    AudioManager manageSound;

    int spawnChance;                                                  // A random chance of encountering a enemy
    float gapBtwEncounters = 9;                                       // once player gets back from a battle the minimum gap before the next ecounter can happen
    bool recentlyencountered = false;                                 // To check if the player had a recent encounter


    private void Start()
    {
        manageSound = FindObjectOfType<AudioManager>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "TallGrass")                                 // Checking if colliding with tall grass so that it can there can be random enconters with mini enemies
        {
            spawnChance = Random.Range(0, 100);                      // Generating a random number between 0 and 99

            // Checking if recently encounterd enmey
            if (recentlyencountered)                                  
            {
                if (gapBtwEncounters > 0)                            // getting the gap between encounter timer to do its thing
                    gapBtwEncounters -= Time.deltaTime;
                else if (gapBtwEncounters <= 0)                      //if the timer hits 0 setting the player to be eligibal to more random encounters
                {
                    gapBtwEncounters = 9;
                    recentlyencountered = false;
                }
            }

            // if the player did not have a recent encounter and if so and the random numbet matches then ther will be an encounter triggered
            if ((spawnChance == 13||spawnChance == 53 || spawnChance == 93) && !recentlyencountered)  
            {
                manageSound.fadeToBattle = true;                         //For fade effect
                theOverWorld.SetActive(false);
                battleArea.SetActive(true);
                Instantiate(enemyTypeToSpawn, enemyBattlePosition.position, enemyBattlePosition.rotation);
                manager.Start();                                         // Running start functionin the manager which will set up the battle stats
                recentlyencountered = true;
            }
        }
    }
}
