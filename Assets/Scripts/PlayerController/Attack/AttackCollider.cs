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

        private void Update()
        {
            Hit();
        }

        //private void OnTriggerEnter(Collider other)
        //{
        //    Idamageble obj = other.gameObject.GetComponent<Idamageble>();

        //    if (obj != null)
        //    {
        //        obj.TakeDamage(playerController.transform, punchPlayer.punchDamage, punchPlayer.forceKnockback);
        //    }
        //}

        public void Hit()
        {
            Collider[] hit = Physics.OverlapSphere(transform.position, radiusCollider);

            foreach (var item in hit)
            {
                if (item.gameObject.CompareTag("Enemy"))
                {
                    Debug.Log("pegou");
                    item.gameObject.GetComponent<EnemyController>().TakeDamage(playerController.transform, punchPlayer.punchDamage, punchPlayer.forceKnockback);
                    //item.gameObject.GetComponent<FlashDamageEffect>().CallEffectFlashDamage();
                    //GameObject obj = Instantiate(vfxBurning.gameObject, item.gameObject.transform.position, Quaternion.identity);
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, radiusCollider);
        }

    }
}
