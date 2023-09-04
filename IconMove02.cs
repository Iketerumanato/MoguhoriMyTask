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
    [SerializeField] private GameObject ExitUI;//�|�[�Y�̉摜
    private bool lastFrameIsPause;

    //�A�C�R���̃X�s�[�h
    [SerializeField] private float speed_Ic;

    //�㉺�̈ړ�����
    [SerializeField] private float maxY;
    [SerializeField] private float minY;

    //���E�̈ړ�����
    [SerializeField] private float maxX;
    [SerializeField] private float minX;

    //�������ϖh�~
    //private bool PushFlg = false;

    //�X�e�[�W�̔ԍ��Ǘ�
    //public int StageNum;

    //�X�e�[�W�̃C���[�W�摜�̐؂�ւ��̂���
    [SerializeField] private GameObject StageImageObj;

    //�I����������SE��炷
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

        if (Input.GetKey(KeyCode.D)) //�L�[�{�[�h����p
        {
            Pad_Horizontal = 1.0f;
        }
        if (Input.GetKey(KeyCode.A)) //�L�[�{�[�h����p
        {
            Pad_Horizontal = -1.0f;
        }
        if (Input.GetKey(KeyCode.W)) //�L�[�{�[�h����p
        {
            Pad_Vertical = -1.0f;
        }
        if (Input.GetKey(KeyCode.S)) //�L�[�{�[�h����p
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

            fadeIn.isFading = true; //�t�F�[�h�J�n
            fadeIn.isIn = false; //�t�F�[�h�A�E�g���s��
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
            if (D_Pad_Horizontal == -1) //����
            {
                if (D_Pad_selected != 0)
                {
                    D_Pad_selected--;
                }
                InvokeShortcut = true;
                isDoneInLastFrame = true;
            }

            else if (D_Pad_Horizontal == 1) //�E��
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

    //�A�C�R���̈ړ�
    void Move(float Pad_Horizontal, float Pad_Vertical)
    {
        //�A�C�R���̍��W
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

        //�㉺�̈ړ�����
        Iconpos.y = Mathf.Clamp(Iconpos.y, minY, maxY);

        //���E�̈ړ�����
        Iconpos.x = Mathf.Clamp(Iconpos.x, minX, maxX);

        //���݂̍��W�̕ۑ�
        transform.position = Iconpos;

        //�R���\�[���ł̕\��
        //Debug.Log(Iconpos.y);
    }

    //�A�C�R�����X�e�[�W�A�C�R���ɐG�ꂽ�u�Ԃ̏���(ChangeImage�ɓn��)
    void OnTriggerEnter2D(Collider2D other)
    {
        //�V�[���̈ړ�
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

    //�����ŃV�[���ړ�
    void OnTriggerStay2D(Collider2D other)
    {
        //1
        if (other.gameObject.CompareTag("Stage01"))
        {
            if ((Input.GetButtonDown("DECISION")) && (!lastFrameIsPause))
            {
                //if (PushFlg == false)
                //{
                //    PushFlg = true;
                //    //SceneManager.LoadSceneAsync("");
                //    audioSource.PlayOneShot(selectSE);
                //    Debug.Log("�X�e�[�W�P�ֈړ�");
                //}
                audioSource.PlayOneShot(selectSE);

                selectedStage = 1;
                Debug.Log(selectedStage);
                fadeIn.isFading = true; //�t�F�[�h�J�n
                fadeIn.isIn = false; //�t�F�[�h�A�E�g���s��

                
                //SceneManager.LoadSceneAsync("");
                Debug.Log("�X�e�[�W�P�ֈړ�");
            }
        }

        //2
        if (other.gameObject.CompareTag("Stage02"))
        {
            if ((Input.GetButtonDown("DECISION")) && (!lastFrameIsPause))
            {
                //if (PushFlg == false)
                //{
                //    PushFlg = true;
                //    audioSource.PlayOneShot(selectSE);
                //    //SceneManager.LoadSceneAsync("");
                //    Debug.Log("�X�e�[�W�Q�ֈړ�");
                //}

                selectedStage = 2;
                Debug.Log(selectedStage);
                fadeIn.isFading = true; //�t�F�[�h�J�n
                fadeIn.isIn = false; //�t�F�[�h�A�E�g���s��

                audioSource.PlayOneShot(selectSE);
                //SceneManager.LoadSceneAsync("");
                Debug.Log("�X�e�[�W�Q�ֈړ�");
            }
        }

        //3
        if (other.gameObject.CompareTag("Stage03"))
        {
            if ((Input.GetButtonDown("DECISION")) && (!lastFrameIsPause))
            {
                //if (PushFlg == false)
                //{
                //    PushFlg = true;
                //    audioSource.PlayOneShot(selectSE);
                //    //SceneManager.LoadSceneAsync("");
                //    Debug.Log("�X�e�[�W�R�ֈړ�");
                //}

                selectedStage = 3;
                Debug.Log(selectedStage);
                fadeIn.isFading = true; //�t�F�[�h�J�n
                fadeIn.isIn = false; //�t�F�[�h�A�E�g���s��

                audioSource.PlayOneShot(selectSE);
                //SceneManager.LoadSceneAsync("");
                Debug.Log("�X�e�[�W�R�ֈړ�");
            }
        }

        //4
        if (other.gameObject.CompareTag("Stage04"))
        {
            if ((Input.GetButtonDown("DECISION")) && (!lastFrameIsPause))
            {
                //if (PushFlg == false)
                //{
                //    PushFlg = true;
                //    audioSource.PlayOneShot(selectSE);
                //    //SceneManager.LoadSceneAsync("");
                //    Debug.Log("�X�e�[�W�S�ֈړ�");
                //}

                selectedStage = 4;
                Debug.Log(selectedStage);
                fadeIn.isFading = true; //�t�F�[�h�J�n
                fadeIn.isIn = false; //�t�F�[�h�A�E�g���s��

                audioSource.PlayOneShot(selectSE);
                //SceneManager.LoadSceneAsync("");
                Debug.Log("�X�e�[�W�S�ֈړ�");
            }
        }

        /*
        //5
        if (other.gameObject.CompareTag("Stage05"))
        {
            if ((Input.GetButtonDown("DECISION")) && (!lastFrameIsPause))
            {
                //if (PushFlg == false)
                //{
                //    PushFlg = true;
                //    audioSource.PlayOneShot(selectSE);
                //    //SceneManager.LoadSceneAsync("");
                //    Debug.Log("�X�e�[�W�S�ֈړ�");
                //}

                selectedStage = 5;
                Debug.Log(selectedStage);
                fadeIn.isFading = true; //�t�F�[�h�J�n
                fadeIn.isIn = false; //�t�F�[�h�A�E�g���s��

                audioSource.PlayOneShot(selectSE);
                //SceneManager.LoadSceneAsync("");
                Debug.Log("�X�e�[�W�T�ֈړ�");
            }
        }

        //6
        if (other.gameObject.CompareTag("Stage06"))
        {
            if ((Input.GetButtonDown("DECISION")) && (!lastFrameIsPause))
            {
                //if (PushFlg == false)
                //{
                //    PushFlg = true;
                //    audioSource.PlayOneShot(selectSE);
                //    //SceneManager.LoadSceneAsync("");
                //    Debug.Log("�X�e�[�W�S�ֈړ�");
                //}

                selectedStage = 6;
                Debug.Log(selectedStage);
                fadeIn.isFading = true; //�t�F�[�h�J�n
                fadeIn.isIn = false; //�t�F�[�h�A�E�g���s��

                audioSource.PlayOneShot(selectSE);
                //SceneManager.LoadSceneAsync("");
                Debug.Log("�X�e�[�W�U�ֈړ�");
            }
        }

        //7
        if (other.gameObject.CompareTag("Stage07"))
        {
            if ((Input.GetButtonDown("DECISION")) && (!lastFrameIsPause))
            {
                //if (PushFlg == false)
                //{
                //    PushFlg = true;
                //    audioSource.PlayOneShot(selectSE);
                //    //SceneManager.LoadSceneAsync("");
                //    Debug.Log("�X�e�[�W�S�ֈړ�");
                //}

                selectedStage = 7;
                Debug.Log(selectedStage);
                fadeIn.isFading = true; //�t�F�[�h�J�n
                fadeIn.isIn = false; //�t�F�[�h�A�E�g���s��

                audioSource.PlayOneShot(selectSE);
                //SceneManager.LoadSceneAsync("");
                Debug.Log("�X�e�[�W�V�ֈړ�");
            }
        }

        //8
        if (other.gameObject.CompareTag("Stage08"))
        {
            if ((Input.GetButtonDown("DECISION")) && (!lastFrameIsPause))
            {
                //if (PushFlg == false)
                //{
                //    PushFlg = true;
                //    audioSource.PlayOneShot(selectSE);
                //    //SceneManager.LoadSceneAsync("");
                //    Debug.Log("�X�e�[�W�S�ֈړ�");
                //}

                selectedStage = 8;
                Debug.Log(selectedStage);
                fadeIn.isFading = true; //�t�F�[�h�J�n
                fadeIn.isIn = false; //�t�F�[�h�A�E�g���s��

                audioSource.PlayOneShot(selectSE);
                //SceneManager.LoadSceneAsync("");
                Debug.Log("�X�e�[�W�W�ֈړ�");
            }
        }

        //9
        if (other.gameObject.CompareTag("Stage09"))
        {
            if ((Input.GetButtonDown("DECISION")) && (!lastFrameIsPause))
            {
                //if (PushFlg == false)
                //{
                //    PushFlg = true;
                //    audioSource.PlayOneShot(selectSE);
                //    //SceneManager.LoadSceneAsync("");
                //    Debug.Log("�X�e�[�W�S�ֈړ�");
                //}

                selectedStage = 9;
                Debug.Log(selectedStage);
                fadeIn.isFading = true; //�t�F�[�h�J�n
                fadeIn.isIn = false; //�t�F�[�h�A�E�g���s��

                audioSource.PlayOneShot(selectSE);
                //SceneManager.LoadSceneAsync("");
                Debug.Log("�X�e�[�W�X�ֈړ�");
            }
        }

        //10
        if (other.gameObject.CompareTag("Stage10"))
        {
            ((Input.GetButtonDown("DECISION")) && (!lastFrameIsPause))
            {
                //if (PushFlg == false)
                //{
                //    PushFlg = true;
                //    audioSource.PlayOneShot(selectSE);
                //    //SceneManager.LoadSceneAsync("");
                //    Debug.Log("�X�e�[�W�S�ֈړ�");
                //}

                selectedStage = 10;
                Debug.Log(selectedStage);
                fadeIn.isFading = true; //�t�F�[�h�J�n
                fadeIn.isIn = false; //�t�F�[�h�A�E�g���s��

                audioSource.PlayOneShot(selectSE);
                //SceneManager.LoadSceneAsync("");
                Debug.Log("�X�e�[�W�P�O�ֈړ�");
            }
        }
        */
    }

    //�A�C�R�����X�e�[�W�A�C�R�����痣�ꂽ��
    void OnTriggerExit2D(Collider2D other)
    {
        selectedStage = 0;
        selectedStageImage = 0;
        Debug.Log("�o��");
    }

    void LoadTitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
