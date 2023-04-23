using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyInput
{
    public class MyInputs : MonoBehaviour
    {
        private InputMap input;

        public static MyInputs instance;

        private void Awake()
        {
            instance = this;

            input = new InputMap();
        }

        public static InputMap GetInput()
        {
            return instance.input;
        }
    }
}
