using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeadTanksCounter : MonoBehaviour
{
    [SerializeField] private int _valueForWin;
    
    private int value;

    public UnityEvent PlayerWin;

    public void TankDead()
    {
        value++;
        if (value >= _valueForWin)
        {
            PlayerWin?.Invoke();
        }
    }
}
