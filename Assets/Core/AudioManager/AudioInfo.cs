#region

using System;
using UnityEngine;

#endregion

namespace GameJamUtility.Core.AudioManager
{
    [Serializable]
    public class AudioInfo
    {
    #region Public Variables

        public AudioClip Clip => clip;
        public string    Key  => key;

    #endregion

    #region Private Variables

        [SerializeField]
        private string key;

        [SerializeField]
        private AudioClip clip;

    #endregion

    #region Constructor

        public AudioInfo(string key , AudioClip clip)
        {
            this.key  = key;
            this.clip = clip;
        }

    #endregion
    }
}