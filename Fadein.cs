using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{

    [SerializeField] float fadeSpeed = 0.01f;        //透明度が変わるスピードを管理
    float red, green, blue, alfa;   //パネルの色、不透明度を管理

    public bool isFading = true;   //フェードイン処理の開始、完了を管理するフラグ

    public bool isIn = true; //今はフェードアウト状態か

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

        alfa -= fadeSpeed;                //a)不透明度を徐々に下げる
        SetAlpha();                      //b)変更した不透明度パネルに反映する
        if (alfa <= 0)
        {
            isFading = false;
        }
    }
    
    void StartFadeOut()
    {

        alfa += fadeSpeed * 2;           //a)不透明度を徐々に上げる
        SetAlpha();                      //b)変更した不透明度パネルに反映する
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
