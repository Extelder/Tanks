using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlashAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void PlayShootAnimation()
    {
        _animator.SetTrigger("Shoot");
    }
}
