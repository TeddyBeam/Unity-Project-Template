using System;
using System.Collections.Generic;
using UnityEngine;

namespace ApplicationLayer.PhysicLogic
{
    public class TriggerAttacker<T> : PhysicAttacker<T>
    {
        protected override void OnPhysicAttacking() { }

        public void OnTriggerEnter(Collider other)
        {
            base.Attack(other.gameObject);
        }
    }
}
