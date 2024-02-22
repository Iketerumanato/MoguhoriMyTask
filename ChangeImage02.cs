using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage02 : MonoBehaviour
{
    //ステージのイメージ画面の表示
    [SerializeField] private Image StageImage;
    [SerializeField] private Sprite[] StageSp;

    int StageNum[];
    StageNum = new int[11]{0,1,2,3,4,5,6,7,8,9,10};

    //踏んだステージアイコンのタグによって画像を変え、
    private GameObject PlayerIc;
    private IconMove02 iconmove;

    //アニメーションの再生させる
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
        //関数呼び出し
        ImageChange();
    }

    //イメージ画像の切り替え、アニメーションの再生
    void ImageChange()
    {
        PlayerIc = GameObject.Find("PlayerIcon");
        iconmove = PlayerIc.GetComponent<IconMove02>();

        //ステージ1
        if (iconmove.selectedStageImage == StageNum[0])
        {
            StageImage.sprite = StageSp[0];
            ImageAnime.SetFloat("Speed", 1);
            ImageAnime.SetBool("Imbl", true);
        }

        //ステージ2
        if (iconmove.selectedStageImage == 2)
        {
            StageImage.sprite = StageSp[1];
            ImageAnime.SetFloat("Speed", 1);
            ImageAnime.SetBool("Imbl", true);
        }

        //ステージ3
        if (iconmove.selectedStageImage == 3)
        {
            StageImage.sprite = StageSp[2];
            ImageAnime.SetFloat("Speed", 1);
            ImageAnime.SetBool("Imbl", true);
        }

        //ステージ4
        if (iconmove.selectedStageImage == 4)
        {
            StageImage.sprite = StageSp[3];
            ImageAnime.SetFloat("Speed", 1);
            ImageAnime.SetBool("Imbl", true);
        }

        //ステージ5
        if (iconmove.selectedStageImage == 5)
        {
            StageImage.sprite = StageSp[4];
            ImageAnime.SetFloat("Speed", 1);
            ImageAnime.SetBool("Imbl", true);
        }

        //ステージ6
        if (iconmove.selectedStageImage == 6)
        {
            StageImage.sprite = StageSp[5];
            ImageAnime.SetFloat("Speed", 1);
            ImageAnime.SetBool("Imbl", true);
        }

        //ステージ7
        if (iconmove.selectedStageImage == 7)
        {
            StageImage.sprite = StageSp[6];
            ImageAnime.SetFloat("Speed", 1);
            ImageAnime.SetBool("Imbl", true);
        }

        //ステージ8
        if (iconmove.selectedStageImage == 8)
        {
            StageImage.sprite = StageSp[7];
            ImageAnime.SetFloat("Speed", 1);
            ImageAnime.SetBool("Imbl", true);
            
        }

        //ステージ9
        if (iconmove.selectedStageImage == 9)
        {
            StageImage.sprite = StageSp[8];
            ImageAnime.SetFloat("Speed", 1);
            ImageAnime.SetBool("Imbl", true);
        }

        //ステージ10
        if (iconmove.selectedStageImage == 10)
        {
            StageImage.sprite = StageSp[9];
            ImageAnime.SetFloat("Speed", 1);
            ImageAnime.SetBool("Imbl", true);
        }

        //アニメーションの再度再生のため
        if (iconmove.selectedStageImage == 0)
        {
            //ImageAnime.SetBool("Imbl", false);
            ImageAnime.SetFloat("Speed", -1);
        }
    }
}
