using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFrameColor : MonoBehaviour
{
    //Inspectorからカラーをセット
    [SerializeField] Color[] colors;

    [SerializeField] Renderer frameRenderer;
    int CurrentColorIdx;

    void Awake()
    {
        //始めのカラーを表示
        ChangeMaterialColor();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        ChangeMaterialColor();
    }

    void ChangeMaterialColor()
    {
        frameRenderer.material.color = colors[CurrentColorIdx];
        CurrentColorIdx++;
        if (CurrentColorIdx >= colors.Length) /*CurrentColorIdx = 0;*/ Destroy(gameObject, 0.2f);
    }
}