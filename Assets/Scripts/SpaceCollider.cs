using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            GameManager._lifesCount = GameManager._lifesCount +3;
        }
    }
}
