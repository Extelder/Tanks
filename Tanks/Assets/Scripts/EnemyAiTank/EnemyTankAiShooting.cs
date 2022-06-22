using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankAiShooting : MonoBehaviour
{
    [SerializeField] private Pool _pool;
    [SerializeField] private Transform _muzzle;

    public void BeginShoot() => StartCoroutine(Shooting(0.5f));
    private void OnDisable() => StopAllCoroutines();

    private IEnumerator Shooting(float _timeForNextFire)
    {
        while (true)
        {
            yield return new WaitForSeconds(0.05f);
            _pool.GetFreeElement(_muzzle.position, transform.rotation);
            yield return new WaitForSeconds(_timeForNextFire);
        }
    }
}
