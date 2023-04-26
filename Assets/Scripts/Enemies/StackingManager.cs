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

    public void StackingEnemies(RagdollEnabler[] ragdollsEnabler, Transform transformPlayer)
    {
        isAffected = true;

        if (isAffected)
        {
            foreach (RagdollEnabler ragdoll in ragdollsEnabler)
            {
                ragdoll.EnableAnimator();
            }

            int indexStack = playerAttachmentPoint.transform.childCount - 1;

            Vector3 position = Vector3.zero;
            Quaternion rotation = Quaternion.Euler(-90, 90, 0);

            transformPlayer.SetParent(playerAttachmentPoint);

            if (indexStack >= 0)
            {
                position = playerAttachmentPoint.GetChild(indexStack).transform.localPosition;
            }

            float lastStackedEnemyY = 0f;

            if (indexStack > 0)
            {
                lastStackedEnemyY = playerAttachmentPoint.GetChild(indexStack - 1).localPosition.y;
                position.y = lastStackedEnemyY + offsetStacking;
                transformPlayer.localPosition = position;
                transformPlayer.localRotation = rotation;
            }
            else
            {
                transformPlayer.localPosition = Vector3.zero;
                transformPlayer.localRotation = rotation;
            }
        }
    }
}
