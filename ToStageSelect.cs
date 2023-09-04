using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToStageSelect : MonoBehaviour
{
    //押すとセレクト画面に戻る
    public void OnClickButton()
    {
        //必要ならここで名前を変えてください
        SceneManager.LoadScene("SelectDE");
        Time.timeScale = 1f;
        Debug.Log("Go to StageSelect");
    }
}
