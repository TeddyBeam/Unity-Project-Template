using System;
using System.Collections.Generic;
using UnityEngine;

namespace ApplicationLayer.PhysicLogic
{
    public class CollisionAttacker<T> : PhysicAttacker<T>
    {
        protected override void OnPhysicAttacking() { }

        public void OnCollisionEnter(Collision collision)
        {
            base.Attack(collision.gameObject);
        }
    }
}
