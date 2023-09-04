using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBack02 : MonoBehaviour
{
    [SerializeField] private float scrollSpeed; //背景をスクロールさせるスピード
    [SerializeField] private float startLine;//背景のスクロールを開始する位置
    [SerializeField] private float deadLine; //背景のスクロールが終了する位置
    public static ScrollBack02 scrollins;//インスタンスの生成

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Awake()
    {
        if (scrollins == null)
        {
            scrollins = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ScrollPlus();
    }

    //スクロール
    public void ScrollPlus()
    {
        transform.Translate(scrollSpeed, 0, 0); //x方向にscrollSpeed分動かす

        if (transform.position.x < deadLine) //もし背景のx座標よりdeadLineが大きくなったら
        {
            transform.position = new Vector3(startLine, 0, 0);//背景をstartLineまで戻す
        }

        Debug.Log("スクロール開始");
    }
}
