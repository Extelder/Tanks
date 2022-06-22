using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankFire : MonoBehaviour
{
    [SerializeField] private float _fireTime;
    [SerializeField] private GameObject _fire;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private PlayerInput _playerInput;

    private void OnEnable()
    {
        _fire.SetActive(true);
        StartCoroutine(Fire());
    }

    private void OnDisable()
    {
        _fire.SetActive(false);
        StopAllCoroutines();
    }

    private IEnumerator Fire()
    {
        while (true)
        {
            yield return new WaitUntil(() => _playerInput.CheckFoButtonDownInput(KeyCode.Mouse0));
            _particleSystem.Play();
            yield return new WaitForSeconds(_fireTime);
            _particleSystem.Stop();
        }
    }
}
