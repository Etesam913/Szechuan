using System.Collections;
using UnityEngine;

public class Stream : MonoBehaviour
{
    private LineRenderer _lineRenderer = null;

    private ParticleSystem _splashParticle = null;

    private Coroutine pourRoutine = null;
    
    private Vector3 targetPosition = Vector3.zero;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _splashParticle = GetComponentInChildren<ParticleSystem>();
    }
    // Start is called before the first frame update
    void Start()
    {
        MoveToPosition(0, transform.position);
        MoveToPosition(1, transform.position);
    }

    public void Begin()
    {
        StartCoroutine(UpdateParticle());
        pourRoutine = StartCoroutine(BeginPour());
        
    }

    public void End()
    {
        StopCoroutine(pourRoutine);
        pourRoutine = StartCoroutine(EndPour());
    }

    private IEnumerator EndPour()
    {
        while (!HasReachedPosition(0, targetPosition))
        {
            AnimateToPosition(0, targetPosition);
            AnimateToPosition(1, targetPosition);
            yield return null;
        }
        Destroy(gameObject);
    }
    
    private IEnumerator BeginPour()
    {
        while (gameObject.activeSelf)
        {
            targetPosition = FindEndPoint();
            MoveToPosition(0, transform.position);
            AnimateToPosition(1, targetPosition);
            yield return null;    
        }
        
    }

    private Vector3 FindEndPoint()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);

        Physics.Raycast(ray, out hit, 10.0f);
        Vector3 endPoint = hit.collider ? hit.point : ray.GetPoint(10.0f);
        return endPoint;
    }

    private void MoveToPosition(int index, Vector3 targetPosition)
    {
        _lineRenderer.SetPosition(index, targetPosition);
    }

    private void AnimateToPosition(int index, Vector3 targetPosition)
    {
        Vector3 currentPoint = _lineRenderer.GetPosition(index);
        Vector3 newPosition = Vector3.MoveTowards(currentPoint, targetPosition, Time.deltaTime * 1.75f);
        _lineRenderer.SetPosition(index, newPosition);
    }

    private bool HasReachedPosition(int index, Vector3 targetPosition)
    {
        Vector3 currentPosition = _lineRenderer.GetPosition(index);
        return currentPosition == targetPosition;
    }


    private IEnumerator UpdateParticle()
    {
        while (gameObject.activeSelf)
        {
            _splashParticle.gameObject.transform.position = targetPosition;

            bool isHitting = HasReachedPosition(1, targetPosition);
            _splashParticle.gameObject.SetActive(isHitting);
            yield return null;    
        }
        
    }
}
