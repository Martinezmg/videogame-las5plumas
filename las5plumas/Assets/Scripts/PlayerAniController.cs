using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerAniController : MonoBehaviour {

    const float locomotionAnimSmoothTime = 0.1f;

    public NavMeshAgent agent;
    public Animator animator;

	// Use this for initialization
	void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        float speedPercent = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("speedPercent", speedPercent, locomotionAnimSmoothTime, Time.deltaTime);
		
	}
}
