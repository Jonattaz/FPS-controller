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
                    if(!instance){
                        instance = this;
                        m_Pages = new Hashtable();
                        RegisterAllPages();

                        if(entryPage != PageType.None){
                            TurnPageOn(entryPage);
                        }
                    }
                }
            #endregion

            #region Public Functions
                public void TurnPageOn(PageType _type){
                    if(_type == PageType.None) return;
                    if(!PageExists(_type)){
                        LogWarning("You are trying to turn page on ["+_type+"] that has not been registered.");
                        return;
                    }

                    Page _page = GetPage(_type);
                    _page.gameObject.SetActive(true);
                    _page.Animate(true);
                } 
                public void TurnPageOff(PageType _off, PageType _on=PageType.None, bool _WaitForExit=false){
                    if(_off == PageType.None) return;
                    if(!PageExists(_off)){
                        LogWarning("You are trying to turn page off ["+_off+"] that has not been registered.");
                        return;
                    }

                    Page _offPage = GetPage(_off);
                    if(_offPage.gameObject.activeSelf){
                        _offPage.Animate(false);
                    }

                    
                    if(_on != PageType.None){
                        Page _onPage = GetPage(_on);
                        if(_WaitForExit){
                            StopCoroutine("WaitForPageExit");
                            StartCoroutine(WaitForPageExit(_onPage, _offPage));
                        }else{
                            TurnPageOn(_on);
                        }
                    }
                }

            #endregion

            #region  Private Functions

                private IEnumerator WaitForPageExit(Page _on, Page _off){ 
                    while(_off.targetState !=Page.FLAG_NONE){
                        yield return null;
                    }

                    TurnPageOn(_on.type);
                }
                private void RegisterAllPages(){
                    foreach (Page _page in pages){
                        RegisterPage(_page);
                    }
                }
                private void RegisterPage(Page _page){
                    if(PageExists(_page.type)){
                        LogWarning("You are trying to register a page ["+_page.type+"] that has already been registered: "+_page.gameObject.name);
                        return;
                    }

                    m_Pages.Add(_page.type, _page);
                    Log("Registered new page ["+_page.type+"]");
                }
                private Page GetPage(PageType _type){
                     if(!PageExists(_type)){
                        LogWarning("You are trying to get a page ["+_type+"] that has not been registered.");
                        return null;
                     }

                     return (Page)m_Pages[_type];
                }
                // Verify if the page exists
                private bool PageExists(PageType _type){ 
                    return m_Pages.ContainsKey(_type);
                }
                private void Log(string _msg){
                    if(!debug)return;
                    Debug.Log("[PageController]: "+_msg);
                }
                private void LogWarning(string _msg){
                    if(!debug)return;
                    Debug.LogWarning("[PageController]"+_msg);
                }      
            #endregion
        }
    }
}












