using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Player's movement control
/// </summary>
[RequireComponent(typeof(NavMeshAgent))]
public class Movement : MonoBehaviour
{
    #region ========== Variables ========

    public List<Transform> waypoints { get; set; }

    Animator _anim;
    NavMeshAgent _agent;
    int position = 0;

    #endregion ========== Variables ========

    #region ========== Unity-time ========

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Main.Instance.canMove)
        {
            _agent.SetDestination(waypoints[position].position);
            _anim.SetBool("Moving", true);
        }

        // Stoping the player and enabling him to fire
        if (Math.Round(transform.position.z, 1) == Math.Round(waypoints[position].position.z, 1) &&
        Math.Round(transform.position.y, 1) == Math.Round(waypoints[position].position.y, 1))
        {
            Main.Instance.canMove = false;
            _anim.SetBool("Moving", false);

            Main.Instance.currentLvl = position;
            position++;
        }

    }

    #endregion ========== Unity-time ========
}