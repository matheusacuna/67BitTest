using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMoney : MonoBehaviour
{
    public float radiusCollider;
    [SerializeField] private ShopManager moneyManager;

    void Update()
    {
        IdentifyPool();
    }

    public void IdentifyPool()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, radiusCollider);

        foreach (var item in hit)
        {
            if (item.gameObject.CompareTag("Pool"))
            {
                Debug.Log("pegou");
                moneyManager.IncrementMoney(10f);
                Destroy(gameObject);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radiusCollider);
    }
}
