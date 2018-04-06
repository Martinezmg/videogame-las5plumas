using System.Collections;
using UnityEngine;

namespace Project.Game
{
    [RequireComponent(typeof(Camera))]
    public class CameraController : MonoBehaviour
    {
        public Transform target;

        //Para la suavidad del movimiento
        [Header("Transform smoothness")]
        public float lerpSmothness = 1f;
        [Range(0, 1)]
        public float quaternionLerpSmothness = 0.05f;        

        //misc
        private bool idle = true;

        private void Start()
        {
            if (target != null)
            {
                transform.position = target.position;
                transform.rotation = target.rotation;
            }
            
        }


        private void Update()
        {

            #region MoveToPoint
            if (!idle)
            {
                MoveToNewTarget();
            }
            #endregion
        }

        public void SetNewTarget(Transform t)
        {
            target = t;

            idle = false;
        }

        private void MoveToNewTarget()
        {
            float distanceA = Vector3.Distance(transform.position, target.position);
            float distanceB = Vector3.Distance(transform.eulerAngles, target.eulerAngles);

            if (distanceA > 0.1f && distanceB > 0.1f)
            {
                transform.position = Vector3.Slerp(transform.position, target.position, Time.deltaTime * lerpSmothness);

                transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, quaternionLerpSmothness);
            }
            else
            {
                idle = true;
            }
        }

    }
}
