using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToStageSelect : MonoBehaviour
{
    //�����ƃZ���N�g��ʂɖ߂�
    public void OnClickButton()
    {
        //�K�v�Ȃ炱���Ŗ��O��ς��Ă�������
        SceneManager.LoadScene("SelectDE");
        Time.timeScale = 1f;
        Debug.Log("Go to StageSelect");
    }
}
