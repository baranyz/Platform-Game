using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speed = 4f;
    [SerializeField] float _Jumpspeed = 4f;
    [SerializeField] AudioSource _audioHit, _audioJump, _audioLife;
    Rigidbody2D _rgb;
    Animator _ani;
    SpriteRenderer _spr;
    Collider2D _col;
    bool _isEffect;
    float _effectTime;

    private void Start()
    {
        _rgb = GetComponent<Rigidbody2D>();
        _ani = GetComponent<Animator>();
        _spr = GetComponent<SpriteRenderer>();
        _col = GetComponent<Collider2D>();

        _spr.color = new Color(1, 1, 1, 1);

        _effectTime = 0;

        _ani.SetBool("isAppear", true);
        
    }
    private void Update()
    {
        if(_ani.GetCurrentAnimatorStateInfo(0).IsName("Appear") && _ani.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f){
            _ani.SetBool("isAppear", false);
        }
        PlayerLifeEffect();
    }

    private void FixedUpdate()
    {
        
        MovementsAndAnimations();

    }

    void PlayerLifeEffect(){
        if(GameManager._lifesMinusEffect == true){
            _isEffect = true;
            _audioLife.Play();
            GameManager._isLeftButtonDown = false;
            _ani.SetBool("isRun", false);
            GameManager._isRightButtonDown = false;
            GameManager._isJump = false;
            if(_spr.flipX == true){
                if(Mathf.Approximately(_rgb.velocity.y, 0) == true){
                    _rgb.AddForce(new Vector2(3, 5), ForceMode2D.Impulse);
                    GameManager._lifesMinusEffect = false;
                }
                else if(Mathf.Approximately(_rgb.velocity.y, 0) == false){
                    _rgb.AddForce(new Vector2(3, 0), ForceMode2D.Impulse);
                    GameManager._lifesMinusEffect = false;
                }
            }
            else if(_spr.flipX == false){
                if(Mathf.Approximately(_rgb.velocity.y, 0) == true){
                    _rgb.AddForce(new Vector2(-3, 5), ForceMode2D.Impulse);
                    GameManager._lifesMinusEffect = false;
                }
                else if(Mathf.Approximately(_rgb.velocity.y, 0) == false){
                    _rgb.AddForce(new Vector2(-3, 0), ForceMode2D.Impulse);
                    GameManager._lifesMinusEffect = false;
                }
            }
        }
        if(_isEffect){
            _effectTime += Time.deltaTime;
            List<Color32> _ColorList = new(){new Color32(50,50,50,255), new Color32(255,255,255,255)};
            float _speedColor = Mathf.PingPong(Time.time*100, 1.1f);
            _spr.color = _ColorList[(int)_speedColor];
        }
        if(_effectTime > 0.5f){
            _isEffect = false;
            _effectTime = 0;
            _spr.color = new Color32(255,255,255,255);
        }
        
    }       

    void MovementsAndAnimations()
    {
        if (GameManager._isLeftButtonDown == true)
        {
            transform.Translate(Vector2.left * Time.deltaTime * _speed);
            _spr.flipX = true;
            _ani.SetBool("isRun", true);

        }
        else if (GameManager._isRightButtonDown == true)
        {
            transform.Translate(Vector2.right * Time.deltaTime * _speed);
            _spr.flipX = false;
            _ani.SetBool("isRun", true);
        }

        if (GameManager._isButtonUp == true)
        {
            _ani.SetBool("isRun", false);
        }

        if (GameManager._isJump == true && Mathf.Approximately(_rgb.velocity.y, 0) && _ani.GetBool("isFall") == false)
        {
            _rgb.AddForce(Vector2.up * _Jumpspeed, ForceMode2D.Impulse);
            _ani.SetBool("isJump", true);
            _audioJump.Play();
            GameManager._isJump = false;
        }
        if(Mathf.Approximately(_rgb.velocity.y, 0) != false) GameManager._isJump = false;
        
        if (_ani.GetBool("isJump") && _rgb.velocity.y < 0)
        {
            _ani.SetBool("isJump", false);
            _ani.SetBool("isFall", true);
        }

        if(_rgb.velocity.y < 0)
        {
            _ani.SetBool("isFall", true);
        }

        if (Mathf.Approximately(_rgb.velocity.y, 0))
        {
            _ani.SetBool("isFall", false);
        }

        if(_ani.GetCurrentAnimatorStateInfo(0).IsName("Hit") == false && GameManager._isHit == true)
        {
            _ani.SetBool("isHit", true);
            _audioHit.Play();
        }
        else
        {
            GameManager._isHit = false;
            _ani.SetBool("isHit", false);
        }

    }
}

