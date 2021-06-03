using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    #region ========== Variables ========

    [SerializeField] float _rotateSpeed = 100;
    [SerializeField] float _moveSpeed = 0.2f;
    [SerializeField] float _fireRange = 1;

    Animator _anim;
    NavMeshAgent _agent;

    #endregion ========== Variables ========

    #region ========== Unity-time ========

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.stoppingDistance = _fireRange;

        _anim = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            // Rotate to the player
            Quaternion rotation = Quaternion.LookRotation(other.transform.position - transform.position);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, _rotateSpeed * Time.deltaTime);

            // Start moving animation
            _anim.SetBool("Moving", true);

            if(_agent.isStopped)
                _agent.isStopped = false;

            // Move bot ot the target
            _agent.SetDestination(other.transform.position);

            // Attack the target
            if (Vector3.Distance(transform.position, other.transform.position) <= _fireRange)
            {
                _anim.SetBool("Moving", false);
                _anim.SetTrigger("Fire");
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _anim.SetBool("Moving", false);
            _agent.isStopped = true;
        }
    }

    #endregion ========== Unity-time ========
}