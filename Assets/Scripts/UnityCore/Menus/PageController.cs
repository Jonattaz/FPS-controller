using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UnityCore{

    namespace Menu{
        public class PageController : MonoBehaviour
        {

            public static PageController instance;

            [SerializeField]private bool debug;
            // Page that loads up at the begining of the game 
            [SerializeField]private PageType entryPage;
            // UI objects in the Unity Hierarchy
            [SerializeField]private Page[] pages;

            // Represents the relationship between page and pagetype
            private  Hashtable m_Pages;

            #region Unity Functions
                private void Awake() {

                }
            #endregion

            #region Public Functions
                public void TurnPageOn(PageType _type){} 
                public void TurnPageOff(PageType _off, PageType _on=PageType.None, bool _WaitForExit=false){}

            #endregion

            #region  Private Functions

                private IEnumerator WaitForPageExit(Page _on, Page _off){ yield return null;}
                private void RegisterAllPages(){}
                private void RegisterPage(Page _page){}
                private Page GetPage(PageType _type){ return null;}
                // Verify if the page exists
                private bool PageExists(PageType _type){ return false;}
                private void Log(string _msg){}
                private void LogWarning(string _msg){}
                private void LogError(string _msg){}
            #endregion
        }
    }
}













