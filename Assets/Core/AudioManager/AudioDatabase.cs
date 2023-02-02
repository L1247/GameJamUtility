#region

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#endregion

namespace GameJamUtility.Core.AudioManager
{
    [Serializable]
    public class AudioDatabase
    {
    #region Private Variables

        [SerializeField]
        private List<AudioInfo> audioInfos = new List<AudioInfo>();

    #endregion

    #region Public Methods

        public void AddOrOverwrite(string key , AudioClip clip)
        {
            if (TryGetInfo(key , out var info)) return;
            info = new AudioInfo(key , clip);
            audioInfos.Add(info);
        }

        public bool TryGetInfo(string key , out AudioInfo value)
        {
            value = audioInfos.FirstOrDefault(info => info.Key == key);
            var keyExist = value is not null;
            return keyExist;
        }

        public bool TryGetValue(string key , out AudioClip value)
        {
            if (TryGetInfo(key , out var info) == false)
            {
                value = null;
                return false;
            }

            value = info.Clip;
            if (value is not null) return true;
            Debug.LogWarning($"TryGetValue but the clip is null by key: {key}");
            return false;
        }

    #endregion
    }
}