using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IconMove02 : MonoBehaviour
{
    public FadeIn fadeIn;

    public int selectedStage;
    public int selectedStageImage;

    public int D_Pad_selected = 1;
    private float D_Pad_Horizontal;
    private bool isDoneInLastFrame = false;
    private int FrameCount = 0;
    public bool InvokeShortcut = false;

    float Pad_Horizontal;
    float Pad_Vertical;

    private bool backToTitle;
    [SerializeField] private GameObject ExitUI;//ポーズの画像
    private bool lastFrameIsPause;

    //アイコンのスピード
    [SerializeField] private float speed_Ic;

    //上下の移動制限
    [SerializeField] private float maxY;
    [SerializeField] private float minY;

    //左右の移動制限
    [SerializeField] private float maxX;
    [SerializeField] private float minX;

    //ステージのイメージ画像の切り替えのため
    [SerializeField] private GameObject StageImageObj;

    //選択した時のSEを鳴らす
    public AudioClip selectSE;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        selectedStage = 0;
        StageImageObj = GameObject.Find("StageImage");
        audioSource = GetComponent<AudioSource>();
        backToTitle = false;
    }

    // Update is called once per frame
    void Update()
    {
        Pad_Horizontal = Input.GetAxis("PAD_HORIZONTAL");
        Pad_Vertical = Input.GetAxis("PAD_VERTICAL");

        D_Pad_Horizontal = Input.GetAxis("D_PAD_HORIZONTAL");

        if (Input.GetKey(KeyCode.D)) //キーボード操作用
        {
            Pad_Horizontal = 1.0f;
        }
        if (Input.GetKey(KeyCode.A)) //キーボード操作用
        {
            Pad_Horizontal = -1.0f;
        }
        if (Input.GetKey(KeyCode.W)) //キーボード操作用
        {
            Pad_Vertical = -1.0f;
        }
        if (Input.GetKey(KeyCode.S)) //キーボード操作用
        {
            Pad_Vertical = 1.0f;
        }

        Move(Pad_Horizontal, Pad_Vertical);

        if ((selectedStage != 0) && (fadeIn.isFading == false))
        {
            switch (selectedStage)
            {
                case 1:
                    SceneManager.LoadSceneAsync("Stage1");
                    break;
                case 2:
                    SceneManager.LoadSceneAsync("Stage2");
                    break;
                case 3:
                    SceneManager.LoadSceneAsync("Stage3");
                    break;
                case 4:
                    SceneManager.LoadSceneAsync("Stage4");
                    break;
                case 5:
                    SceneManager.LoadSceneAsync("Stage5");
                    break;
                default:
                    break;
            }
        }

        if ((Input.GetButtonDown("BACK")) && (!lastFrameIsPause))
        {
            audioSource.PlayOneShot(selectSE);

            fadeIn.isFading = true; //フェード開始
            fadeIn.isIn = false; //フェードアウトを行う
            backToTitle = true;
        }

        if ((backToTitle == true) && (fadeIn.isFading == false))
        {
            Invoke("LoadTitleScene", 1);
        }

        if (ExitUI.activeSelf)
        {
            lastFrameIsPause = true;
        }
        else
        {
            lastFrameIsPause = false;
        }

        if (isDoneInLastFrame)
        {
            if (FrameCount < 10)
            {
                FrameCount++;
            }
            else
            {
                FrameCount = 0;
                isDoneInLastFrame = false;
            }
        }
        else
        {
            if (D_Pad_Horizontal == -1) //左へ
            {
                if (D_Pad_selected != 0)
                {
                    D_Pad_selected--;
                }
                InvokeShortcut = true;
                isDoneInLastFrame = true;
            }

            else if (D_Pad_Horizontal == 1) //右へ
            {
                if (D_Pad_selected != 10)
                {
                    D_Pad_selected++;
                }
                InvokeShortcut = true;
                isDoneInLastFrame = true;
            }
        }
    }

    //アイコンの移動
    void Move(float Pad_Horizontal, float Pad_Vertical)
    {
        //アイコンの座標
        Vector2 Iconpos = transform.position;

        if (Pad_Vertical > 0)
        {
            Iconpos.y -= speed_Ic;
        }
        
        if (Pad_Vertical < 0)
        {
            Iconpos.y += speed_Ic;
        }

        if (Pad_Horizontal < 0)
        {
            Iconpos.x -= speed_Ic;
        }

        if (Pad_Horizontal > 0)
        {
            Iconpos.x += speed_Ic;
        }

        //上下の移動制限
        Iconpos.y = Mathf.Clamp(Iconpos.y, minY, maxY);

        //左右の移動制限
        Iconpos.x = Mathf.Clamp(Iconpos.x, minX, maxX);

        //現在の座標の保存
        transform.position = Iconpos;

        //コンソールでの表示
        //Debug.Log(Iconpos.y);
    }

    //アイコンがステージアイコンに触れた瞬間の処理(ChangeImageに渡す)
    void OnTriggerEnter2D(Collider2D other)
    {
        //シーンの移動
        //1
        if (other.gameObject.CompareTag("Stage01"))
        {
            selectedStageImage = 1;
            D_Pad_selected = 1;
            Debug.Log(selectedStage);
        }

        //2
        if (other.gameObject.CompareTag("Stage02"))
        {
            selectedStageImage = 2;
            D_Pad_selected = 2;
            Debug.Log(selectedStage);
        }

        //2
        if (other.gameObject.CompareTag("Stage03"))
        {
            selectedStageImage = 3;
            D_Pad_selected = 3;
            Debug.Log(selectedStage);
        }

        //4
        if (other.gameObject.CompareTag("Stage04"))
        {
            selectedStageImage = 4;
            D_Pad_selected = 4;
            Debug.Log(selectedStage);
        }

        //5
        if (other.gameObject.CompareTag("Stage05"))
        {
            selectedStageImage = 5;
            D_Pad_selected = 5;
            Debug.Log(selectedStage);
        }

        //6
        if (other.gameObject.CompareTag("Stage06"))
        {
            selectedStageImage = 6;
            D_Pad_selected = 6;
            Debug.Log(selectedStage);
        }

        //7
        if (other.gameObject.CompareTag("Stage07"))
        {
            selectedStageImage = 7;
            D_Pad_selected = 7;
            Debug.Log(selectedStage);
        }

        //8
        if (other.gameObject.CompareTag("Stage08"))
        {
            selectedStageImage = 8;
            D_Pad_selected = 8;
            Debug.Log(selectedStage);
        }

        //9
        if (other.gameObject.CompareTag("Stage09"))
        {
            selectedStageImage = 9;
            D_Pad_selected = 9;
            Debug.Log(selectedStage);
        }

        //10
        if (other.gameObject.CompareTag("Stage10"))
        {
            selectedStageImage = 10;
            D_Pad_selected = 10;
            Debug.Log(selectedStage);
        }
    }

    //ここでシーン移動
    void OnTriggerStay2D(Collider2D other)
    {
        //1
        if (other.gameObject.CompareTag("Stage01"))
        {
            if ((Input.GetButtonDown("DECISION")) && (!lastFrameIsPause))
            {
                audioSource.PlayOneShot(selectSE);

                selectedStage = 1;
                Debug.Log(selectedStage);
                fadeIn.isFading = true; //フェード開始
                fadeIn.isIn = false; //フェードアウトを行う

                
                //SceneManager.LoadSceneAsync("");
                Debug.Log("ステージ１へ移動");
            }
        }

        //2
        if (other.gameObject.CompareTag("Stage02"))
        {
            if ((Input.GetButtonDown("DECISION")) && (!lastFrameIsPause))
            {
                selectedStage = 2;
                Debug.Log(selectedStage);
                fadeIn.isFading = true; //フェード開始
                fadeIn.isIn = false; //フェードアウトを行う

                audioSource.PlayOneShot(selectSE);
                //SceneManager.LoadSceneAsync("");
                Debug.Log("ステージ２へ移動");
            }
        }

        //3
        if (other.gameObject.CompareTag("Stage03"))
        {
            if ((Input.GetButtonDown("DECISION")) && (!lastFrameIsPause))
            {
                selectedStage = 3;
                Debug.Log(selectedStage);
                fadeIn.isFading = true; //フェード開始
                fadeIn.isIn = false; //フェードアウトを行う

                audioSource.PlayOneShot(selectSE);
                //SceneManager.LoadSceneAsync("");
                Debug.Log("ステージ３へ移動");
            }
        }

        //4
        if (other.gameObject.CompareTag("Stage04"))
        {
            if ((Input.GetButtonDown("DECISION")) && (!lastFrameIsPause))
            {
                selectedStage = 4;
                Debug.Log(selectedStage);
                fadeIn.isFading = true; //フェード開始
                fadeIn.isIn = false; //フェードアウトを行う

                audioSource.PlayOneShot(selectSE);
                //SceneManager.LoadSceneAsync("");
                Debug.Log("ステージ４へ移動");
            }
        }
    }

    //アイコンがステージアイコンから離れた時
    void OnTriggerExit2D(Collider2D other)
    {
        selectedStage = 0;
        selectedStageImage = 0;
        Debug.Log("出た");
    }

    void LoadTitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
