using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollCam02 : MonoBehaviour
{
    // アイコンのゲームオブジェクト
    public GameObject PlayerIcon;

    // アイコンとカメラの位置関係を保持
    private Vector3 CamOffset;

    //ショートカットで使用
    [SerializeField] private GameObject[] StageIcon;

    // Start is called before the first frame update
    void Start()
    {
        // ゲームスタート時でのアイコンとカメラの位置関係を記憶
        CamOffset = transform.position - PlayerIcon.transform.position;
    }

    void LateUpdate()
    {
        // アイコンの現在位置から新しいカメラの位置を作成
        Vector3 vector = PlayerIcon.transform.position + CamOffset;
        // 縦方向は固定
        vector.y = transform.position.y;
        //カメラの横移動の制限
        vector.x = Mathf.Clamp(vector.x, 0f, 3850f);
        // カメラの位置を移動
        transform.position = vector;

        //ショートカット
        //ステージ1へショートカット
        if (Input.GetKey(KeyCode.Alpha1))
        {
            PlayerIcon.transform.position = StageIcon[0].transform.position;
            Debug.Log("Push01");
        }

        //ステージ2へショートカット
        if (Input.GetKey(KeyCode.Alpha2))
        {
            PlayerIcon.transform.position = StageIcon[1].transform.position;
            Debug.Log("Push02");
        }

        //ステージ3へショートカット
        if (Input.GetKey(KeyCode.Alpha3))
        {
            PlayerIcon.transform.position = StageIcon[2].transform.position;
            Debug.Log("Push03");
        }

        //ステージ4へショートカット
        if (Input.GetKey(KeyCode.Alpha4))
        {
            PlayerIcon.transform.position = StageIcon[3].transform.position;
            Debug.Log("Push04");
        }

        //ステージ5へショートカット
        if (Input.GetKey(KeyCode.Alpha5))
        {
            PlayerIcon.transform.position = StageIcon[4].transform.position;
            Debug.Log("Push05");
        }

        //ステージ6へショートカット
        if (Input.GetKey(KeyCode.Alpha6))
        {
            PlayerIcon.transform.position = StageIcon[5].transform.position;
            Debug.Log("Push06");
        }

        //ステージ7へショートカット
        if (Input.GetKey(KeyCode.Alpha7))
        {
            PlayerIcon.transform.position = StageIcon[6].transform.position;
            Debug.Log("Push07");
        }

        //ステージ8へショートカット
        if (Input.GetKey(KeyCode.Alpha8))
        {
            PlayerIcon.transform.position = StageIcon[7].transform.position;
            Debug.Log("Push08");
        }

        //ステージ9へショートカット
        if (Input.GetKey(KeyCode.Alpha9))
        {
            PlayerIcon.transform.position = StageIcon[8].transform.position;
            Debug.Log("Push09");
        }

        //ステージ10へショートカット
        if (Input.GetKey(KeyCode.Alpha0))
        {
            PlayerIcon.transform.position = StageIcon[9].transform.position;
            Debug.Log("Push00");
        }
    }
}
