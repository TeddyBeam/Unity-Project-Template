using System;
using System.Collections.Generic;
using UnityEngine;

namespace ApplicationLayer.InputDetectors
{
    /// <summary>
    /// Detect user swipe on mobile device's screen.
    /// </summary>
    public class TouchSwipeDetector : OnScreenSwipeDetector
    {
        protected override void DetectSwipe()
        {
            if (Input.touchCount != 1)
                return;

            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                firstPressPos = new Vector2(touch.position.x, touch.position.y);
            }

            if (touch.phase == TouchPhase.Ended)
            {
                secondPressPos = new Vector2(touch.position.x, touch.position.y);
                currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

                // Make sure it was a legit swipe, not a tap
                if (currentSwipe.magnitude < minSwipeLength)
                    return;

                currentSwipe.Normalize();

                if (Vector2.Dot(currentSwipe, GetCardinalDirections(SwipeDirections.Up)) > DOT_COMPARE)
                {
                    OnSwipeDetected.Invoke(SwipeDirections.Up);
                    print("Up!");
                    return;
                }

                if (Vector2.Dot(currentSwipe, GetCardinalDirections(SwipeDirections.Down)) > DOT_COMPARE)
                {
                    OnSwipeDetected.Invoke(SwipeDirections.Down);
                    print("Down!");
                    return;
                }

                if (Vector2.Dot(currentSwipe, GetCardinalDirections(SwipeDirections.Left)) > DOT_COMPARE)
                {
                    OnSwipeDetected.Invoke(SwipeDirections.Left);
                    print("Left");
                    return;
                }

                if (Vector2.Dot(currentSwipe, GetCardinalDirections(SwipeDirections.Right)) > DOT_COMPARE)
                {
                    OnSwipeDetected.Invoke(SwipeDirections.Right);
                    print("Right");
                    return;
                }

                if (Vector2.Dot(currentSwipe, GetCardinalDirections(SwipeDirections.UpRight)) > DOT_COMPARE)
                {
                    OnSwipeDetected.Invoke(SwipeDirections.UpRight);
                    print("UpRight");
                    return;
                }

                if (Vector2.Dot(currentSwipe, GetCardinalDirections(SwipeDirections.UpLeft)) > DOT_COMPARE)
                {
                    OnSwipeDetected.Invoke(SwipeDirections.UpLeft);
                    print("UpLeft");
                    return;
                }

                if (Vector2.Dot(currentSwipe, GetCardinalDirections(SwipeDirections.DownLeft)) > DOT_COMPARE)
                {
                    OnSwipeDetected.Invoke(SwipeDirections.DownLeft);
                    print("DownLeft");
                    return;
                }

                if (Vector2.Dot(currentSwipe, GetCardinalDirections(SwipeDirections.DownRight)) > DOT_COMPARE)
                {
                    OnSwipeDetected.Invoke(SwipeDirections.DownRight);
                    print("DownRight");
                    return;
                }
            }           
        }
    }
}
