using com.ootii.Messages;
using UnityEngine;

namespace BonusLevel.HackNSlash.Game
{
    public class BeatManager : MonoBehaviour
    {
        public int[] beats = new int[100];
        public int currentBeat = 0;

        private float enemySpeed;
        private float timeToTarget;
        private float timeToSpawn;

        private void Start()
        {
            Init();
            MessageDispatcher.AddListener(GameEvents.START_GAME, OnGameStarted);
        }

        private void Init()
        {
            //Some calculations
            enemySpeed = 60 / GameController.Instance.bpm;
            //Debug.Log("Enemy Speed : " + enemySpeed);
            //float distance = GameController.Instance.distance; //Vector2.Distance(leftSpawnPosition, leftTargetPosition);
            //Debug.Log("Distance to travel : " + distance);
            //timeToTarget = enemySpeed * distance;
        }

        public void OnGameStarted(IMessage message)
        {
            InvokeRepeating("CheckForBeat", enemySpeed, enemySpeed);
        }

        private void CheckForBeat()
        {
            if (beats[currentBeat + 8] == 1)
            {
                MessageDispatcher.SendMessage(GameEvents.SPAWN);
            }
            currentBeat++;
        }
    }
}