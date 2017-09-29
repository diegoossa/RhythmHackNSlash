using com.ootii.Messages;
using UnityEngine;

namespace BonusLevel.HackNSlash.Game
{
    public class SoundController : MonoBehaviour
    {
        private AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            Init();
            MessageDispatcher.AddListener(GameEvents.START_GAME, OnGameStarted);
        }

        private void Init()
        {
            //audioSource.pitch = GameController.Instance.bpm / 60;
        }

        public void OnGameStarted(IMessage message)
        {
            audioSource.Play();
        }
    }
}