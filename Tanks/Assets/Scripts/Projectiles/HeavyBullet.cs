using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

[RequireComponent(typeof(PoolObject))]
public class HeavyBullet : Projectile
{
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;
    private PoolObject _poolObject;

    private CompositeDisposable _disposable = new CompositeDisposable();
    private Rigidbody _rigidBody;

    private void Awake() => _rigidBody = GetComponent<Rigidbody>();

    private void OnEnable()
    {
        _poolObject = GetComponent<PoolObject>();
        Observable.EveryUpdate().Subscribe(_ =>
        {
            _rigidBody.velocity = transform.forward * _speed;
        }).AddTo(_disposable);
    }

    private void OnDisable()
    {
        _disposable.Clear();
    }

    public override void Accept(IProjectileVisitor visitor)
    {
        visitor.Visit(this, _damage);
        _poolObject.ReturnToPool();
    }
}
