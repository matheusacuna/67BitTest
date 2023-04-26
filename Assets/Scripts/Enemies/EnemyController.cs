using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyUtilities;
using System;

public class EnemyController : MonoBehaviour, Idamageble
{
    [Header("Stacking Enemy Settings")]
    [SerializeField] StackingManager stackingManager;
    //public int maxStackLimit;
    [SerializeField]
    private RagdollEnabler[] Ragdolls;
    //public Transform playerAttachmentPoint;
    private Rigidbody rig;
    //public int offsetStacking;
    //public bool isAffected;


    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    public void TakeDamage(Transform targetTransform,  int damage, float knockBackForce)
    {
        int currentStackCount = stackingManager.playerAttachmentPoint.childCount;

        if (currentStackCount < stackingManager.maxStackLimit)
        {
            StartCoroutine(Stacking());
        }

        ApplyKnockback(targetTransform, knockBackForce); 

    }
    public void ApplyKnockback(Transform targetTransform, float knockBackForce)
    {
        foreach (RagdollEnabler ragdoll in Ragdolls)
        {
            ragdoll.EnableRagdoll();

        }
        foreach (RagdollEnabler ragdoll in Ragdolls)
        {
            foreach (Rigidbody rigidbody in ragdoll.rigidBodies)
            {
                rigidbody.KnockBack(transform, targetTransform, knockBackForce);
            }
        }
    }
    public IEnumerator Stacking()
    {
        yield return new WaitForSeconds(1.5f);
        stackingManager.StackingEnemies(Ragdolls, transform);
        
    }
}
