using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test2 : MonoBehaviour
{
    public int hp = 180;
    public Text textHpUI;
    public Text textStateUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // UI ����
        textHpUI.text = hp.ToString();

        if (hp <= 50)
        {
            textStateUI.text = "Run!!";
        }
        else if (hp >= 200)
        {
            textStateUI.text = "Attack!!";
        }
        else
        {
            textStateUI.text = "Defense!!";
        }

        //============================================================================

        if (Input.GetMouseButtonDown(0)) // ���� ���콺 ��ư
        {
            hp += 10;
        }

        if (Input.GetMouseButtonDown(1)) // ������ ���콺 ��ư
        {
            hp -= 10;
        }


       
    }
}
