#region

using GameJamUtility.Core.AudioManager;
using UnityEngine;

#endregion

namespace Demo
{
    public class DemoController : MonoBehaviour
    {
    #region Unity events

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("key Space down");
                AudioManager.Instance.PlayAudio("Success");
            }

            if (Input.GetKeyDown(KeyCode.B))
            {
                Debug.Log("key B down");
                AudioManager.Instance.PlayMusic("Epic Battle");
            }
        }

    #endregion
    }
}