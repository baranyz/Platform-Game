using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastLevelSpawner : MonoBehaviour
{
    [SerializeField] GameObject _bigFace, _ball;
    List<GameObject> _gameobjects;
    int _random;
    private void Start() {
        
        _gameobjects = new List<GameObject> {_bigFace, _ball};
        InvokeRepeating("Spawn", Random.Range(0,1), Random.Range(10, 30));
    }

    private void Update() {
        Debug.Log(_random);
    }

    private void Spawn(){
        _random = Random.Range(0,2);
        Instantiate(_gameobjects[_random], transform.position, Quaternion.identity);
        
    }
}
