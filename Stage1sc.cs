using UnityEngine;

public class Stage1sc : MonoBehaviour
{
    [SerializeField] GameObject NormalBlock;    //普通のブロック
    [SerializeField] GameObject TrapBlock;      //トラップブロック
    [SerializeField] GameObject TriggerBlock;   //トリガーブロック
    [SerializeField] GameObject UnBreakUnLook;  //破壊不可不可視ブロック
    [SerializeField] GameObject Ground;         //床
    [SerializeField] GameObject SpawnPoint;     //マップ生成時のスポーンポイント
    [SerializeField] GameObject UnBreak;        //破壊不可可視ブロック
    [SerializeField] GameObject BlockWalker;

    void Start()
    {
        //0 = 何もなし　1 = 普通のブロック　2 = トラップブロック　
        //3 = トリガーブロック　4 = 破壊不可透明ブロック　5 = 床
        //6 = スポーン地点　7 = 破壊不可可視ブロック  9X = 鍵付き
        //8 = 歩行君

        //地面1(破壊不可)
        int[][] Map1_0 =
{
            new int[] { 4, 4, 4, 4, 4, 4, 4},
            new int[] { 4, 4, 4, 4, 4, 4, 4},
            new int[] { 4, 4, 4, 4, 4, 4, 4},
            new int[] { 4, 4, 4, 4, 4, 4, 4},
            new int[] { 4, 4, 4, 4, 4, 4, 4},
            new int[] { 4, 4, 4, 4, 4, 4, 4},
            new int[] { 4, 4, 4, 4, 4, 4, 4}
        };
        //地面2(破壊不可)
        int[][] Map1_1 =
        {
            new int[] { 4, 4, 4, 4, 4, 4, 4},
            new int[] { 4, 4, 4, 4, 4, 4, 4},
            new int[] { 4, 4, 4, 4, 4, 4, 4},
            new int[] { 4, 4, 4, 4, 4, 4, 4},
            new int[] { 4, 4, 4, 4, 4, 4, 4},
            new int[] { 4, 4, 4, 4, 4, 4, 4},
            new int[] { 4, 4, 4, 4, 4, 4, 4}
        };
        //一層目
        int[][] Map1_2 =
        {
            new int[] { 4, 4, 4, 4, 4, 4, 4},
            new int[] { 4 ,7, 7, 7, 7, 7, 4},
            new int[] { 4, 7, 7, 7, 7, 7, 4},
            new int[] { 4, 7, 7, 7, 7, 7, 4},
            new int[] { 4, 7, 7, 7, 7, 7, 4},
            new int[] { 4, 7, 7, 7, 7, 7, 4},
            new int[] { 4, 4, 4, 4, 4, 4, 4}

        };
        //二層目
        int[][] Map1_3 =
        {
            new int[] { 4, 4, 4, 4, 4, 4, 4},
            new int[] { 4 ,1, 1, 1, 1, 1, 4},
            new int[] { 4, 1, 1, 1, 1, 1, 4},
            new int[] { 4, 1, 1, 1, 1, 1, 4},
            new int[] { 4, 1, 1, 1, 1, 1, 4},
            new int[] { 4, 1, 1, 1, 1, 1, 4},
            new int[] { 4, 4, 4, 4, 4, 4, 4}
        };
        //三層目
        int[][] Map1_4 =
        {
            new int[] { 4, 4, 4, 4, 4, 4, 4},
            new int[] { 4 ,0, 1, 1, 1, 0, 4},
            new int[] { 4 ,0, 1, 1, 1, 0, 4},
            new int[] { 4 ,0, 7, 7, 7, 0, 4},
            new int[] { 4 ,0, 0, 0, 0, 0, 4},
            new int[] { 4 ,0, 0, 0, 0, 0, 4},
            new int[] { 4, 4, 4, 4, 4, 4, 4}
        };
        //四層目
        int[][] Map1_5 =
        {
            new int[] { 4, 4, 4, 4, 4, 4, 4},
            new int[] { 4 ,0, 1, 1, 1, 0, 4},
            new int[] { 4 ,0, 1, 1, 1, 0, 4},
            new int[] { 4 ,0, 7, 7, 7, 0, 4},
            new int[] { 4 ,0, 0, 0, 0, 0, 4},
            new int[] { 4 ,0, 0, 0, 0, 0, 4},
            new int[] { 4, 4, 4, 4, 4, 4, 4}
        };
        //五層目
        int[][] Map1_6 =
        {
            new int[] { 4, 4, 4, 4, 4, 4, 4},
            new int[] { 4, 0, 0, 0, 0, 0, 4},
            new int[] { 4, 0, 0, 3, 0, 0, 4},
            new int[] { 4, 0, 0, 0, 0, 0, 4},
            new int[] { 4, 0, 0, 0, 0, 0, 4},
            new int[] { 4, 0, 0, 0, 0, 0, 4},
            new int[] { 4, 4, 4, 4, 4, 4, 4}
        };
        //六層目
        int[][] Map1_7 =
        {
            new int[] { 4, 4, 4, 4, 4, 4, 4},
            new int[] { 4, 0, 0, 0, 0, 0, 4},
            new int[] { 4, 0, 0, 0, 0, 0, 4},
            new int[] { 4, 0, 0, 0, 0, 0, 4},
            new int[] { 4, 0, 0, 0, 0, 0, 4},
            new int[] { 4, 0, 0, 0, 0, 0, 4},
            new int[] { 4, 4, 4, 4, 4, 4, 4}
        };
        //七層目
        int[][] Map1_8 =
        {
            new int[] { 4, 4, 4, 4, 4, 4, 4},
            new int[] { 4, 0, 0, 0, 0, 0, 4},
            new int[] { 4, 0, 0, 0, 0, 0, 4},
            new int[] { 4, 0, 0, 0, 0, 0, 4},
            new int[] { 4, 0, 0, 0, 0, 0, 4},
            new int[] { 4, 0, 0, 0, 0, 0, 4},
            new int[] { 4, 4, 4, 4, 4, 4, 4}
        };
        //八層目
        int[][] Map1_9 =
        {
            new int[] { 4, 4, 4, 4, 4, 4, 4},
            new int[] { 4, 0, 0, 0, 0, 0, 4},
            new int[] { 4, 0, 0, 0, 0, 0, 4},
            new int[] { 4, 0, 0, 0, 0, 0, 4},
            new int[] { 4, 0, 0, 0, 0, 0, 4},
            new int[] { 4, 0, 0, 0, 0, 0, 4},
            new int[] { 4, 4, 4, 4, 4, 4, 4}
        };
        //九層目
        int[][] Map1_10 =
        {
            new int[] { 4, 4, 4, 4, 4, 4, 4},
            new int[] { 4, 0, 0, 0, 0, 0, 4},
            new int[] { 4, 0, 0, 0, 0, 0, 4},
            new int[] { 4, 0, 0, 0, 0, 0, 4},
            new int[] { 4, 0, 0, 0, 0, 0, 4},
            new int[] { 4, 0, 0, 0, 0, 0, 4},
            new int[] { 4, 4, 4, 4, 4, 4, 4}
        };
        //十層目
        int[][] Map1_11 =
        {
            new int[] { 4, 4, 4, 4, 4, 4, 4},
            new int[] { 4, 0, 0, 0, 0, 0, 4},
            new int[] { 4, 0, 0, 0, 0, 0, 4},
            new int[] { 4, 0, 0, 0, 0, 0, 4},
            new int[] { 4, 0, 0, 0, 0, 0, 4},
            new int[] { 4, 0, 0, 0, 0, 0, 4},
            new int[] { 4, 4, 4, 4, 4, 4, 4}
        };

        // ステージ作成
        FieldMake(Map1_0, 0);
        FieldMake(Map1_1, 1);
        FieldMake(Map1_2, 2);
        FieldMake(Map1_3, 3);
        FieldMake(Map1_4, 4);
        FieldMake(Map1_5, 5);
        FieldMake(Map1_6, 6);
        FieldMake(Map1_7, 7);
        FieldMake(Map1_8, 8);
        FieldMake(Map1_9, 9);
        FieldMake(Map1_10, 10);
        FieldMake(Map1_11, 11);
    }

