using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameColor : MonoBehaviour
{
    //Inspectorからカラーをセット
    [SerializeField] Color[] colors;

    [SerializeField] Renderer frameRenderer;
    
    private int currentColorIdx;
    private float delayDestroySeconds = 0.2f;

    void Awake()
    {
        //始めのカラーを表示
        currentColorIdx = 0;
        frameRenderer.material.color = colors[0];

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        currentColorIdx++;
        
        if (currentColorIdx < colors.Length) {
            frameRenderer.material.color = colors[currentColorIdx];
        }
        else
        {
            Destroy(gameObject, delayDestroySeconds);
        }
    }

}