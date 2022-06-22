using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IProjectileVisitor>(out IProjectileVisitor projectileVisitor))
        {
            Accept(projectileVisitor);
        }
    }

    public abstract void Accept(IProjectileVisitor visitor);
}
