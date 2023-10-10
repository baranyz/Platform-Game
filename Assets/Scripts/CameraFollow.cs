using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    GameObject _player;
    Rigidbody2D _playerRgb;
    float _lerpT;
    private void Start() {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerRgb = _player.GetComponent<Rigidbody2D>();
    }

private void FixedUpdate() {

    if(Mathf.Approximately(_playerRgb.velocity.y, 0) == false){

        _lerpT = 1;
    }
    else{

        _lerpT = 6;
    }

    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, _player.transform.position.y + 2f, transform.position.z), Time.fixedDeltaTime *_lerpT);

    transform.position = new Vector3(_player.transform.position.x +5, transform.position.y, transform.position.z);
    
}

}
