using UnityEngine;
using Project.Game;

namespace Project.Interactables
{
    public class Player_I : Interactable
    {
        public GameObject ui;

        public override void SpecialInteract(Transform playerTransform)
        {
            Debug.Log("Entrar al inventario             ***");
            base.SpecialInteract(playerTransform);

            PlayParticles();

            //Time.timeScale = 0f;
            ui.SetActive(true);
        }
    }
}
