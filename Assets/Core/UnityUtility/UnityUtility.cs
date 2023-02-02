#region

using UnityEngine;

#endregion

namespace GameJamUtility.Core.UnityUtility
{
    public static class UnityUtility
    {
    #region Public Methods

        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            var componentExist = gameObject.TryGetComponent<T>(out var component);
            if (componentExist) return component;

            component = gameObject.AddComponent<T>();
            return component;
        }

    #endregion
    }
}