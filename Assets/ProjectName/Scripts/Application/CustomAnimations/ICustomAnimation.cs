using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationLayer.CustomAnimations
{
    /// <summary>
    /// On mobile, 
    /// consider using those animations instead of Unity's default animation system for better performance.
    /// </summary>
    public interface ICustomAnimation
    {
        /// <summary>
        /// Start the animation.
        /// </summary>
        void StartAnimation();

        /// <summary>
        /// Stop the animation.
        /// </summary>
        void StopAnimation();
    }
}
