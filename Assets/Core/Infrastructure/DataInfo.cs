#region

using System;
using UnityEngine;

#endregion

namespace GameJamUtility.Core.Infrastructure
{
    [Serializable]
    public class DataInfo<V> where V : class
    {
    #region Public Variables

        public string Key => key;

        public V Value => value;

    #endregion

    #region Private Variables

        [SerializeField]
        private string key;

        [SerializeField]
        private V value;

    #endregion

    #region Constructor

        public DataInfo(string key , V value)
        {
            this.key   = key;
            this.value = value;
        }

    #endregion
    }
}