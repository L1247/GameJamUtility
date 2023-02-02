#region

using System;
using GameJamUtility.Core.Infrastructure;
using UnityEngine;

#endregion

namespace GameJamUtility.Core.AudioManager
{
    [Serializable]
    public class AudioDatabase : Database<AudioInfo , AudioClip> { }
}