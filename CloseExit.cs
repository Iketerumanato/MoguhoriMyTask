using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseExit : MonoBehaviour
{
    [SerializeField] private GameObject ExitUI;//�|�[�Y�̉摜
    [SerializeField] private GameObject Yes;//���Z�b�g�{�^���̃I�u�W�F�N�g
    [SerializeField] private GameObject No;//�Z���N�g�V�[���֔�ԃ{�^���̃I�u�W�F�N�g
    [SerializeField] private GameObject Panel;//�|�[�Y�������̔w�i�������Ȃ�

    //�����Ƃ��̃X�e�[�W�����g���C�ł���
    public void Close()
    {
        ExitUI.SetActive(!ExitUI.activeSelf);
        Yes.SetActive(!Yes.activeSelf);
        No.SetActive(!No.activeSelf);
        Panel.SetActive(!Panel.activeSelf);
    }
}