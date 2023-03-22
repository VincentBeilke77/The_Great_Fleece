using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _animator;

    public List<Transform> waypoints;

    [SerializeField]
    private int _currentTarget = 0;
    private bool _reverse = false;
    private bool _targetReached = false;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        if (_agent == null)
        {
            Debug.LogError("Nav Mesh Agent is NULL.");
        }

        _animator = GetComponentInChildren<Animator>();
        if (_animator == null)
        {
            Debug.LogError("Animator is NULL.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if waypoints exsist (count) && waypoints[currentTarget] != null
        // set destination to current target
        if (waypoints.Count > 0 && waypoints.Count > 1 && waypoints[_currentTarget] != null)
        {
            _agent.SetDestination(waypoints[_currentTarget].position);
            var distance = Vector3.Distance(transform.position, waypoints[_currentTarget].position);

            if (distance < 1 && (_currentTarget == 0 || _currentTarget == waypoints.Count - 1))
            {
                _animator.SetBool("Walk", false);
            } else
            {
                _animator.SetBool("Walk", true);
            }

            if (distance < 1.0f && _targetReached == false)
            {                
                _targetReached = true;

                StartCoroutine(WaitBeforeMoving());
            } 

        }
    }

    IEnumerator WaitBeforeMoving()
    {        
        if ((_currentTarget == 0 || _currentTarget == waypoints.Count - 1) && waypoints.Count > 1)
        {
            yield return new WaitForSeconds(2.0f);
        } else
        {
            yield return null;
        }

        if (_reverse)
        {
            _currentTarget--;
            if (_currentTarget == 0)
            {
                _reverse = false;
                _currentTarget = 0;
            }
        }
        else
        {
            _currentTarget++;
            if (_currentTarget == waypoints.Count)
            {
                _reverse = true;
                _currentTarget--;
            }
        }

        _targetReached = false;
    }
}
