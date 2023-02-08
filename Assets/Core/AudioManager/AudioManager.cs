#region

using GameJamUtility.Core.UnityUtility;
using UnityEditor;
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
                var prefab = GetPrefab();
                if (prefab is null)
                {
                    Debug.LogWarning("audio manager prefab is null. place a AudioManager prefab in Resources/GameJamUtility path.");
                    return null;
                }

                var audioManager = CreateAudioManager(prefab);
                if (prefab.dontDestroyOnLoad) DontDestroyOnLoad(audioManager);
                instance = audioManager;
                return instance;
            }
        }

        public bool dontDestroyOnLoad = true;

    #endregion

    #region Private Variables

        private static AudioManager instance;

        private AudioSource audioSource;

        private bool isInit;

        [SerializeField]
        private AudioDatabase audioDatabase;

        [SerializeField]
        private MusicDataBase musicDataBase;

    #endregion

    #region Public Methods

        public void PlayAudio(string audioKey , float volumeScale = 1.0f)
        {
            Init();
            if (audioDatabase.TryGetValue(audioKey , out var clip)) audioSource.PlayOneShot(clip , volumeScale);
            else Debug.LogWarning($"[Play Audio] - can't find audio by key: {audioKey} , Try add AudioInfo in prefab.");
        }

        public void PlayMusic(string musicKey)
        {
            Init();
            if (musicDataBase.TryGetValue(musicKey , out var clip))
            {
                audioSource.clip = clip;
                audioSource.Play();
            }
            else
            {
                Debug.LogWarning($"[Play Music] - can't find music by key: {musicKey} , Try add MusicInfo in prefab.");
            }
        }

    #endregion

    #region Private Methods

        private void ClearInstanceIfEditor()
        {
        #if UNITY_EDITOR
            if (EditorSettings.enterPlayModeOptionsEnabled) instance = null;
        #endif
        }

        private static AudioManager CreateAudioManager(AudioManager prefab)
        {
            var audioManager = Instantiate(prefab);
            audioManager.Init();
            return audioManager;
        }

        private static AudioManager GetPrefab()
        {
            var prefab = Resources.Load<AudioManager>("GameJamUtility/AudioManager");
            return prefab;
        }

        private void Init()
        {
            if (isInit) return;
            isInit                  = true;
            audioSource             = gameObject.GetOrAddComponent<AudioSource>();
            audioSource.playOnAwake = false;
            audioSource.clip        = null;
        }

        private void OnDisable()
        {
            ClearInstanceIfEditor();
        }

    #endregion
    }
}