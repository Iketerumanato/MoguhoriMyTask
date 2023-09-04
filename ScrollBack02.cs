using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBack02 : MonoBehaviour
{
    [SerializeField] private float scrollSpeed; //�w�i���X�N���[��������X�s�[�h
    [SerializeField] private float startLine;//�w�i�̃X�N���[�����J�n����ʒu
    [SerializeField] private float deadLine; //�w�i�̃X�N���[�����I������ʒu
    public static ScrollBack02 scrollins;//�C���X�^���X�̐���

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Awake()
    {
        if (scrollins == null)
        {
            scrollins = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ScrollPlus();
    }

    //�X�N���[��
    public void ScrollPlus()
    {
        transform.Translate(scrollSpeed, 0, 0); //x������scrollSpeed��������

        if (transform.position.x < deadLine) //�����w�i��x���W���deadLine���傫���Ȃ�����
        {
            transform.position = new Vector3(startLine, 0, 0);//�w�i��startLine�܂Ŗ߂�
        }

        Debug.Log("�X�N���[���J�n");
    }
}
