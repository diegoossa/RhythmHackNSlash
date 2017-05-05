using com.ootii.Messages;
using UnityEngine;

namespace GrupoDeInteres.HackNSlash.Game
{
    public class OtherClass : MonoBehaviour
    {
        private void Start()
        {
            MessageDispatcher.AddListener(GameEvents.START_GAME, OnStarted);
        }

        private void OnStarted(IMessage message)
        {
            Debug.Log("Recibio el mensaje de START_GAME");
        }
    }
}