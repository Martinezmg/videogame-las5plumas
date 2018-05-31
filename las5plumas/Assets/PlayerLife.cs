using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public IntReference playerLife;

    public Image h1;
    public Image h2;
    public Image h3;

    public Sprite h;
    public Sprite nh;

    public UnityEvent OnPlayerDeath;

    private void Update()
    {
        switch (playerLife.Value)
        {
            case 3:
                h1.sprite = h;
                h2.sprite = h;
                h3.sprite = h;
                break;
            case 2:
                h1.sprite = h;
                h2.sprite = h;
                h3.sprite = nh;
                break;
            case 1:
                h1.sprite = h;
                h2.sprite = nh;
                h3.sprite = nh;
                break;
            default:
                OnPlayerDeath.Invoke();
                break;
        }
    }
}
