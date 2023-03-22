using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _animator;

    private Vector3 _target;

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
        // Left Click
        if (Input.GetMouseButton(0))
        {
            // cast a ray from mouse positon
            var rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {         
                _agent.SetDestination(hitInfo.point);
                _animator.SetBool("Walk", true);
                _target = hitInfo.point;
            }
        }

        // distance between player and destination
        var distance = Vector3.Distance(transform.position, _target);

        if (distance < 1.0f)
        {
            _animator.SetBool("Walk", false);
        }
    }
}
