using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerectImage02 : MonoBehaviour
{
    //�I���������̉摜�؂�ւ�
    [SerializeField] private SpriteRenderer StageIcon;
    public Sprite StageIcon_a;//�I���������̉摜
    public Sprite StageIcon_b;//�I������O�̉摜

    // Start is called before the first frame update
    void Start()
    {
        StageIcon = GetComponent<SpriteRenderer>();
    }

    //�d�Ȃ�����
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "PlayerIcon")
        {
            StageIcon.sprite = StageIcon_a;
        }
    }

    //�o����
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "PlayerIcon")
        {
            StageIcon.sprite = StageIcon_b;
        }
    }
}
