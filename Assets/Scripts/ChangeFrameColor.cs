using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFrameColor : MonoBehaviour
{
    //Hierarchyからカラーをセット
    [SerializeField] Color[] Colors;

    Renderer Renderer;
    int CurrentColorIdx;

    void Awake()
    {
        //何度も呼ぶAPIはキャッシュしておく
        Renderer = GetComponent<Renderer>();
        //始めのカラーを表示
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
        //デフォのブロックの色を緑にする
        GetComponent<Renderer>().material.color = Color.green;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //自身(ブロック)に"Player"オブジェクトが当たったとき
        if (collision.gameObject.name == "Player")
        {
            GetComponent<Renderer>().material.color = Color.red;
            //破壊する(対象：自身のゲームオブジェクト)
            //Destroy(this.gameObject);
        }
    }
}    
*/