using com.ootii.Messages;
using UnityEngine;

namespace BonusLevel.HackNSlash.Game
{
    public class GameController : Singleton<GameController>
    {
        [Header("Song Attributes")]
        public float bpm;
        public float distance = 8;

        public void StartGame()
        {
            MessageDispatcher.SendMessage(GameEvents.START_GAME);
        }
    }
}