    void FieldMake(int[][] Map,int y)
    {
        for (int i = 0; i < Map.Length; i++)
        {
            for (int j = 0; j < Map[i].Length; j++)
            {
                if (Map[i][j] == 1)
                    Instantiate(NormalBlock, new Vector3(i, y + 0.5f, j), Quaternion.identity);
                if (Map[i][j] == 2)
                    Instantiate(TrapBlock, new Vector3(i, y + 0.5f, j), Quaternion.identity);
                if (Map[i][j] == 3)
                    Instantiate(TriggerBlock, new Vector3(i, y + 0.5f, j), Quaternion.identity);
                if (Map[i][j] == 4)
                    Instantiate(UnBreakUnLook, new Vector3(i, y + 0.5f, j), Quaternion.identity);
                if (Map[i][j] == 5)
                    Instantiate(Ground, new Vector3(i, y + 0.5f, j), Quaternion.identity);
                if (Map[i][j] == 6)
                    Instantiate(SpawnPoint, new Vector3(i, y + 0.5f, j), Quaternion.identity);
                if (Map[i][j] == 7)
                    Instantiate(UnBreak, new Vector3(i, y + 0.5f, j), Quaternion.identity);
                if (Map[i][j] == 8)
                    Instantiate(BlockWalker, new Vector3(i, y + 0.5f, j), Quaternion.identity);
            }
        }

    }
}