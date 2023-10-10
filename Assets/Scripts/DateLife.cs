using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateLife : MonoBehaviour
{
    private void Start() {
 
        if(PlayerPrefs.GetString("lastTime") == ""){
            PlayerPrefs.SetString("lastTime",DateTime.Now.ToString());
            return;
        }
        DateTime last = DateTime.Parse(PlayerPrefs.GetString("lastTime"));
        DateTime now = DateTime.Now;

        TimeSpan timeSpan = now-last;

        if(timeSpan.Days >= 1){
            PlayerPrefs.SetInt("_lifesCount",0);
        }

        PlayerPrefs.SetString("lastTime",now.ToString());

    }

}
