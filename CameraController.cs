using UnityEngine;

//�C���[�W�̓����n���̃J����
public class CameraController : MonoBehaviour
{
    public GameObject targetObj = null;//�ǂ�������Ώ�
    Vector3 targetPos;//�Ώۂ̍��W

    //�@�ώZ��]�p��ʓr�o���Ă�����悤�ɂ��Ă���
    float angleH;
    float angleV;

    void Start()
    {
        targetPos = targetObj.transform.position;
    }

    void Update()
    {
        // target�̈ړ��ʕ��A�J�������ړ�����
        transform.position += targetObj.transform.position - targetPos;
        targetPos = targetObj.transform.position;

        // �E�X�e�B�b�N�̈ړ���
        float KeyInputX = Input.GetAxis("PAD_CAMERA_HORIZONTAL");
        float KeyInputY = Input.GetAxis("PAD_CAMERA_VERTICAL");

        if (Input.GetKey(KeyCode.RightArrow)) //�L�[�{�[�h����p
        {
            KeyInputX = 1.0f;
        }
        if (Input.GetKey(KeyCode.LeftArrow)) //�L�[�{�[�h����p
        {
            KeyInputX = -1.0f;
        }
        if (Input.GetKey(KeyCode.UpArrow)) //�L�[�{�[�h����p
        {
            KeyInputY = -1.0f;
        }
        if (Input.GetKey(KeyCode.DownArrow)) //�L�[�{�[�h����p
        {
            KeyInputY = 1.0f;
        }

        // �}�E�X�ړ��ʂ��狁�߂������E������]�p
        float deltaAngleH = KeyInputX * Time.deltaTime * 100f;
        float deltaAngleV = -KeyInputY * Time.deltaTime * 100f; //�㉺�ړ��̂݃X�e�B�b�N�����o�[�X���Ă��邽��-1�������Ă��܂�

        // �p�x��ώZ����
        angleH += deltaAngleH;
        angleV += deltaAngleV;

        // �ώZ�p�x�𐧌�����
        //���]
        //float clampedAngleH = Mathf.Clamp(angleH, -180, 180);
        //����
        float clampedAngleV = Mathf.Clamp(angleV, -20, 50); //���������݂̂��������ɐ���

        // �N�����v�O�̐ώZ�p����N�����v��̐ώZ�p�������āA�ǂꂾ�������͈͂𒴂����������߂�
        // ���������͈͓��Ȃ獷��0�ɂȂ邪�A�}�C�i�X���ɉz����΃}�C�i�X�́A�v���X���Ȃ�v���X�̊p�x����������
        //float overshootH = angleH - clampedAngleH;
        float overshootV = angleV - clampedAngleV;

        // �p�x����������]�ʂ𒲐����āA�����𒴂��Ȃ��悤�ɂ��Ă��
        // �ώZ�p�x��������̒l�ɏ㏑������
        //deltaAngleH -= overshootH;
        deltaAngleV -= overshootV;
        //angleH = clampedAngleH;
        angleV = clampedAngleV;

        /*
        // target�̈ʒu��Y���𒆐S�ɁA��]�i���]�j����
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.RotateAround(targetPos, Vector3.up, -deltaAngleH);
        }

        // �J�����̐����ړ�
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.RotateAround(targetPos, transform.right, deltaAngleV);
        }
        */

        transform.RotateAround(targetPos, Vector3.up, -deltaAngleH); //���ۂ̃J�����ړ������Bif�̒��Ɋi�[���Ȃ��Ă��悳�����������̂ŏo�����B�Ƃ�����float�^��GetAxis�������ɓ��ꂽ��G���[���o��
        transform.RotateAround(targetPos, transform.right, deltaAngleV);
    }
}