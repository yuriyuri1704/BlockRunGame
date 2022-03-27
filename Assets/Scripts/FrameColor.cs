using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameColor : MonoBehaviour
{
    //Inspector����J���[���Z�b�g
    [SerializeField] Color[] colors;

    [SerializeField] Renderer frameRenderer;
    
    private int currentColorIdx;
    private float delayDestroySeconds = 0.2f;

    void Awake()
    {
        //�n�߂̃J���[��\��
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