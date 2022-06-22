using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShoot : MonoBehaviour
{
    [SerializeField] private Pool _pool;
    [SerializeField] private Transform _muzzle;
    [SerializeField] private float _timeForNextFire;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private MuzzleFlashAnimation _animation;

    private void OnEnable()
    {
        StartCoroutine(Shooting());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator Shooting()
    {
        while (true)
        {
            yield return new WaitUntil(() => _playerInput.CheckFoButtonDownInput(KeyCode.Mouse0));
            _pool.GetFreeElement(_muzzle.position, transform.rotation);
            _animation.PlayShootAnimation();
            yield return new WaitForSeconds(_timeForNextFire);
        }
    }
}