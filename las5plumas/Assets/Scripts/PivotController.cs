using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Level.MainScene
{

    public class PivotController : MonoBehaviour
    {
        public float iniAngle = 0f;
        public float finAngle = 180f;
        public float angError = 10f;
        [SerializeField]
        private float curAngle = 0f;

        public float angularSpeed = 1f;

        private int dir = 1;

        private void Start()
        {
            curAngle = 0;
        }

        

        private void Update()
        {
            if (dir == 1)
            {
                float error = Mathf.Abs(curAngle - finAngle);

                if (error < angError)
                {
                    dir = -1;
                }

                //curAngle = Mathf.Lerp(curAngle, finAngle, angularSpeed * Time.deltaTime);
                curAngle += angularSpeed * Time.deltaTime;
            }
            else
            {
                float error = Mathf.Abs(curAngle - iniAngle);

                if (error < angError)
                {
                    dir = 1;
                }

                //curAngle = Mathf.Lerp(curAngle, iniAngle, angularSpeed * Time.deltaTime);
                curAngle -= angularSpeed * Time.deltaTime;
            }

            //curAngle += angularSpeed * Time.deltaTime;

            transform.localRotation = Quaternion.AngleAxis(curAngle, transform.up);
        }

    }
}