using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAiPlayerDetecting : MonoBehaviour
{
    public UnityEvent PlayerTankDetected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            PlayerTankDetected?.Invoke();
            enabled = false;
        }
    }
}
