using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackingEnemies : MonoBehaviour
{
    public Transform stackPosition; // A posição inicial para empilhar os objetos
    public float stackOffset = 1f; // O espaçamento entre os objetos empilhados
    private List<GameObject> stackedObjects; // Lista para armazenar os objetos empilhados
    private Vector3 _firstCubePos;
    private Vector3 _currentCubePos;
    private int _cubeListIndexCounter = 0;

    void Start()
    {
        stackedObjects = new List<GameObject>();
    }
}
