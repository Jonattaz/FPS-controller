using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityCore{
    
    namespace Data{
       
        public class DataController : MonoBehaviour
        {
            private static readonly string DATA_SCORE = "Score";
            private static readonly string DATA_HIGHSCORE = "Highscore";
            private static readonly int DEFAULT_INT = 0;

            #region Properties
                public int Score{
                    get{
                        return GetInt(DATA_SCORE);
                    }
                    set{
                        SaveInt(DATA_SCORE, value);
                        int _score = this.Score;
                        if(_score > this.Highscore){
                            this.Highscore = _score;
                        }
                    }
                }

                public int Highscore{
                    get{
                        return GetInt(DATA_HIGHSCORE);
                    }
                    private set{
                        SaveInt(DATA_HIGHSCORE, value);
                    }
                }
                 
            #endregion

            #region Private Functions
                private void SaveInt(string _data, int _value){
                    PlayerPrefs.SetInt(_data, _value);
                }

                private int GetInt(string _data){
                    return PlayerPrefs.GetInt(_data, DEFAULT_INT);
                }
            #endregion
        }
    }
}
