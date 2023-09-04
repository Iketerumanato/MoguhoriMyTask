using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollCam02 : MonoBehaviour
{
    // �A�C�R���̃Q�[���I�u�W�F�N�g
    public GameObject PlayerIcon;

    // �A�C�R���ƃJ�����̈ʒu�֌W��ێ�
    private Vector3 CamOffset;

    //�V���[�g�J�b�g�Ŏg�p
    [SerializeField] private GameObject[] StageIcon;

    // Start is called before the first frame update
    void Start()
    {
        // �Q�[���X�^�[�g���ł̃A�C�R���ƃJ�����̈ʒu�֌W���L��
        CamOffset = transform.position - PlayerIcon.transform.position;
    }

    void LateUpdate()
    {
        // �A�C�R���̌��݈ʒu����V�����J�����̈ʒu���쐬
        Vector3 vector = PlayerIcon.transform.position + CamOffset;
        // �c�����͌Œ�
        vector.y = transform.position.y;
        //�J�����̉��ړ��̐���
        vector.x = Mathf.Clamp(vector.x, 0f, 3850f);
        // �J�����̈ʒu���ړ�
        transform.position = vector;

        //�V���[�g�J�b�g
        //�X�e�[�W1�փV���[�g�J�b�g
        if (Input.GetKey(KeyCode.Alpha1))
        {
            PlayerIcon.transform.position = StageIcon[0].transform.position;
            Debug.Log("Push01");
        }

        //�X�e�[�W2�փV���[�g�J�b�g
        if (Input.GetKey(KeyCode.Alpha2))
        {
            PlayerIcon.transform.position = StageIcon[1].transform.position;
            Debug.Log("Push02");
        }

        //�X�e�[�W3�փV���[�g�J�b�g
        if (Input.GetKey(KeyCode.Alpha3))
        {
            PlayerIcon.transform.position = StageIcon[2].transform.position;
            Debug.Log("Push03");
        }

        //�X�e�[�W4�փV���[�g�J�b�g
        if (Input.GetKey(KeyCode.Alpha4))
        {
            PlayerIcon.transform.position = StageIcon[3].transform.position;
            Debug.Log("Push04");
        }

        //�X�e�[�W5�փV���[�g�J�b�g
        if (Input.GetKey(KeyCode.Alpha5))
        {
            PlayerIcon.transform.position = StageIcon[4].transform.position;
            Debug.Log("Push05");
        }

        //�X�e�[�W6�փV���[�g�J�b�g
        if (Input.GetKey(KeyCode.Alpha6))
        {
            PlayerIcon.transform.position = StageIcon[5].transform.position;
            Debug.Log("Push06");
        }

        //�X�e�[�W7�փV���[�g�J�b�g
        if (Input.GetKey(KeyCode.Alpha7))
        {
            PlayerIcon.transform.position = StageIcon[6].transform.position;
            Debug.Log("Push07");
        }

        //�X�e�[�W8�փV���[�g�J�b�g
        if (Input.GetKey(KeyCode.Alpha8))
        {
            PlayerIcon.transform.position = StageIcon[7].transform.position;
            Debug.Log("Push08");
        }

        //�X�e�[�W9�փV���[�g�J�b�g
        if (Input.GetKey(KeyCode.Alpha9))
        {
            PlayerIcon.transform.position = StageIcon[8].transform.position;
            Debug.Log("Push09");
        }

        //�X�e�[�W10�փV���[�g�J�b�g
        if (Input.GetKey(KeyCode.Alpha0))
        {
            PlayerIcon.transform.position = StageIcon[9].transform.position;
            Debug.Log("Push00");
        }
    }
}
