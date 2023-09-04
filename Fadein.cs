using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{

    [SerializeField] float fadeSpeed = 0.01f;        //�����x���ς��X�s�[�h���Ǘ�
    float red, green, blue, alfa;   //�p�l���̐F�A�s�����x���Ǘ�

    public bool isFading = true;   //�t�F�[�h�C�������̊J�n�A�������Ǘ�����t���O

    public bool isIn = true; //���̓t�F�[�h�A�E�g��Ԃ�

    Image fadeImage;

    // Start is called before the first frame update
    void Start()
    {
        fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFading)
        {
            if (isIn)
            {
                StartFadeIn();
            }
            else
            {
                StartFadeOut();
            }
        }
    }

    void StartFadeIn()
    {

        alfa -= fadeSpeed;                //a)�s�����x�����X�ɉ�����
        SetAlpha();                      //b)�ύX�����s�����x�p�l���ɔ��f����
        if (alfa <= 0)
        {
            isFading = false;
        }
    }
    
    void StartFadeOut()
    {

        alfa += fadeSpeed * 2;           //a)�s�����x�����X�ɏグ��
        SetAlpha();                      //b)�ύX�����s�����x�p�l���ɔ��f����
        if (alfa >= 1)
        {
            isFading = false;
        }
    }

    void SetAlpha()
    {
        fadeImage.color = new Color(red, green, blue, alfa);
    }
}
