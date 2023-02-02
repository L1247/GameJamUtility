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
                Debug.Log("space down");
                AudioManager.Instance.PlayAudio("Success");
            }
        }

    #endregion
    }
}