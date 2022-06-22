using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    [SerializeField] private TankBodyRotation _bodyRotation;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private float _speed;

    private Rigidbody _rigidBody;
    private CompositeDisposable _disposable = new CompositeDisposable();

    private void Awake() => _rigidBody = GetComponent<Rigidbody>();

    private void OnEnable()
    {
        Observable.EveryUpdate().Subscribe(_ =>
        {
            _rigidBody.velocity = _bodyRotation.transform.rotation * new Vector3(0f, 0f, _speed * _playerInput.TankMovementInputAxis);
        }).AddTo(_disposable);
    }

    private void OnDisable() => _disposable.Clear();
}
