using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    float _length, _startPos;
    GameObject _cam;
    [SerializeField] float _parallaxEffect;

    private void Start()
    {
        _startPos = transform.position.x;
        _length = GetComponent<SpriteRenderer>().bounds.size.x;
        _cam = GameObject.FindGameObjectWithTag("MainCamera");
    }


    private void Update()
    {

        float _temp = _cam.transform.position.x * (1 - _parallaxEffect);
        float _dist = _cam.transform.position.x * _parallaxEffect;

        transform.position = new Vector3(_startPos + _dist, transform.position.y, transform.position.z);

        if (_temp > _startPos + _parallaxEffect ) _startPos += _length;
        else if (_temp < _startPos - _length ) _startPos -= _length;

    }

}
