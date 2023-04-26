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
                moneyManager.IncrementMoney(10f);
                Feedback();
                Destroy(gameObject);               
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radiusCollider);
    }

    public void Feedback()
    {
        moneyManager.feedbackMoney.GetComponent<Animator>().Play("feedbackMoney", -1, 0.0f);
    }
}
