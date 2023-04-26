using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackingManager : MonoBehaviour
{

    [Header("Stacking Enemy Settings")]
    public int maxStackLimit;
    public Transform playerAttachmentPoint;
    public int offsetStacking;
    public bool isAffected;
    public int currentStackCount;
    public float offsetX;

    public void StackingEnemies(RagdollEnabler[] ragdollsEnabler, Transform transformPlayer)
    {
        isAffected = true;

        if (isAffected)
        {
            transformPlayer.gameObject.GetComponent<BoxCollider>().enabled = false;

            foreach (RagdollEnabler ragdoll in ragdollsEnabler)
            {
                ragdoll.EnableAnimator();
            }

            int indexStack = playerAttachmentPoint.transform.childCount;

            Vector3 position = Vector3.zero;
            position.x += offsetX;
            Quaternion rotation = Quaternion.Euler(-90, 90, 0);

            if (indexStack >= 1)
            {
                position = playerAttachmentPoint.GetChild(indexStack - 1).transform.localPosition;
                position.y += offsetStacking;
            }

            transformPlayer.SetParent(playerAttachmentPoint);

            transformPlayer.localPosition = position;
            transformPlayer.localRotation = rotation;

        }
    }
}
