using System.Collections.Generic;
using com.ootii.Messages;
using UnityEngine;

namespace BonusLevel.HackNSlash.Game
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField]
        private Transform enemy;

        [Space(10)]
        [Header("Reference positions")]
        public Transform leftSpawn;
        public Transform rightSpawn;
        public Transform leftTarget;
        public Transform rightTarget;

        private Vector2 leftSpawnPosition;
        private Vector2 rightSpawnPosition;
        private Vector2 leftTargetPosition;
        private Vector2 rightTargetPosition;

        private float enemySpeed;
        private float timeToTarget;
        private float timeToSpawn;

        private List<Enemy> currentEnemies;

        private float perfectArea;

        private void Start()
        {
            Init();
            MessageDispatcher.AddListener(GameEvents.SPAWN, Spawn);
            MessageDispatcher.AddListener(GameEvents.LEFT_TOUCH, DestroyEnemy);
            //MessageDispatcher.AddListener(GameEvents.START_GAME, OnGameStarted);
        }

        private void Init()
        {
            currentEnemies = new List<Enemy>();

            //Cache position of the Transform, because we don't need the Transform itself
            leftSpawnPosition = leftSpawn.position;
            rightSpawnPosition = rightSpawn.position;
            leftTargetPosition = leftTarget.position;
            rightTargetPosition = rightTarget.position;

            //Some calculations
            enemySpeed = 60 / GameController.Instance.bpm;
            perfectArea = leftTarget.GetComponent<BoxCollider2D>().size.y;
            //Debug.Log("Enemy Speed : " + enemySpeed);
            float distance = GameController.Instance.distance;
            //Vector2.Distance(leftSpawnPosition, leftTargetPosition);
            //Debug.Log("Distance to travel : " + distance);
            timeToTarget = enemySpeed * distance;
        }

        //public void OnGameStarted(IMessage message)
        //{
        //    InvokeRepeating("Spawn", enemySpeed, enemySpeed);
        //}

        private void Update()
        {
        }

        public void Spawn(IMessage message)
        {
            Enemy currentEnemy = Instantiate(enemy, leftSpawnPosition, Quaternion.identity).GetComponent<Enemy>();
            currentEnemy.Init(leftTargetPosition, timeToTarget);
            currentEnemies.Add(currentEnemy);
        }

        public void DestroyEnemy(IMessage message)
        {
            if (currentEnemies.Count <= 0)
                return;
            float distance = leftTarget.transform.position.x - currentEnemies[0].gameObject.transform.position.x;

            if(distance >0 && distance<0.5)
            {
                if (distance <= 0.5 && distance >= 0.2)
                    Debug.Log("perfect");
                else
                    Debug.Log("good");
                currentEnemies[0].DestroyEnemy();
                currentEnemies.RemoveAt(0);
            }
            
        }
    }
}