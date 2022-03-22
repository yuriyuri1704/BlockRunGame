using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFrameColor : MonoBehaviour
{
    //Hierarchy����J���[���Z�b�g
    [SerializeField] Color[] Colors;

    Renderer Renderer;
    int CurrentColorIdx;

    void Awake()
    {
        //���x���Ă�API�̓L���b�V�����Ă���
        Renderer = GetComponent<Renderer>();
        //�n�߂̃J���[��\��
        ChangeMaterialColor();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        ChangeMaterialColor();
    }

    void ChangeMaterialColor()
    {
        Renderer.material.color = Colors[CurrentColorIdx];
        CurrentColorIdx++;
        if (CurrentColorIdx >= Colors.Length) /*CurrentColorIdx = 0;*/ Destroy(gameObject, 0.2f);
    }
}


/*void Start()
    {
        //�f�t�H�̃u���b�N�̐F��΂ɂ���
        GetComponent<Renderer>().material.color = Color.green;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //���g(�u���b�N)��"Player"�I�u�W�F�N�g�����������Ƃ�
        if (collision.gameObject.name == "Player")
        {
            GetComponent<Renderer>().material.color = Color.red;
            //�j�󂷂�(�ΏہF���g�̃Q�[���I�u�W�F�N�g)
            //Destroy(this.gameObject);
        }
    }
}    
*/