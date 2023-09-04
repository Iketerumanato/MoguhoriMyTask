using UnityEngine;

public class Stage1sc : MonoBehaviour
{
    [SerializeField] GameObject NormalBlock;    //���ʂ̃u���b�N
    [SerializeField] GameObject TrapBlock;      //�g���b�v�u���b�N
    [SerializeField] GameObject TriggerBlock;   //�g���K�[�u���b�N
    [SerializeField] GameObject UnBreakUnLook;  //�j��s�s���u���b�N
    [SerializeField] GameObject Ground;         //��
    [SerializeField] GameObject SpawnPoint;     //�}�b�v�������̃X�|�[���|�C���g
    [SerializeField] GameObject UnBreak;        //�j��s���u���b�N
    [SerializeField] GameObject BlockWalker;

    void Start()
    {
        //0 = �����Ȃ��@1 = ���ʂ̃u���b�N�@2 = �g���b�v�u���b�N�@
        //3 = �g���K�[�u���b�N�@4 = �j��s�����u���b�N�@5 = ��
        //6 = �X�|�[���n�_�@7 = �j��s���u���b�N  9X = ���t��
        //8 = ���s�N

        //�n��1(�j��s��)
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
        //�n��2(�j��s��)
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
        //��w��
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
        //��w��
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
        //�O�w��
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
        //�l�w��
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
        //�ܑw��
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
        //�Z�w��
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
        //���w��
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
        //���w��
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
        //��w��
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
        //�\�w��
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

        // �X�e�[�W�쐬
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