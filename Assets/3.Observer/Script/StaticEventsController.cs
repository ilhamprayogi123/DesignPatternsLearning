using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Observer
{
    public class StaticEventsController : MonoBehaviour
    {
        public Enemy enemyPrefab;

        private int score;

        private int enemiesKilled = 0;

        void Awake()
        {
            Enemy.onAnyEnemyDie += addToScore;   
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //Spawn new enemies that will die after some time
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject newEnemy = Instantiate(enemyPrefab.gameObject, Random.insideUnitSphere, Quaternion.identity) as GameObject;

                //Kill the enemy automatically after 3 seconds which will trigger the event
                Destroy(newEnemy, 3f);
            }
        }

        void addToScore(Enemy enemyScript)
        {
            score += enemyScript.enemyValue;

            enemiesKilled += 1;

            Debug.Log($"You've killed {enemiesKilled} enemies and the score is: {score}");
        }
    }
}


