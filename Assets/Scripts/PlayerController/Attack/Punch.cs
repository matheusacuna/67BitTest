using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyInput;

public class Punch : MonoBehaviour
{
    [SerializeField] private Animator animPlayer;
    public int punchDamage;
    public float forceKnockback;
    private bool isPunching;
    
   
    void Update()
    {
        if(MyInputs.GetInput().Player.Attack.triggered)
        {
            animPlayer.SetTrigger("basicAttackTrigger");
        }
    }
}
