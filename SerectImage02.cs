using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerectImage02 : MonoBehaviour
{
    //選択した時の画像切り替え
    [SerializeField] private SpriteRenderer StageIcon;
    public Sprite StageIcon_a;//選択した時の画像
    public Sprite StageIcon_b;//選択する前の画像

    // Start is called before the first frame update
    void Start()
    {
        StageIcon = GetComponent<SpriteRenderer>();
    }

    //重なった時
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "PlayerIcon")
        {
            StageIcon.sprite = StageIcon_a;
        }
    }

    //出た時
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "PlayerIcon")
        {
            StageIcon.sprite = StageIcon_b;
        }
    }
}
