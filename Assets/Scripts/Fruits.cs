using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{
    AudioSource _audio;
    SpriteRenderer _spr;

    private void Start() {
        _audio = GetComponent<AudioSource>();
        _spr = GetComponent<SpriteRenderer>();
    }
    private void Update() {
        
        float _pingPong = Mathf.PingPong(Time.time*3, 1);
        transform.position = Vector2.Lerp(new Vector2(transform.position.x, transform.position.y + Time.deltaTime), new Vector2(transform.position.x, transform.position.y - Time.deltaTime), _pingPong);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            _audio.Play();
            GameManager._diamondCount += 10;
            GameManager._diamondEffect = true;
            _spr.enabled = false;
            Destroy(this.gameObject, _audio.clip.length);
        }
    }
}
