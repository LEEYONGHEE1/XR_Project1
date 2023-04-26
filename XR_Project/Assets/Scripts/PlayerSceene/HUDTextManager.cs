using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDTextManager : MonoBehaviour
{

    public Text hudText;
    public GameObject character;
    public Vector3 offset;

    public GameObject HudTextUp;
    public GameObject canvasObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (character != null)
        {
            Vector3 characterHeadPosition = character.transform.position;
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(characterHeadPosition);     //3D 포지션을 2D로 변환
            hudText.transform.position = screenPosition + offset;

        }
        // 캐릭터 머리 위에 텍스트 표시
        

    }

    public void UpdateHUDTextSet(string newText, GameObject target, Vector3 TargetOffset)
    {
        Vector3 TagetPosition = target.transform.position;
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(TagetPosition);
        GameObject temp = (GameObject)Instantiate(HudTextUp);
        temp.transform.SetParent(canvasObject.transform, false);
        temp.transform.position = screenPosition + TargetOffset;
        temp.GetComponent<HUDMove>().textUI.text = newText;

    }
}
