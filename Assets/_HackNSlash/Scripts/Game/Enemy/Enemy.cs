using DG.Tweening;
using UnityEngine;

namespace BonusLevel.HackNSlash.Game
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        private GameObject explosion;

        public void Init(Vector2 target, float time)
        {
            transform.DOMove(target, time)
                .SetEase(Ease.Linear)
                .OnComplete(OnMovementCompleted);
        }

        private void OnMovementCompleted()
        {
            Debug.Log("Movement completed");
        }

        public void DestroyEnemy()
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}