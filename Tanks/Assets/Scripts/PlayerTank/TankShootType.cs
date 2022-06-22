using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class TankShootType : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private TankShoot _tankShoot;
    [SerializeField] private TankFire _tankFire;

    private CompositeDisposable _disposable = new CompositeDisposable();

    private void OnEnable()
    {
        Observable.EveryUpdate().Subscribe(_ =>
        {
            if (_playerInput.CheckFoButtonDownInput(KeyCode.Alpha1))
            {
                DisableAllShootTypes();
                _tankShoot.enabled = true;
            }
            if(_playerInput.CheckFoButtonDownInput(KeyCode.Alpha2))
            {
                DisableAllShootTypes();
                _tankFire.enabled = true;
            }
        }).AddTo(_disposable);
    }

    private void OnDisable() => _disposable.Clear();

    private void DisableAllShootTypes()
    {
        _tankFire.enabled = false;
        _tankShoot.enabled = false;
    }
}
