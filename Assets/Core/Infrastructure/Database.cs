#region

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#endregion

namespace GameJamUtility.Core.Infrastructure
{
    [Serializable]
    public class Database<T , V> where T : DataInfo<V> where V : class
    {
    #region Protected Variables

        [SerializeField]
        protected List<T> infos = new List<T>();

    #endregion

    #region Public Methods

        public void AddOrOverwrite(string key , V value)
        {
            if (TryGetInfo(key , out var info)) return;
            info = (T)new DataInfo<V>(key , value);
            infos.Add(info);
        }

        public bool TryGetInfo(string key , out T value)
        {
            value = infos.FirstOrDefault(info => info.Key == key);
            var keyExist = value is not null;
            return keyExist;
        }

        public bool TryGetValue(string key , out V value)
        {
            if (TryGetInfo(key , out var info) == false)
            {
                value = null;
                return false;
            }

            value = info.Value;
            if (value is not null) return true;
            Debug.LogWarning($"TryGetValue but the value is null by key: {key}");
            return false;
        }

    #endregion
    }
}