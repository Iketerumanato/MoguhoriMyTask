using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenePause02 : MonoBehaviour
{
    [SerializeField] private GameObject PauseUI;//ポーズの画像
    [SerializeField] private GameObject ResetButton;//リセットボタンのオブジェクト
    [SerializeField] private GameObject ToSelectButton;//セレクトシーンへ飛ぶボタンのオブジェクト
    [SerializeField] private GameObject Panel;//ポーズした時の背景が白くなる
    [SerializeField] Button[] button;//0->Retry,1->SelectScene

    //選択後の処理のため
    private bool ButtonFlg;

    //PAD操作用
    float D_Pad_Vertical;

    void Start()
    {
        //コンポーネントの取得
        button[0] = ResetButton.GetComponent<Button>();
        button[1] = ToSelectButton.GetComponent<Button>();
        //ボタンが選択された状態になる
        ButtonFlg = false;
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
        if (Input.GetButtonDown("PAUSE") || ((Input.GetButtonDown("BACK")) && (PauseUI.activeSelf))) //ポーズ画面を閉じるときだけ、BACKキーでも操作できる
        {
            //Uiとボタンたちを起こす
            PauseUI.SetActive(!PauseUI.activeSelf);
            ResetButton.SetActive(!ResetButton.activeSelf);
            ToSelectButton.SetActive(!ToSelectButton.activeSelf);
            Panel.SetActive(!Panel.activeSelf);

            //上の関数に渡す
            ButtonFlg = true;

            //押すと一時停止
            if (PauseUI.activeSelf)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f; //ポーズ画面を閉じたときに再びタイムスケールを１に戻せるよう変更しました
            }
        }
    }
}
