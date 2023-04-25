using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyUtilities;
using System;

public class EnemyController : MonoBehaviour, Idamageble
{
    public Transform playerAttachmentPoint;
    private Rigidbody rig;
    public int offsetStacking;
    public bool isAffected;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    public void TakeDamage(Transform targetTransform, int damage, float knockBackForce)
    {
        StartCoroutine(Stacking());
        rig.KnockBack(transform, targetTransform, knockBackForce);
    }

    public IEnumerator Stacking()
    {
        yield return new WaitForSeconds(1.5f);

        isAffected = true;

        if(isAffected)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;

            int indexStack = playerAttachmentPoint.transform.childCount - 1;

            Vector3 position = Vector3.zero;
            Quaternion rotation = Quaternion.Euler(-90, 90, 0);

            if (indexStack >= 0)
            {
                position = playerAttachmentPoint.GetChild(indexStack).transform.localPosition;
            }

            transform.SetParent(playerAttachmentPoint);

            if (indexStack >= 0)
            {
                position.y += offsetStacking;
                transform.localPosition = position;
                transform.localRotation = rotation;
            }
            else
            {
                transform.localPosition = Vector3.zero;
                transform.localRotation = rotation;
            }
        }
    }
}
