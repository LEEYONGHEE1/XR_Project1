using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    protected SceneChanger SceneChanger => SceneChanger.Instance;
    public enum GameState
    {
        Start,
        Playing,
        GameOver

    }

    public event Action<GameState> OnGameStateChanged;

    public GameState currentState = GameState.Start;

    public GameState CurrentState
    {
        get { return currentState; }


        private set
        {
            currentState = value;
            OnGameStateChanged?.Invoke(currentState);
        }
    }

    public void StartGame()
    {
        CurrentState = GameState.Playing;
    }

    public void GameOver() 
    {
        currentState = GameState.GameOver;

    }
    // Start is called before the first frame update
    public GameManager() { }

    public static GameManager Instance { get; private set; }

    public PlayerHp playerHp;
    public Image playerHpHIImage;
    public Button BtnSample;

    //private void Start()
    //{
    //    this.BtnSample.onClick.AddListener(() =>
    //    {
    //        Debug.Log("Button Click");
    //    });
    //}

    private void Awake()
    {
        if(Instance)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            transform.parent = null;
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        Init();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(Scene.name = "GameScene")
        {
            playerHp.Hp = 100;
        }
    }
    private void Init()
    {
        playerHp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHp>();
        playerHpHIImage = GameObject.FindGameObjectWithTag("UIHealthBar").GetComponent<Image>();
    }

    private void Update()
    {
        playerHpHIImage.fillAmount = (float)playerHp.Hp / 100.0f;
    }
}
