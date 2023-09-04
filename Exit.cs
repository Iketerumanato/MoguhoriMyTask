using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    [SerializeField] private GameObject ExitUI;//ポーズの画像
    [SerializeField] private GameObject Yes;//リセットボタンのオブジェクト
    [SerializeField] private GameObject No;//セレクトシーンへ飛ぶボタンのオブジェクト
    [SerializeField] private GameObject Panel;//ポーズした時の背景が白くなる
    [SerializeField] Button[] button;//0->Retry,1->SelectScene

    //選択後の処理のため
    private bool ButtonFlg;

    public bool isPause;

    //PAD操作用
    float D_Pad_Vertical;

    void Start()
    {
        //コンポーネントの取得
        button[0] = Yes.GetComponent<Button>();
        button[1] = No.GetComponent<Button>();
        //ボタンが選択された状態になる
        ButtonFlg = false;
        isPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        //関数呼び出し
        Pause();
        Controll();
    }

    void Controll()
    {
        //十字キーまたはG,Bキーで操作、Aボタンまたはスペースキーで決定
        if (ButtonFlg == true)
        {
            float D_Pad_Vertical = Input.GetAxis("D_PAD_VERTICAL");

            if (Input.GetKeyDown(KeyCode.G)) //デバッグ用操作
            {
                D_Pad_Vertical = 1.0f;
            }
            if (Input.GetKeyDown(KeyCode.B))
            {
                D_Pad_Vertical = -1.0f;
            }

            if (D_Pad_Vertical == 1.0f)
            {
                button[0].Select();

                if (Input.GetButtonDown("DECISION"))
                {
                    button[0].onClick.Invoke();
                }
            }

            if (D_Pad_Vertical == -1.0f)
            {
                button[1].Select();

                if (Input.GetButtonDown("DECISION"))
                {
                    button[1].onClick.Invoke();
                }
            }
        }
    }

    //ポーズの機能
    void Pause()
    {
        //PAUSEキーでポーズ
        if (Input.GetButtonDown("PAUSE") || ((Input.GetButtonDown("BACK")) && (ExitUI.activeSelf))) //ポーズ画面を閉じるときだけ、BACKキーでも操作できる
        {
            //Uiとボタンたちを起こす
            ExitUI.SetActive(!ExitUI.activeSelf);
            Yes.SetActive(!Yes.activeSelf);
            No.SetActive(!No.activeSelf);
            Panel.SetActive(!Panel.activeSelf);

            //上の関数に渡す
            ButtonFlg = true;
        }
    }
}
