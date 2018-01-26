using System;
using System.Collections.Generic;
using UnityEngine;

namespace ApplicationLayer.PhysicLogic
{
    /// <summary>
    /// Attacker can attack all object that has implemented IPhysicVictim.
    /// </summary>
    /// <typeparam name="T">Type of the physic parameter that will be sent to victim.</typeparam>
    public abstract class PhysicAttacker<T> : MonoBehaviour
    {
        [SerializeField, Tooltip("This parameter will be sent to the victim when a physic event is triggered.")]
        protected T physicParam = default(T);

        [SerializeField]
        private bool useTags = false;

        //[SerializeField]
        //private List<string> attackableTags;

        protected void Attack(GameObject victimObject, Vector3 hitPoint = default(Vector3), Vector3 attackDirection = default(Vector3))
        {
            //if (useTags && attackableTags != null && !attackableTags.Contains(victimObject.tag))
            //    return;

            IAttackable<T>[] victimPhysicInterfaces = victimObject.GetComponents<IAttackable<T>>();

            if (victimPhysicInterfaces != null && victimPhysicInterfaces.Length > 0)
            {
                foreach (IAttackable<T> physicInterface in victimPhysicInterfaces)
                {
                    physicInterface.OnBeingAttacked(physicParam, hitPoint, attackDirection);
                }

                OnPhysicAttacking();
            }
        }

        /// <summary>
        /// Will be invoke when game object is attacking a victim.
        /// </summary>
        protected abstract void OnPhysicAttacking();
    }
}
