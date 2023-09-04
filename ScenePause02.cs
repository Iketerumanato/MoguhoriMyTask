using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenePause02 : MonoBehaviour
{
    [SerializeField] private GameObject PauseUI;//�|�[�Y�̉摜
    [SerializeField] private GameObject ResetButton;//���Z�b�g�{�^���̃I�u�W�F�N�g
    [SerializeField] private GameObject ToSelectButton;//�Z���N�g�V�[���֔�ԃ{�^���̃I�u�W�F�N�g
    [SerializeField] private GameObject Panel;//�|�[�Y�������̔w�i�������Ȃ�
    [SerializeField] Button[] button;//0->Retry,1->SelectScene

    //�I����̏����̂���
    private bool ButtonFlg;

    //PAD����p
    float D_Pad_Vertical;

    void Start()
    {
        //�R���|�[�l���g�̎擾
        button[0] = ResetButton.GetComponent<Button>();
        button[1] = ToSelectButton.GetComponent<Button>();
        //�{�^�����I�����ꂽ��ԂɂȂ�
        ButtonFlg = false;
    }

    // Update is called once per frame
    void Update()
    {
        //�֐��Ăяo��
        Pause();
        Controll();
    }

    void Controll()
    {
        //�\���L�[�܂���G,B�L�[�ő���AA�{�^���܂��̓X�y�[�X�L�[�Ō���
        if (ButtonFlg == true)
        {
            float D_Pad_Vertical = Input.GetAxis("D_PAD_VERTICAL");

            if (Input.GetKeyDown(KeyCode.G)) //�f�o�b�O�p����
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

    //�|�[�Y�̋@�\
    void Pause()
    {
        //PAUSE�L�[�Ń|�[�Y
        if (Input.GetButtonDown("PAUSE") || ((Input.GetButtonDown("BACK")) && (PauseUI.activeSelf))) //�|�[�Y��ʂ����Ƃ������ABACK�L�[�ł�����ł���
        {
            //Ui�ƃ{�^���������N����
            PauseUI.SetActive(!PauseUI.activeSelf);
            ResetButton.SetActive(!ResetButton.activeSelf);
            ToSelectButton.SetActive(!ToSelectButton.activeSelf);
            Panel.SetActive(!Panel.activeSelf);

            //��̊֐��ɓn��
            ButtonFlg = true;

            //�����ƈꎞ��~
            if (PauseUI.activeSelf)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f; //�|�[�Y��ʂ�����Ƃ��ɍĂу^�C���X�P�[�����P�ɖ߂���悤�ύX���܂���
            }
        }
    }
}
