using System;
using System.Collections.Generic;
using UnityEngine;

namespace ApplicationLayer.Utilities
{
    public static class ValidateUtilities
    {
        #region Validate Conditions

        /// <summary>
        /// Validate a condition.
        /// </summary>
        /// <typeparam name="T">Type of the object you want to check the condition.</typeparam>
        /// <param name="obj">The object you want to check the condition.</param>
        /// <param name="predicate">The condition.</param>
        /// <param name="errorMessage">The message will be logged to the console if the condition is false.</param>
        /// <returns></returns>
        public static bool ValidateCondition<T>(this T obj, Predicate<T> predicate, string errorMessage = "Wrong condition!!")
        {
            if (!predicate(obj))
                Debug.LogError(errorMessage);

            return predicate(obj);
        }

        #endregion

        #region Validate Components

        /// <summary>
        /// Check if a GameObject has a specific type of component attached to it.
        /// </summary>
        /// <param name="go">Checking GameObject.</param>
        /// <param name="componentType">Type of the component you want to check.</param>
        /// <param name="errorMessage">The message will be logged to the console if the GameObject doesn't has the specific component.</param>
        /// <param name="deleteFlag">Set the GameObject to null if it doesn't has the specific component.</param>
        public static bool ValidateExistComponent(this GameObject go, Type componentType, string errorMessage, bool deleteFlag = false)
        {
            if (go == null)
                return false;

            if (go.GetComponent(componentType) == null)
            {
                Debug.LogError(errorMessage);

                if (deleteFlag)
                    go = null;

                return false;
            }

            return true;
        }

        /// <summary>
        /// Check if a GameObject has a specific type of component attached to it.
        /// </summary>
        /// <param name="go">Checking GameObject.</param>
        /// <param name="componentType">Type of the component you want to check.</param>
        /// <param name="deleteFlag">Set the GameObject to null if it doesn't has the specific component.</param>
        public static bool ValidateExistComponent(this GameObject go, Type componentType, bool deleteFlag = false)
        {
            return go.ValidateExistComponent(componentType, "There is no " + componentType + " component into this GameObject: " + go, deleteFlag);
        }

        /// <summary>
        /// Check if a GameObject has a specific type of components attached to it.
        /// </summary>
        /// <param name="go">Checking GameObject.</param>
        /// <param name="types">Type of the components you want to check.</param>
        /// <param name="deleteFlag">Set the GameObject to null if it doesn't has the specific component.</param>
        public static void ValidateExistComponents(this GameObject go, bool deleteFlag = false, params Type[] types)
        {
            foreach (Type type in types)
            {
                ValidateExistComponent(go, type, deleteFlag);
            }
        }

        #endregion
    }
}
