using UnityEngine;
using UnityEngine.AI;
using Project.Interactables;

namespace Project.Game
{

    public class Controls : MonoBehaviour
    {
        public Transform player;            //player's transform
        public NavMeshAgent playerAgent;    //player's movement motor

        private Touch currentTouch0;    //current pointer (I/O UI) on screen
        private Touch currentTouch1;    //current pointer (I/O UI) on screen
        private Vector2 originPos0;     //position of current pointer when it was in state began
        private Vector2 originPos1;     //position of current pointer when it was in state began
        private Vector2 currentPos0;
        private Vector2 currentPos1;
        private float time0 = 0f;       //timer's touch0
        private float time1 = 0f;       //timer's touch1

        private bool isWalking = false;

        private Interactable interactable;  //object to interact with

        //UI, visual effects, etc

        public Transform ps; //Particle system

        // Update is called once per frame
        void FixedUpdate()
        {
            switch (Input.touchCount)
            {
                case 0:
                    break;
                case 1:
                    currentTouch0 = Input.GetTouch(0);
                    TouchUpdate(Input.GetTouch(0), ref time0);
                    break;
                case 2:
                    currentTouch0 = Input.GetTouch(0);
                    TouchUpdate(Input.GetTouch(0), ref time0);
                    TouchUpdate(Input.GetTouch(1), ref time1);
                    break;
                default:
                    currentTouch0 = Input.GetTouch(0);
                    TouchUpdate(Input.GetTouch(0), ref time0);
                    TouchUpdate(Input.GetTouch(1), ref time1);
                    break;
            }
        }

        private void TouchUpdate(Touch t, ref float time)
        {
            Vector3 v1 = new Vector3(t.position.x, t.position.y, Camera.main.nearClipPlane);
            Vector3 v2 = new Vector3(t.position.x, t.position.y, Camera.main.farClipPlane);

            Vector3 p1 = Camera.main.ScreenToWorldPoint(v1);
            Vector3 p2 = Camera.main.ScreenToWorldPoint(v2);

            RaycastHit hit;

            float timer = Time.time - time;


            if (t.phase == TouchPhase.Began)
            {
                ps.position = p1;

                if (RayCastTouch(p1, p2-p1, out hit))  //Taps interaction
                {
                    if (t.tapCount == 2)
                    {
                        hit.transform.GetComponent<Actioner>().TriggerSpecialAction(player);
                        return;
                    }

                    if (t.tapCount == 1)
                    {
                        hit.transform.GetComponent<Actioner>().TriggerAction(player);
                        return;
                    }
                } //Taps Interactions
                else
                {
                    time = Time.time;

                    if (t.fingerId == currentTouch0.fingerId)
                    {
                        originPos0 = t.position;
                        isWalking = true;
                    }
                }
            }

            if (t.phase == TouchPhase.Moved)
            {
                ps.position = p1; //paticle system

                if (t.fingerId == currentTouch0.fingerId)
                {
                    player.transform.eulerAngles = Vector3.Lerp(
                        player.transform.eulerAngles,
                        new Vector3(
                            player.transform.eulerAngles.x,
                            Camera.main.transform.eulerAngles.y,
                            player.transform.eulerAngles.z),
                            Time.deltaTime);

                    Vector2 currentPoint = t.position;
                    currentPoint = currentPoint - originPos0;

                    if (currentPoint.magnitude > 50f)
                    {
                        ps.gameObject.SetActive(true); //particle system
                        ps.LookAt(originPos0);

                        float angle = Vector2.SignedAngle(currentPoint, Vector2.up);
                        Quaternion rotateTo = Quaternion.Euler(
                            player.transform.GetChild(0).eulerAngles.x,
                            angle + Camera.main.transform.eulerAngles.y,
                            player.transform.GetChild(0).eulerAngles.z);

                        player.transform.GetChild(0).rotation = Quaternion.Lerp(
                            player.transform.GetChild(0).rotation,
                            rotateTo,
                            0.5f);

                        Ray ray = new Ray
                        {
                            origin = player.transform.position,
                            direction = player.transform.GetChild(0).forward
                        };

                        playerAgent.SetDestination(ray.GetPoint(1f));
                    }
                }
            }

            if (t.phase == TouchPhase.Stationary)
            {
                if (isWalking && t.fingerId == currentTouch0.fingerId)
                {
                    Vector2 currentPoint = t.position;
                    currentPoint = currentPoint - originPos0;

                    if (currentPoint.magnitude > 50f)
                    {

                        Ray ray = new Ray
                        {
                            origin = player.transform.position,
                            direction = player.transform.GetChild(0).forward
                        };

                        playerAgent.SetDestination(ray.GetPoint(1f));
                    }
                }

            }

            if (t.phase == TouchPhase.Ended || t.phase == TouchPhase.Canceled)
            {
                if (t.fingerId == currentTouch0.fingerId)
                {
                    isWalking = false;
                    ps.gameObject.SetActive(false);
                }
            }
        }

        private bool RayCastTouch(Vector3 origin, Vector3 direction, out RaycastHit objectHit)
        {
            return Physics.Raycast(
                       origin,        //origin
                       direction,     //direction
                       out objectHit, //out info
                       2000f,         //max length
                       LayerMask.GetMask("Interactable"),  //layer mask 
                       QueryTriggerInteraction.UseGlobal);  //Trigger interaction
        }
    }
}
