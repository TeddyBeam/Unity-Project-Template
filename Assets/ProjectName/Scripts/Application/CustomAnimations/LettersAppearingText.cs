using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ApplicationLayer.CustomAnimations
{
    /// <summary>
    /// Display each character of an UI text one by one.
    /// </summary>
    public class LettersAppearingText : MonoBehaviour, IRunnable
    {
        [SerializeField]
        private Text displayText = null;

        [SerializeField]
        private string startText = "startText", finalText = "finalText";

        [SerializeField, Range(0.01f, 10f), Tooltip("How long does it take to show all the characters.")]
        private float displayTime = 1f;

        public bool IsRunning { get; private set; }

        private Coroutine animateCoroutine = null;

        public void Run()
        {
            animateCoroutine = StartCoroutine(AnimateCoroutine());
            IsRunning = true;
        }

        public void Stop ()
        {
            if (animateCoroutine != null)
                StopCoroutine(animateCoroutine);

            IsRunning = false;
        }

        protected virtual IEnumerator AnimateCoroutine()
        {
            if (displayText == null)
                yield break;

            if (finalText == null)
                yield break;

            // Calculate the delay time before we display another character.
            float delayTime = displayTime / finalText.Length;

            displayText.text = startText;

            // Add all the characters in the finalText into the display Text UI one by one.
            for (int i = 0; i < finalText.Length; i++)
            {
                displayText.text += finalText[i];

                yield return new WaitForSeconds(delayTime);
            }
        }
    }
}
