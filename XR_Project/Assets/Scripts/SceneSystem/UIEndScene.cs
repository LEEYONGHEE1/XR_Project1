﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                       //UI �� ����ϱ� ���� ����

public class UIEndScene : MonoBehaviour
{
    protected SceneChanger SceneChanger => SceneChanger.Instance;     
    public Button gameButton;                           

    // Start is called before the first frame update
    void Start()
    {
        gameButton.onClick.AddListener(OnGameButtonClick);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnGameButtonClick()
    {
        SceneChanger.LoadLobbyScene();
    }
}