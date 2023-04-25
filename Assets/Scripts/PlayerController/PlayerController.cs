using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{ 
    public class PlayerController : MonoBehaviour
    {
        public int CollectedObjectsCount { get; set; }
        private Rigidbody rig;
        public FixedJoystick joystick;
        private float moveH, moveV;
        public float speedMove = 5;

        // Start is called before the first frame update
        void Start()
        {
            rig = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
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
    }
}

