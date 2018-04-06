using UnityEngine;
using UnityEngine.SceneManagement;


namespace Project.Interactables
{
    public class EndLvl : MonoBehaviour
    {

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                Debug.Log("LVL " + SceneManager.GetActiveScene().name + " has been completed.");
            }
        }
    }
}
