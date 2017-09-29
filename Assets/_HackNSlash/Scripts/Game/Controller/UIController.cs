using com.ootii.Messages;
using UnityEngine;
using UnityEngine.UI;

namespace BonusLevel.HackNSlash.Game
{
    public class UIController : MonoBehaviour
    {
        [SerializeField]
        private Button startButton;
        [SerializeField]
        private Button leftButton;
        [SerializeField]
        private Button rigthButton;

        private void Start()
        {
            startButton.onClick.AddListener(OnStartButtonClicked);
            leftButton.onClick.AddListener(OnLeftButtonClicked);
            rigthButton.onClick.AddListener(OnRightButtonClicked);
        }

        private void OnStartButtonClicked()
        {
            GameController.Instance.StartGame();
            startButton.gameObject.SetActive(false);
        }

        private void OnLeftButtonClicked()
        {
            MessageDispatcher.SendMessage(GameEvents.LEFT_TOUCH);
        }

        private void OnRightButtonClicked()
        {
            MessageDispatcher.SendMessage(GameEvents.RIGHT_TOUCH);
        }
    }
}