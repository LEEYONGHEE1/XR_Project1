using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager() { }

    public static GameManager Instance { get; private set; }

    public PlayerHp playerHp;
    public Image playerHpHIImage;

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
