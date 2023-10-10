using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MenuGameManager : MonoBehaviour
{
    [SerializeField] GameObject _errorBal, _errorBalArrow, _addInfoPanel;
    [SerializeField] GameObject _errorLife, _errorLifeArrow;
    [SerializeField] GameObject _soundOn, _SoundOff;
    [SerializeField] TextMeshProUGUI _diamondText;
    [SerializeField] GameObject _life1, _life2, _life3;
    [SerializeField] GameObject _lifeButton, _store, _balanceText, _menuCanvas;
    [SerializeField] Button _storeButton ,_player1Button, _player2Button, _player3Button, _player4Button, _adInfoButton;
    AudioSource _audio;
    int _lifesCount;
    int _audioPrefs;
    bool _isStoreChange = false;
    List<Button> _playerButtons;
    int _isPlayer1, _isPlayer2, _isPlayer3, _isPlayer4;
    List<int> _isPlayers;
    bool _isBalance, _isError, _isLifeError;
    float _balanceTime = 0;
    float _errorTime = 0, _errorLifeTime = 0;

    private void OnApplicationQuit() {
        PlayerPrefs.SetInt("addInfo", 0);
    }
    private void OnEnable() {
        
        if(PlayerPrefs.GetInt("addInfo") == 1) _addInfoPanel.SetActive(false);
        if(PlayerPrefs.GetInt("Levels") == 0) PlayerPrefs.SetInt("Levels", 1);
        if(PlayerPrefs.GetInt("PlayerSpawn") == 0) PlayerPrefs.SetInt("PlayerSpawn", 1);

        _adInfoButton?.onClick.AddListener(()=>{
            _addInfoPanel.SetActive(false);
            PlayerPrefs.SetInt("addInfo", 1);
        });

        _storeButton.onClick.AddListener(() => {
            if(!_store.activeSelf) _store.SetActive(true);
            else _store.SetActive(false);
        });

        _player1Button.onClick.AddListener(() => {
            _isStoreChange = true;
            PlayerPrefs.SetInt("PlayerSpawn", 1);
        });

        _player2Button.onClick.AddListener(() => {
            if(PlayerPrefs.GetInt("_isPlayer2") == 0 && PlayerPrefs.GetInt("_diamondCount") >= 500){
                _isStoreChange = true;
                PlayerPrefs.SetInt("PlayerSpawn", 2);
                PlayerPrefs.SetInt("_diamondCount", (PlayerPrefs.GetInt("_diamondCount")-500));
                PlayerPrefs.SetInt("_isPlayer2", 1);
            }
            else if(PlayerPrefs.GetInt("_isPlayer2") == 1){
                _isStoreChange = true;
                PlayerPrefs.SetInt("PlayerSpawn", 2);
            }
            else _isBalance = true;
        });

        _player3Button.onClick.AddListener(() => {
            if(PlayerPrefs.GetInt("_isPlayer3") == 0 && PlayerPrefs.GetInt("_diamondCount") >= 5000){
                _isStoreChange = true;
                PlayerPrefs.SetInt("PlayerSpawn", 3);
                PlayerPrefs.SetInt("_diamondCount", (PlayerPrefs.GetInt("_diamondCount")-5000));
                PlayerPrefs.SetInt("_isPlayer3", 1);
            }
            else if(PlayerPrefs.GetInt("_isPlayer3") == 1){
                _isStoreChange = true;
                PlayerPrefs.SetInt("PlayerSpawn", 3);
            }
            else _isBalance = true;
        });

        _player4Button.onClick.AddListener(() => {
            if(PlayerPrefs.GetInt("_isPlayer4") == 0 && PlayerPrefs.GetInt("_diamondCount") >= 10000){
                _isStoreChange = true;
                PlayerPrefs.SetInt("PlayerSpawn", 4);
                PlayerPrefs.SetInt("_diamondCount", (PlayerPrefs.GetInt("_diamondCount")-10000));
                PlayerPrefs.SetInt("_isPlayer4", 1);
            }
            else if(PlayerPrefs.GetInt("_isPlayer4") == 1){
                _isStoreChange = true;
                PlayerPrefs.SetInt("PlayerSpawn", 4);
            }
            else _isBalance = true;
        });
    }
    private void Start() {

        for(int i = 1; i <= PlayerPrefs.GetInt("Levels"); i++){

            _menuCanvas.transform.GetChild(i).GetComponent<Image>().color = Color.green;
        }

        _playerButtons = new List<Button>(){_player1Button,_player2Button,_player3Button,_player4Button};
        _isStoreChange = true;

        _lifesCount = PlayerPrefs.GetInt("_lifesCount");

        _audio = GetComponent<AudioSource>();

        _audioPrefs = PlayerPrefs.GetInt("_audioPrefs");

        if(_audioPrefs == 1){
            _soundOn.SetActive(true);
            _SoundOff.SetActive(false);
            AudioListener.pause = false;
        }
        if(_audioPrefs == 2){
            _soundOn.SetActive(false);
            _SoundOff.SetActive(true);
            AudioListener.pause = true;
        }
        else {
            _soundOn.SetActive(true);
            _SoundOff.SetActive(false);
            AudioListener.pause = false;
        }
        
    }

    private void Update() {

        if(_isLifeError){

            _errorLife.SetActive(true);
            _errorLifeArrow.SetActive(true);
            _errorLifeTime += Time.deltaTime;
            if(_errorLifeTime > 2){
                _errorLife.SetActive(false);
                _errorLifeArrow.SetActive(false);
                _errorLifeTime = 0;
                _isLifeError = false;
            }
        }

        if(_isError){

            _errorBal.SetActive(true);
            _errorBalArrow.SetActive(true);
            _errorTime += Time.deltaTime;
            if(_errorTime > 2){
                _errorBal.SetActive(false);
                _errorBalArrow.SetActive(false);
                _errorTime = 0;
                _isError = false;
            }
        }

        if(_isBalance){
            _balanceText.SetActive(true);
            _balanceTime += Time.deltaTime;
            if(_balanceTime > 1){
                _balanceTime = 0;
                _isBalance = false;
            }
        }
        else _balanceText.SetActive(false);

        if(_isStoreChange){

            _isPlayer1 = PlayerPrefs.GetInt("_isPlayer1");
            _isPlayer2 = PlayerPrefs.GetInt("_isPlayer2");
            _isPlayer3 = PlayerPrefs.GetInt("_isPlayer3");
            _isPlayer4 = PlayerPrefs.GetInt("_isPlayer4");
            _isPlayers = new List<int>(){_isPlayer1, _isPlayer2, _isPlayer3, _isPlayer4};

            for(int i = 0; i < 4; i++){
                if(i != 0 && _isPlayers[i] == 1){
                    _playerButtons[i].transform.GetChild(0).gameObject.SetActive(false);
                }

                if(PlayerPrefs.GetInt("PlayerSpawn") == i+1){
                    _playerButtons[i].GetComponent<Image>().color = new Vector4(1,1,1,1);
                }
                else if(PlayerPrefs.GetInt("PlayerSpawn") != i+1){
                    _playerButtons[i].GetComponent<Image>().color = new Vector4(1,1,1,0.25f);
                }
            }
            _isStoreChange = false;
        }
   
        PlayerPrefs.SetInt("_audioPrefs", _audioPrefs);       
        MenuLife();
        
        PlayerPrefs.SetInt("_lifesCount", _lifesCount);

        _diamondText.SetText("x"+PlayerPrefs.GetInt("_diamondCount"));

        if(_lifesCount == 0){
            _lifeButton.SetActive(false);
        }  
        else if(_lifesCount <= 3){
            _lifeButton.SetActive(true);
        }

    }

    private void MenuLife(){

        if(_lifesCount<= 3 && _lifesCount >= 0){

            if(_lifesCount == 0) {
                _life1.SetActive(true);
                _life2.SetActive(true);
                _life3.SetActive(true);
            }
            if(_lifesCount == 1){
                _life1.SetActive(false);
                _life2.SetActive(true);
                _life3.SetActive(true);
            }
            if(_lifesCount == 2){
                _life1.SetActive(false);
                _life2.SetActive(false);
                _life3.SetActive(true);
            }
            if(_lifesCount == 3){
                _life1.SetActive(false);
                _life2.SetActive(false);
                _life3.SetActive(false);
            }
        }
    }

    public void OnDiamondButton(){
        
        PlayerPrefs.SetInt("_diamondCount", PlayerPrefs.GetInt("_diamondCount")+100);
    }

    public void OnAddLife(){
        if(PlayerPrefs.GetInt("_diamondCount") >= 10){
            if(_lifesCount > 0){
                PlayerPrefs.SetInt("_diamondCount", (PlayerPrefs.GetInt("_diamondCount")-10));
                _lifesCount --;
            }
        }
        else if(_isLifeError == false) _isError = true;
    }
    public void OnSoundOnClick(){
        _soundOn.SetActive(false);
        _SoundOff.SetActive(true);
        _audio.Play();
        _audioPrefs = 2;
        AudioListener.pause = true;

    }
    public void OnSounOffClick(){
        _soundOn.SetActive(true);
        _SoundOff.SetActive(false);
        _audio.Play();
        _audioPrefs = 1;
        AudioListener.pause = false;
    }

    public void OnLevelButton(int level){
        if(_lifesCount < 3 && PlayerPrefs.GetInt("Levels") >= level){
            SceneManager.LoadScene(level);
        }
        else if(_lifesCount == 3 && PlayerPrefs.GetInt("Levels") >= level){
            if(_isError == false) _isLifeError = true;
        }
    }

}
