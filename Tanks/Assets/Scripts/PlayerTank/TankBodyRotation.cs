using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class TankBodyRotation : MonoBehaviour
{
    [SerializeField] private PlayerInput _input;

    private Rigidbody _rigidBody;
    private CompositeDisposable _disposable = new CompositeDisposable();

    private void Awake() => _rigidBody = GetComponent<Rigidbody>();

    private void OnEnable()
    {
        Observable.EveryUpdate().Subscribe(_ =>
        {
            transform.eulerAngles += new Vector3(0, _input.TankBodyRotationInputAxis, 0f);
        }).AddTo(_disposable);
    }

    private void OnDisable() => _disposable.Clear();
}
