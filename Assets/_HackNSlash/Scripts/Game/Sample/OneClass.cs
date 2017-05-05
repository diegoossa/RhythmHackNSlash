using com.ootii.Messages;
using UnityEngine;

namespace GrupoDeInteres.HackNSlash.Game
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