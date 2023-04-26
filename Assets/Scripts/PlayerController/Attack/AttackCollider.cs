using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Player
{
    public class AttackCollider : MonoBehaviour
    {
        private PlayerController playerController;
        private Punch punchPlayer;
        public float radiusCollider;

        private void Awake()
        {
            playerController = GetComponentInParent<PlayerController>();
            punchPlayer = GetComponentInParent<Punch>();
        }

        private void OnTriggerEnter(Collider other)
        {
            Idamageble obj = other.gameObject.GetComponent<Idamageble>();

            if (obj != null)
            {
                obj.TakeDamage(playerController.transform, punchPlayer.punchDamage, punchPlayer.forceKnockback);
            }
        }
    }
}
