using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTrigger : MonoBehaviour
{
    [SerializeField] GameObject theOverWorld;
    [SerializeField] GameObject battleArea;
    [SerializeField] GameObject enemyTypeToSpawn;                     // Prefab of the enemy type which is to be spawned

    [SerializeField] Transform enemyBattlePosition;                   // Position the enemy is instanciate in the battle area
    [SerializeField] AudioSource overWorldSource;                     // Audio source for the audio responsibel in the over-world
    [SerializeField] AudioSource battleSource;                        // Audio source for the audio responsibel in the battle area
    [SerializeField] BattleManager manager;
    [SerializeField] AudioManager manageSound;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")                                    // Checking if player collied with enemy then moving to battle area and spawnin enemy
        {
            StartCoroutine(manageSound.FadeIn(battleSource, overWorldSource, 0.38f, 0.3f));                //For fade effect
            theOverWorld.SetActive(false);
            battleArea.SetActive(true);
            Instantiate(enemyTypeToSpawn, enemyBattlePosition.position, enemyBattlePosition.rotation);
            manager.Start();                                         // Running start functionin the manager which will set up the battle stats
            Destroy(gameObject);
        }
    }
}
