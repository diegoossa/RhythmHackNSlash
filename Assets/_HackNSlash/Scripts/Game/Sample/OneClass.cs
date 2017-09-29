using com.ootii.Messages;
using UnityEngine;

namespace BonusLevel.HackNSlash.Game
{
    public class OneClass : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetButtonDown("Jump"))
            {
                MessageDispatcher.SendMessage(GameEvents.START_GAME);
            }
        }
    }
}