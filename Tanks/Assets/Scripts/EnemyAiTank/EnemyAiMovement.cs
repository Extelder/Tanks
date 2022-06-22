using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAiMovement : MonoBehaviour
{
    [SerializeField] private List<Transform> _patrolPoints = new List<Transform>(2);
    [SerializeField] private Transform _player;
    [SerializeField] private bool _autoPatrolpointsGenerate;

    private CompositeDisposable _disposable = new CompositeDisposable();

    private NavMeshAgent _agent;

    private void Awake() => _agent = GetComponent<NavMeshAgent>();

    private void GeneratePatrolPoint(Vector3 direction, float multiplyValue)
    {
        _patrolPoints.Add(Instantiate(new GameObject("Patrol point"),
            transform.position - direction * multiplyValue,
            Quaternion.identity).transform);
    }

    private void OnEnable()
    {
        if (_autoPatrolpointsGenerate)
        {
            GeneratePatrolPoint(transform.right, Random.Range(-15f, 15f));
            GeneratePatrolPoint(transform.forward, Random.Range(-15f, 15f));
        }

        StartCoroutine(MovingToRandomPoint());
    }

    private void OnDisable()
    {
        _disposable.Clear();
        StopAllCoroutines();
    }

    private IEnumerator MovingToRandomPoint()
    {
        int i = 0;
        while (true)
        {
            SetDestinationToPoint(_patrolPoints[i].position);
            i++;
            yield return new WaitForSeconds(0.05f);
            yield return new WaitUntil(() => _agent.remainingDistance <= 1f);
            if (i == _patrolPoints.Count) i = 0;
        }
    }

    private void SetDestinationToPoint(Vector3 point) => _agent.SetDestination(point);

    public void BeginHunt()
    {
        StopAllCoroutines();
        Observable.EveryUpdate().Subscribe(_ => { SetDestinationToPoint(_player.position); }).AddTo(_disposable);
    }
}