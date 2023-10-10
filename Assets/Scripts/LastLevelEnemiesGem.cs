using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastLevelEnemiesGem : MonoBehaviour
{
    [SerializeField] GameObject _gem;
    int _randomSpawnTime;
    Animator _ani;
    bool _isSpawn;
    private void Start() {
        
        _ani = GetComponent<Animator>();
        _randomSpawnTime = Random.Range(1,100);
    }

    private void Update() {
        
        try{

            if((_ani.GetBool("isBigfaceDeath") || _ani.GetBool("isDeath")) && !_isSpawn && _randomSpawnTime > 50){

                Spawn();
                _isSpawn = true;
            }
        }
        catch{}
    
    }

    private void Spawn(){

        Instantiate(_gem, new Vector2(transform.position.x, transform.position.y +3f), Quaternion.identity);
    }
}
