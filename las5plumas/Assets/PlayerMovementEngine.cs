using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovementEngine : MonoBehaviour 
{
    public NavMeshAgent agent;

    //this.transform for move

    //transform from GFX
    public Transform rotation_pivot;
    private float rotationLerpSpeed = 0.35f;

	public void RotatePlane()
    {
        transform.eulerAngles = Vector3.Lerp(
                        transform.eulerAngles,
                        new Vector3(
                            transform.eulerAngles.x,
                            Camera.main.transform.eulerAngles.y,
                            transform.eulerAngles.z),
                            Time.deltaTime);
    }

    public void RotateAgent(float angle)
    {
        Quaternion rotateTo = Quaternion.Euler(
                        rotation_pivot.eulerAngles.x,
                        angle + Camera.main.transform.eulerAngles.y,
                        rotation_pivot.eulerAngles.z);

        rotation_pivot.rotation = Quaternion.Lerp(
            rotation_pivot.rotation,
            rotateTo,
            rotationLerpSpeed);
    }

    public void MoveAgent(Vector3 direction)
    {
        agent.Move(rotation_pivot.forward);
    }
}
