using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalanceError : MonoBehaviour
{
    Image _img;

    private void Start() {
        _img = GetComponent<Image>();
    }

    private void Update() {
        
        float t = Mathf.PingPong(Time.time * 2, 1);
        _img.color = new Vector4(1,1,1,t);
    }
}
