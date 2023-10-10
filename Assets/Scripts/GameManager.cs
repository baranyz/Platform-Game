using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject _gameoverText;
    [SerializeField] GameObject _player1, _player2, _player3, _player4;
    GameObject _player;
    [SerializeField] GameObject _life1, _life2, _life3;
    [SerializeField] TextMeshProUGUI _diamondCountText;
    [SerializeField] RectTransform _diamondUp;
    GameObject _cam;

    public static bool _isLeftButtonDown, _isRightButtonDown, _isButtonUp, _isJump, _isHit;
    public static bool _gameover, _lifesMinusEffect, _diamondEffect;
    float _PlayerDeadColor, _leftLifeScale, _diamondUpScale;
    bool _isLeftTime;
    public static int _lifesCount, _diamondCount;

    private void Awake() {
        
        if(PlayerPrefs.GetInt("PlayerSpawn") == 1){
            _player = _player1;
        }
        else if(PlayerPrefs.GetInt("PlayerSpawn") == 2){
            _player = _player2;
        }
        else if(PlayerPrefs.GetInt("PlayerSpawn") == 3){
            _player = _player3;
        }
        else if(PlayerPrefs.GetInt("PlayerSpawn") == 4){
            _player = _player4;
        }
        Instantiate(_player);
    }

    private void Start()
    {   
        _player = GameObject.FindGameObjectWithTag("Player");

        _PlayerDeadColor = 1f;
        _leftLifeScale = 1f;
        _diamondUpScale = 1f;

        _lifesCount = PlayerPrefs.GetInt("_lifesCount");
        _diamondCount = PlayerPrefs.GetInt("_diamondCount");

        _cam = GameObject.FindGameObjectWithTag("MainCamera");

        _gameover = false;
       
    }

    private void Update() {

        if(_gameover == true){
            Gameover();
            PlayerDeath();
        }
        else if(_gameover == false){
            try{

                _gameoverText.SetActive(false);
                _cam.GetComponent<CameraFollow>().enabled = true;
                _player.GetComponent<PlayerController>().enabled = true;
                _player.GetComponent<Animator>().enabled = true;
                _PlayerDeadColor = 1;
                _player.GetComponent<Rigidbody2D>().gravityScale = 1;
                _player.GetComponent<Collider2D>().enabled = true;
            }
            catch{}
            
        
        }
        _diamondUp.localScale = new Vector3(_diamondUpScale, _diamondUpScale, 1);
        if(_diamondEffect){

            _diamondUpScale += Time.deltaTime;
            if(_diamondUpScale > 1.3){
            _diamondEffect = false;
            }
        }
        else if(_diamondEffect == false){
            if(_diamondUpScale > 1){
                _diamondUpScale -= Time.deltaTime;
                if(_diamondUpScale == 1) _diamondUpScale =1;
                
            }
        }

        _diamondCountText.SetText("x"+_diamondCount);
        

        Life();
        Save();
    }

    private void Life(){
        
        if(_lifesCount< 3 && _lifesCount >= 0){
            _gameover = false;
            if(_lifesCount == 0) {
                _life1.SetActive(true);
                _life2.SetActive(true);
                _life3.SetActive(true);
            }
            if(_lifesCount == 1){
                
                _life2.SetActive(true);
                _life3.SetActive(true);
                LifeEffect(_life1);
            }
            if(_lifesCount == 2){
                _life1.SetActive(false);
                _life3.SetActive(true);
                LifeEffect(_life2);
            }
           
        }
        else if(_lifesCount == 3){
            
            _life1.SetActive(false);
            _life2.SetActive(false);
            LifeEffect(_life3);
            
            _gameover = true;
        }
        else{
            _lifesCount=3;
        }

        
    }

    private void LifeEffect(GameObject life){

        life.GetComponent<RectTransform>().localScale = new Vector3(_leftLifeScale, _leftLifeScale, 1);
        _leftLifeScale -= Time.deltaTime;
        if(_leftLifeScale < 0.1f){
            life.SetActive(false);
            _leftLifeScale =1;
        }

    }
    void Save(){
        PlayerPrefs.SetInt("_lifesCount", _lifesCount);
        PlayerPrefs.SetInt("_diamondCount", _diamondCount);
    }
    void PlayerDeath(){
        if(_cam.GetComponent<CameraFollow>() != null)_cam.GetComponent<CameraFollow>().enabled = false;
        _player.GetComponent<PlayerController>().enabled = false;
        _player.GetComponent<Animator>().enabled = false;
        _PlayerDeadColor -= Time.deltaTime/2;
        _player.GetComponent<Rigidbody2D>().gravityScale = 0;
        _player.transform.Translate(Vector2.up * Time.deltaTime /4);
        _player.GetComponent<Collider2D>().enabled = false;
        _player.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, _PlayerDeadColor);
    }

    void Gameover()
    {
        _gameoverText.SetActive(true);

        if (_gameoverText.GetComponent<TextMeshProUGUI>().fontSizeMax < 150) _gameoverText.GetComponent<TextMeshProUGUI>().fontSizeMax += Time.deltaTime *100;
        else SceneManager.LoadScene(0);
    }

    public void onLeftButtonDown()
    {
        _isLeftButtonDown = true;
        _isButtonUp = false;
    }
    public void onRightButtonDown()
    {
        _isRightButtonDown = true;
        _isButtonUp = false;
    }
    public void ButtonUp()
    {
        _isLeftButtonDown = false;
        _isRightButtonDown = false;
        _isButtonUp = true;
    }
    
    public void onHitButtonDown()
    {
        _isHit = true;
    }

    public void onJumpButtonDown()
    {
        _isJump = true;
    }
 

}
