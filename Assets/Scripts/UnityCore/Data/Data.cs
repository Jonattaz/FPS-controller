using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityCore{

    namespace Data{

        public class Data : MonoBehaviour
        {   
            public DataController dataController;

            #region Unity Functions
                #if UNITY_EDITOR
                    private void Update(){
                        if(Input.GetKeyUp(KeyCode.R)){
                            AddScoreTest(1);
                        }
                        if(Input.GetKeyUp(KeyCode.T)){
                            AddScoreTest(-1);
                        }
                        if(Input.GetKeyUp(KeyCode.Space)){
                            ResetScoreTest();
                        }
                    }
                #endif
            #endregion

            #region Private Functions
                private void AddScoreTest(int delta){
                    Log("Score = "+dataController.Score+" | Highscore = "+dataController.Highscore);
                    dataController.Score += delta;
                }
                private void ResetScoreTest(){
                    Log("Score = "+dataController.Score+" | Highscore = "+dataController.Highscore);
                     dataController.Score = 0;
                }
                private void Log(string _msg){
                    Debug.Log("[Data] " + _msg);
                } 
            #endregion

        }
    }
}
