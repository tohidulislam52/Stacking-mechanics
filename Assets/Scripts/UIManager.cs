using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI _scroeText;
    [SerializeField] private TextMeshProUGUI _HighScroeText;
    [SerializeField] private TextMeshProUGUI _HighScroeText2;
    [SerializeField] private TextMeshProUGUI _gameoverScroe;
    [SerializeField] private TextMeshProUGUI _gameoverHighscroe;

    [SerializeField] private GameObject _player,_Start,_GameOver,_PlayPanel;
    private int _HighScore,_score;
    private bool _startGame=true;
    private UIManager _uimanager;
     void Awake() {
    _uimanager = this;    
    }
    void Start()
    {
        _Start.SetActive(true);
        _HighScore = PlayerPrefs.GetInt("HighScore", 0);
        _HighScroeText.text= _HighScore.ToString();
        _HighScroeText2.text= _HighScore.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if (Gamemanager.GameManagerInstance.StartTheGame)
        {
             _score =Mathf.Abs( Mathf.RoundToInt(_player.transform.position.z*2));
            // _score = Mathf.Abs(_score);
            _scroeText.text = _score.ToString();
            if(_score> _HighScore)
            {
                 _HighScore = _score;
                PlayerPrefs.SetInt("HighScore",_HighScore);
                _HighScroeText.text= _HighScore.ToString();
            }
        }
        if(Gamemanager.GameManagerInstance.StartTheGame && _startGame)
        {
            _startGame = false;
            StartGame();
        }
    }

    public void GameOver()
    {
        _PlayPanel.SetActive(false);
        _GameOver.SetActive(true);
        _gameoverScroe.text = _score.ToString();
        _gameoverHighscroe.text = PlayerPrefs.GetInt("HighScore",0).ToString();
    }
    public void StartGame()
    {
        _Start.SetActive(false);
        _PlayPanel.SetActive(true);
    }

    public void Play()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    
}
