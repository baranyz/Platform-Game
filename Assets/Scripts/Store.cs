using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    float _firstYPos;
    Vector3 _firstPos;

    private void Start() {
        
        _firstYPos = transform.position.y;
        _firstPos = transform.position;
    }

    private void OnDisable() {
        
        transform.position = _firstPos;
    }

    private void Update() {
            
        if(_firstYPos + 130 > transform.position.y) transform.Translate(Vector2.up * Time.deltaTime * 300);
    }
}
