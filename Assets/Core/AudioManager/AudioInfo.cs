#region

using System;
using GameJamUtility.Core.Infrastructure;
using UnityEngine;

#endregion

namespace GameJamUtility.Core.AudioManager
{
    [Serializable]
    public class AudioInfo : DataInfo<AudioClip>
    {
    #region Constructor

        public AudioInfo(string key , AudioClip value) : base(key , value) { }

    #endregion
    }
}