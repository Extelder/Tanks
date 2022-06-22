using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProjectileVisitor
{
    public void Visit(HeavyBullet heavyBullet, float damage = 15f);
    public void Visit(FireProjectile fireProjectile);
}
