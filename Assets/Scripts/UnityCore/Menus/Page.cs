using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityCore{
    
    namespace Menu{
        
        public class Page : MonoBehaviour
        {
            public static readonly string FLAG_ON = "On";
            public static readonly string FLAG_OFF = "Off";
            public static readonly string FLAG_NONE = "None";

            public PageType type;
            public bool useAnimation;
            public string targetState{get; private set;}

            private Animator m_Animator;

            #region Unity Functions
                private void OnEnable() {}
            #endregion

            #region Public Functions
                public void Animate(bool _on){}
            #endregion

            #region Private Functions
                private IEnumerator AwaitAnimation(bool _on){ yield return null;}
                private void CheckAnimatorIntegrity(){}
                private void Log(string _msg){}
                private void LogWarning(string _msg){}
                private void LogError(string _msg){}
            #endregion

        }
    }
}
