using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDestruction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    //OnCollisionEnter2D�F���g�ɉ������������Ƃ��̊֐�
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //���g(�u���b�N)��"Player"�I�u�W�F�N�g�����������Ƃ�
        if (collision.gameObject.name == "Player" && GetComponent<Renderer>().material.color == Color.red)
        {            
                //�j�󂷂�(�ΏہF���g�̃Q�[���I�u�W�F�N�g)
                Destroy(this.gameObject);     
        }
    }

}
