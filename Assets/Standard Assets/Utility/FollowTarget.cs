using System;
using UnityEngine;
using UnityEngine.UI;


namespace UnityStandardAssets.Utility
{
    public class FollowTarget : MonoBehaviour
    {
        public Transform target;
        public Vector3 offset = new Vector3(0f, 7.5f, 0f);
        private Quaternion localRotation; // 
        public float speed = 1.0f;

        public Text xtelgText;
        public Text ytelgText;
     

            void Start()
        {
            // copy the rotation of the object itself into a buffer
            localRotation = transform.rotation;
        }

        void Update() // runs 60 fps or so
        {
            // find speed based on delta
            float curSpeed = Time.deltaTime * speed;
            // first update the current rotation angles with input from acceleration axis
            localRotation.y -= Input.acceleration.x * curSpeed;
            localRotation.y = Mathf.Clamp(localRotation.y, -0.1f, 0.1f);
            localRotation.x += Input.acceleration.y * curSpeed;
            localRotation.x = Mathf.Clamp(localRotation.x, -0.1f, 0.1f);
           // localRotation.z = 0;
            // then rotate this object accordingly to the new angle
            transform.rotation = localRotation;
            transform.position = target.position + offset;


            xtelgText.text = "x: " + localRotation.x;
            ytelgText.text = "y: " + localRotation.y;
           
        }

        
    }
}
