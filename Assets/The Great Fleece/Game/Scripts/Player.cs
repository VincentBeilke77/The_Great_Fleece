using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _animator;

    private Vector3 _target;

    [SerializeField]
    private GameObject _coinPrefab;

    private bool _coinThrown;

    // Start is called before the first frame update
    void Start()
    {
        _coinThrown = false;
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
        Movement();

        // if right click 
        if (Input.GetMouseButtonDown(1))
        {
            if (_coinThrown == false)
            {
                RaycastHit hitInfo;
                // cast a ray from mouse positon
                var rayOrigin = GetRayOrigin();

                if (Physics.Raycast(rayOrigin, out hitInfo))
                {
                    // instaniate coin at clicked position
                    _animator.SetTrigger("Throw");
                    _coinThrown = true;
                    Instantiate(_coinPrefab, hitInfo.point, Quaternion.identity);
                    SendAIToCoinSpot(hitInfo.point);
                }
            }
        }
    }

    private void Movement()
    {
        // Left Click
        if (Input.GetMouseButton(0))
        {
            RaycastHit hitInfo;
            // cast a ray from mouse positon
            Ray rayOrigin = GetRayOrigin();

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

    private static Ray GetRayOrigin()
    {
        return Camera.main.ScreenPointToRay(Input.mousePosition);
    }

    public void SendAIToCoinSpot(Vector3 coinPosition)
    {
        // round up the guards
        var guards = GameObject.FindGameObjectsWithTag("Guard1");
        // go through each guard
        foreach(var guard in guards)
        {
            var guardAI = guard.GetComponent<GuardAI>();
            var navMesh = guard.GetComponent<NavMeshAgent>();
            var guardAnim = guard.GetComponent<Animator>();

            guardAI.coinTossed = true;
            guardAnim.SetBool("Walk", true);
            navMesh.SetDestination(coinPosition);
            guardAI.coinPosition = coinPosition;
        }
    }
}
