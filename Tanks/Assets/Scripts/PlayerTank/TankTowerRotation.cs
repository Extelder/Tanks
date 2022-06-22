using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class TankTowerRotation : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;

    private CompositeDisposable _disposable = new CompositeDisposable();

    private void OnEnable()
    {
        Observable.EveryUpdate().Subscribe(_ =>
        {
            transform.LookAt(_playerInput.WorldMousePosition, transform.up);
            transform.localEulerAngles = new Vector3(0f, transform.localEulerAngles.y, 0f);
        }).AddTo(_disposable);
    }

    private void OnDisable() => _disposable.Clear();
}
