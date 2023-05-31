using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{

    protected GameManager GameManager => GameManager.Instance;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.OnGameStateChanged += UpdateUI;
    }


    private void OnDisable()
    {
        GameManager.OnGameStateChanged -= UpdateUI;
    }
    private void UpdateUI(GameManager.GameState state)

    {
        switch(state)
        {
            case GameManager.GameState.Start:
                Debug.Log("게임 시작 UI 업데이트");
                break;

            case GameManager.GameState.Playing:
                Debug.Log("게임 플레이중 UI 업데이트");
                break;
            case GameManager.GameState.GameOver:
                Debug.Log("게임 오버 UI 업데이트");
                break;

        }
    }

    // Update is called once per frame
    
}
