using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDestruction : MonoBehaviour
{
   
    //OnCollisionEnter2D：自身に何か当たったときの関数
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //自身(ブロック)に"Player"オブジェクトが当たったとき
        if (collision.gameObject.name == "Player" && GetComponent<Renderer>().material.color == Color.red)
        {            
            //破壊する(対象：自身のゲームオブジェクト)
            Destroy(this.gameObject);     
        }
    }

}
