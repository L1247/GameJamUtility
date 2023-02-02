#region

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
        private AudioDatabase audioDatabase;

    #endregion

    #region Public Methods

        public void PlayAudio(string audioKey)
        {
            if (audioDatabase.TryGetInfo(audioKey , out var info))
            {
                var clip = info.Value;
                audioSource.PlayOneShot(clip);
            }
            else
            {
                Debug.LogWarning($"[Play Audio] - can't find audio by key: {audioKey} , Try add AudioInfo in prefab.");
            }
        }

        public void PlayMusic(string musicKey) { }

    #endregion

    #region Private Methods

        private void Init()
        {
            audioSource             = gameObject.GetOrAddComponent<AudioSource>();
            audioSource.playOnAwake = false;
            audioSource.clip        = null;
        }

    #endregion
    }
}