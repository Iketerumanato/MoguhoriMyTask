using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseExit : MonoBehaviour
{
    [SerializeField] private GameObject ExitUI;//ポーズの画像
    [SerializeField] private GameObject Yes;//リセットボタンのオブジェクト
    [SerializeField] private GameObject No;//セレクトシーンへ飛ぶボタンのオブジェクト
    [SerializeField] private GameObject Panel;//ポーズした時の背景が白くなる

    //押すとそのステージをリトライできる
    public void Close()
    {
        ExitUI.SetActive(!ExitUI.activeSelf);
        Yes.SetActive(!Yes.activeSelf);
        No.SetActive(!No.activeSelf);
        Panel.SetActive(!Panel.activeSelf);
    }
}