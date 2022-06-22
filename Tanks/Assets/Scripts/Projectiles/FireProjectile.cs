using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : Projectile
{

    public override void Accept(IProjectileVisitor visitor)
    {
        visitor.Visit(this);
    }
}

