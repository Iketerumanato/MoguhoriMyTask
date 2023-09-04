using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage02 : MonoBehaviour
{
    //�X�e�[�W�̃C���[�W��ʂ̕\��
    [SerializeField] private Image StageImage;
    [SerializeField] private Sprite[] StageSp;

    //���񂾃X�e�[�W�A�C�R���̃^�O�ɂ���ĉ摜��ς��A
    private GameObject PlayerIc;
    private IconMove02 iconmove;

    //�A�j���[�V�����̍Đ�������
    Animator ImageAnime;

    // Start is called before the first frame update
    void Start()
    {
        StageImage = GameObject.Find("StageImage").GetComponent<Image>();
        StageImage.enabled = true;
        ImageAnime = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //�֐��Ăяo��
        ImageChange();
    }

    //�C���[�W�摜�̐؂�ւ��A�A�j���[�V�����̍Đ�
    void ImageChange()
    {
        PlayerIc = GameObject.Find("PlayerIcon");
        iconmove = PlayerIc.GetComponent<IconMove02>();

        //�X�e�[�W1
        if (iconmove.selectedStageImage == 1)
        {
            StageImage.sprite = StageSp[0];
            ImageAnime.SetFloat("Speed", 1);
            ImageAnime.SetBool("Imbl", true);
        }

        //�X�e�[�W2
        if (iconmove.selectedStageImage == 2)
        {
            StageImage.sprite = StageSp[1];
            ImageAnime.SetFloat("Speed", 1);
            ImageAnime.SetBool("Imbl", true);
        }

        //�X�e�[�W3
        if (iconmove.selectedStageImage == 3)
        {
            StageImage.sprite = StageSp[2];
            ImageAnime.SetFloat("Speed", 1);
            ImageAnime.SetBool("Imbl", true);
        }

        //�X�e�[�W4
        if (iconmove.selectedStageImage == 4)
        {
            StageImage.sprite = StageSp[3];
            ImageAnime.SetFloat("Speed", 1);
            ImageAnime.SetBool("Imbl", true);
        }

        //�X�e�[�W5
        if (iconmove.selectedStageImage == 5)
        {
            StageImage.sprite = StageSp[4];
            ImageAnime.SetFloat("Speed", 1);
            ImageAnime.SetBool("Imbl", true);
        }

        //�X�e�[�W6
        if (iconmove.selectedStageImage == 6)
        {
            StageImage.sprite = StageSp[5];
            ImageAnime.SetFloat("Speed", 1);
            ImageAnime.SetBool("Imbl", true);
        }

        //�X�e�[�W7
        if (iconmove.selectedStageImage == 7)
        {
            StageImage.sprite = StageSp[6];
            ImageAnime.SetFloat("Speed", 1);
            ImageAnime.SetBool("Imbl", true);
        }

        //�X�e�[�W8
        if (iconmove.selectedStageImage == 8)
        {
            StageImage.sprite = StageSp[7];
            ImageAnime.SetFloat("Speed", 1);
            ImageAnime.SetBool("Imbl", true);
            
        }

        //�X�e�[�W9
        if (iconmove.selectedStageImage == 9)
        {
            StageImage.sprite = StageSp[8];
            ImageAnime.SetFloat("Speed", 1);
            ImageAnime.SetBool("Imbl", true);
        }

        //�X�e�[�W10
        if (iconmove.selectedStageImage == 10)
        {
            StageImage.sprite = StageSp[9];
            ImageAnime.SetFloat("Speed", 1);
            ImageAnime.SetBool("Imbl", true);
        }

        //�A�j���[�V�����̍ēx�Đ��̂���
        if (iconmove.selectedStageImage == 0)
        {
            //ImageAnime.SetBool("Imbl", false);
            ImageAnime.SetFloat("Speed", -1);
        }
    }
}
