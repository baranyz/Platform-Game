using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainMain : MonoBehaviour
{
    float _rotateZ;
    bool _isDirectChange;

    private void Update() {
        transform.Rotate(0,0, _rotateZ);

        if(transform.rotation.z > 0.4f){
            _isDirectChange = true;
        }
        if(transform.rotation.z < -0.4f){
            _isDirectChange = false;
        }

        if(_isDirectChange){
            _rotateZ = -Time.deltaTime *100;
        }
        if (_isDirectChange == false){
            _rotateZ = Time.deltaTime *100;
        }

        
    }
}
