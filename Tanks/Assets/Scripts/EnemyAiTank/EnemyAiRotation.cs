using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class EnemyAiRotation : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private CompositeDisposable _disposable = new CompositeDisposable();

    public void LookAtPlayer() =>
        Observable.EveryUpdate().Subscribe(_ =>
        {
            transform.LookAt(_player.position, Vector3.up);
            transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0f);
        }).AddTo(_disposable);

    private void OnDisable() => _disposable.Clear();
}