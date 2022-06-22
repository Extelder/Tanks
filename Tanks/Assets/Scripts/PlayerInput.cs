using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEditor.Searcher;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private CompositeDisposable _disposable = new CompositeDisposable();
    public float TankBodyRotationInputAxis { get; set; }
    public float TankMovementInputAxis { get; set; }
    public Vector3 WorldMousePosition { get; set; }

    public event Action OnLeftMouseButtonDown;

    public bool CheckFoButtonDownInput(KeyCode keyCode)
    {
        if (Input.GetKeyDown(keyCode))
        {
            return true;
        }

        return false;
    }

    private void OnEnable()
    {
        Observable.EveryUpdate().Subscribe(_ =>
            {
                Ray MouseRay = _camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(MouseRay, out hit, Mathf.Infinity))
                {
                    WorldMousePosition = hit.point;
                }
                if(Input.GetMouseButtonDown(0)) OnLeftMouseButtonDown?.Invoke();
                TankBodyRotationInputAxis = Input.GetAxisRaw("Horizontal");
                TankMovementInputAxis = Input.GetAxisRaw("Vertical");
            })
            .AddTo(_disposable);
    }

    private void OnDisable() => _disposable.Clear();
   
}