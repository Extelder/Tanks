using System.Collections;
using UniRx;
using UnityEngine;
using UnityEngine.Events;

public class TankHealth : MonoBehaviour
{
    [SerializeField] private float _maxValue;
    [SerializeField] private float _currentValue;

    private CompositeDisposable _disposable = new CompositeDisposable();

    public UnityEvent Dead;

    public void TakeDamage(float damage)
    {
        if((_currentValue - damage) >= 0)
         _currentValue -= damage;
        if(_currentValue <= 0) 
            Death();
    }

    public void Death()
    {
        StopAllCoroutines();
        Dead?.Invoke();
        Destroy(gameObject);
    }

    public void OnTankCaughtFire(float value = 10, float perSecond = 0.5f)
    {
        StartCoroutine(TakingDamage(value, perSecond));
    }

    private IEnumerator TakingDamage(float value, float perSeconds)
    {
        while (true)
        {
            TakeDamage(value);
            yield return new WaitForSeconds(perSeconds);
        }
    }

}
