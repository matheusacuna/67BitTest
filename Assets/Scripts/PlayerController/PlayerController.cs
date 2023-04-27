using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{ 
    public class PlayerController : MonoBehaviour
    {
        [Header("Joystick Asset Reference")]
        public FixedJoystick joystick;

        [Header("Move Settings")]
        private Rigidbody rig;
        private float moveH, moveV;
        public float speedMove = 5;

        private Animator animPlayer;

        public float radiusCollider;

        void Start()
        {
            rig = GetComponent<Rigidbody>();
            animPlayer = GetComponent<Animator>();
        }

        private void Update()
        {
            SetAnimations();
        }

        void FixedUpdate()
        {
            Move();
        }

        public void Move()
        {
            moveH = joystick.Horizontal;
            moveV = joystick.Vertical;

            Vector3 dir = new Vector3(moveH, 0, moveV);
            rig.velocity = new Vector3(moveH * speedMove, rig.velocity.y, moveV * speedMove);

            if (dir != Vector3.zero)
            {
                transform.LookAt(transform.position + dir);
            }
        }

        public void SetAnimations()
        {
            float velocityMagnitude = new Vector3(rig.velocity.x, 0, rig.velocity.z).magnitude;
            animPlayer.SetFloat("velocity", velocityMagnitude);
        }
    }
}

