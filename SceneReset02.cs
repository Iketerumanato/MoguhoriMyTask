using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReset02 : MonoBehaviour
{
    //�����Ƃ��̃X�e�[�W�����g���C�ł���
    public void Retry()
    {
        Scene loadScene = SceneManager.GetActiveScene();
        SceneManager.LoadSceneAsync(loadScene.name);

        Time.timeScale = 1f;
        Debug.Log("Reset");
    }
}