using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public static PlayerManager player;

    public Transform transformp;

    private void Awake()
    {
        if (player == null)
        {
            player = this;
        }
    }


}
