#region

using System;
using GameJamUtility.Core.Infrastructure;
using UnityEngine;

#endregion

namespace GameJamUtility.Core.AudioManager
{
    [Serializable]
    public class MusicDataBase : Database<MusicInfo , AudioClip> { }

    [Serializable]
    public class MusicInfo : DataInfo<AudioClip>
    {
    #region Constructor

        public MusicInfo(string key , AudioClip value) : base(key , value) { }

    #endregion
    }
}