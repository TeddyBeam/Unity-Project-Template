using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ApplicationLayer.InputDetectors
{
    /// <summary>
    /// Detect user swipe on a device's screen.
    /// </summary>
    public abstract class OnScreenSwipeDetector : MonoBehaviour, IRunnable
    {
        #region Define structures

        public enum SwipeDirections
        {
            None = 0,
            Up,
            Down,
            Left,
            Right,
            UpRight,
            UpLeft,
            DownRight,
            DownLeft
        };

        [Serializable]
        public class SwipeDetectedEvent : UnityEvent<SwipeDirections> { }

        #endregion

        [SerializeField, Tooltip("Start the detection right when this component is enabled?")]
        private bool startOnEnable = true;

        [SerializeField]
        protected float minSwipeLength = 5;

        [SerializeField, Space(10f)]
        private SwipeDetectedEvent onSwipeDetected;

        /// <summary>
        /// Acos(0.906f) ~ 25 degrees.
        /// </summary>
        protected readonly float DOT_COMPARE = 0.906f;

        /// <summary>
        /// Event fired after detected a swipe. 
        /// </summary>
        public SwipeDetectedEvent OnSwipeDetected { get { return onSwipeDetected; } }

        /// <summary>
        /// Is the detection running?
        /// </summary>
        public bool IsRunning { get; private set; }

        /// Cached values.
        protected Vector2 firstPressPos;
        protected Vector2 secondPressPos;
        protected Vector2 currentSwipe;

        protected virtual void OnValidate ()
        {
            // Ensure that the minSwipeLength's value is not negative.
            minSwipeLength = minSwipeLength < 0 ? 0 : minSwipeLength;
        }

        protected virtual void OnEnable ()
        {
            IsRunning = startOnEnable;
        }

        protected virtual void Update ()
        {
            if (!IsRunning)
                return;

            DetectSwipe();
        }

        protected abstract void DetectSwipe();

        public void Stop ()
        {
            IsRunning = false;
        }

        public void Run ()
        {
            IsRunning = true;
        }

        /// <summary>
        /// Get the vector2 to compare with a specific direction.
        /// </summary>
        protected Vector2 GetCardinalDirections(SwipeDirections swipeDirections)
        {
            switch (swipeDirections)
            {
                case SwipeDirections.None: return default(Vector2);

                case SwipeDirections.Up: return new Vector2(0, 1);

                case SwipeDirections.Down: return new Vector2(0, -1);

                case SwipeDirections.Left: return new Vector2(-1, 0);

                case SwipeDirections.Right: return new Vector2(1, 0);

                case SwipeDirections.UpRight: return new Vector2(1, 1);

                case SwipeDirections.UpLeft: return new Vector2(-1, 1);

                case SwipeDirections.DownRight: return new Vector2(1, -1);

                case SwipeDirections.DownLeft: return new Vector2(-1, -1);

                default: return default(Vector2);
            }
        }
    }
}
