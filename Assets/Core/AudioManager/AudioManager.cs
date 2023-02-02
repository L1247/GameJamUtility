#region

using System.Collections.Generic;
using System.Linq;
using GameJamUtility.Core.UnityUtility;
using UnityEngine;

#endregion

namespace GameJamUtility.Core.AudioManager
{
    public class AudioManager : MonoBehaviour
    {
    #region Public Variables

        public static AudioManager Instance
        {
            get
            {
                if (instance is not null) return instance;
                var prefab = Resources.Load<AudioManager>("GameJamUtility/AudioManager");
                if (prefab is null)
                {
                    Debug.LogWarning("audio manager prefab is null. place a AudioManager prefab in Resources/GameJamUtility path.");
                    return null;
                }

                var audioManager = Instantiate(prefab);
                if (prefab.dontDestroyOnLoad) DontDestroyOnLoad(audioManager);
                audioManager.Init();
                instance = audioManager;
                return instance;
            }
        }

        public bool dontDestroyOnLoad = true;

    #endregion

    #region Private Variables

        private static AudioManager instance;

        private AudioSource audioSource;

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

        public void PlayAudio(string audioKey)
        {
            if (TryGetInfo(audioKey , out var info))
            {
                var clip = info.Clip;
                audioSource.PlayOneShot(clip);
            }
            else
            {
                Debug.LogWarning($"[Play Audio] - can't find audio by key: {audioKey} , Try add AudioInfo in prefab.");
            }
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

    #region Private Methods

        private void Init()
        {
            audioSource             = gameObject.GetOrAddComponent<AudioSource>();
            audioSource.playOnAwake = false;
            audioSource.clip        = null;
        }

        private bool TryGetInfo(string key , out AudioInfo value)
        {
            value = audioInfos.FirstOrDefault(info => info.Key == key);
            var keyExist = value is not null;
            return keyExist;
        }

    #endregion
    }
}