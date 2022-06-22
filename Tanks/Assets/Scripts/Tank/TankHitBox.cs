using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHitBox : MonoBehaviour, IProjectileVisitor
{
    [SerializeField] private TankHealth _health;
    [SerializeField] private ParticleSystem _fireParticleSystem;
    public void Visit(HeavyBullet heavyBullet, float damage = 15)
    {
        Debug.Log("POPAL");
        _health?.TakeDamage(damage);
    }

    public void Visit(FireProjectile fireProjectile)
    {
        _health?.OnTankCaughtFire();
        _fireParticleSystem?.Play();
    }
}
