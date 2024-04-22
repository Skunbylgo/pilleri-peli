using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pilleripeli
{
    public class TimeManager : MonoBehaviour
    {
        private float zeroTimescale = 0.0f;
        private float oneTimescale = 1.0f;
        public void Pause(bool value)
        {
            if(value)
            {
                Time.timeScale = zeroTimescale;
            }
            else if(!value)
            {
                Time.timeScale = oneTimescale;
            }
        }
    }
}
