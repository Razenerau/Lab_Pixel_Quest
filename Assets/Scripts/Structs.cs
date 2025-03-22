using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structs : MonoBehaviour
{
    public struct Tags
    {
        public const string GROUNDTAG = "Ground";
        public const string ENEMYTAG = "Enemy";
        public const string FINISHTAG = "Finish";
        public const string COIN = "Coin";
    }

    public struct LevelManager
    {
        private int _levelIndex;
        public int levelIndex 
        {
            get {  return _levelIndex; }
            set { _levelIndex = value; }
        }

        public static bool isWhitePlayerFinish;
        public static bool isBlackPlayerFinish;

        /*
        public bool whitePlayerFinish
        {
            get { return _isWhitePlayerFinish;  }
            set { _isWhitePlayerFinish = value; }
        }
        public bool blackPlayerFinish
        {
            get { return _isBlackPlayerFinish;  }
            set { _isBlackPlayerFinish = value; }
        } */

    }
}
