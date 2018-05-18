using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimController : MonoBehaviour
{
    private Animator anim;
    private int hashID;

    public string ConditionHash = "";

    public bool OnSight { set { anim.SetBool(hashID, value); } }

    private void Start()
    {
        hashID = Animator.StringToHash(ConditionHash);

        anim = GetComponent<Animator>();        
    }
}
