using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleObject : MonoBehaviour
{
    public Transform playerAttachmentPoint; // Referência ao objeto vazio dentro do seu personagem
    public int offsetStacking;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Substitua "Player" pela tag do seu personagem
        {
            Debug.Log("Nothing");
        }
    }
}
