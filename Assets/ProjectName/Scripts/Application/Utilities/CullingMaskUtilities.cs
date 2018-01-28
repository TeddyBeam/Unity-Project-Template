using System;
using System.Collections.Generic;
using UnityEngine;

namespace ApplicationLayer.Utilities
{
    public static class CullingMaskUtilities
    {
        /// <summary>
        /// Remove masks with specific name from a cullingMask.
        /// </summary>
        public static int RemoveCullingMask (this int cullingMask, params string[] masksName)
        {
            foreach (string maskName in masksName)
            {
                cullingMask &= ~(1 << LayerMask.NameToLayer(maskName));
            }

            return cullingMask;
        }

        /// <summary>
        /// Add masks with specific name to a cullingMask.
        /// </summary>
        public static int AddCullingMask (this int cullingMask, params string[] masksName)
        {
            foreach (string maskName in masksName)
            {
                cullingMask |= 1 << LayerMask.NameToLayer(maskName);
            }

            return cullingMask;
        }

        /// <summary>
        /// Toggle masks with specific name in a cullingMask.
        /// </summary>
        public static int ToggleCullingMask (this int cullingMask, params string[] masksName)
        {
            foreach (string maskName in masksName)
            {
                cullingMask ^= 1 << LayerMask.NameToLayer(maskName);
            }

            return cullingMask;
        }

        /// <summary>
        /// Remove masks with specific name from a light.
        /// </summary>
        public static Light RemoveCullingMask (this Light light, params string[] masksName)
        {
            light.cullingMask = light.cullingMask.RemoveCullingMask(masksName);
            return light;
        }

        /// <summary>
        /// Add masks with specific name to a light.
        /// </summary>
        public static Light AddCullingMask (this Light light, params string[] masksName)
        {
            light.cullingMask = light.cullingMask.AddCullingMask(masksName);
            return light;
        }

        /// <summary>
        /// Toggle masks with specific name in a light.
        /// </summary>
        public static Light ToggleCullingMask (this Light light, params string[] masksName)
        {
            light.cullingMask = light.cullingMask.ToggleCullingMask(masksName);
            return light;
        }

        /// <summary>
        /// Remove masks with specific name from a camera.
        /// </summary>
        public static Camera RemoveCullingMask(this Camera cam, params string[] masksName)
        {
            cam.cullingMask = cam.cullingMask.RemoveCullingMask(masksName);
            return cam;
        }

        /// <summary>
        /// Add masks with specific name to a camera.
        /// </summary>
        public static Camera AddCullingMask(this Camera cam, params string[] masksName)
        {
            cam.cullingMask = cam.cullingMask.AddCullingMask(masksName);
            return cam;
        }

        /// <summary>
        /// Toggle masks with specific name in a camera.
        /// </summary>
        public static Camera ToggleCullingMask(this Camera cam, params string[] masksName)
        {
            cam.cullingMask = cam.cullingMask.ToggleCullingMask(masksName);
            return cam;
        }
    }
}
