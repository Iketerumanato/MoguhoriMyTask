using UnityEngine;

//イメージはモンハンのカメラ
public class CameraController : MonoBehaviour
{
    public GameObject targetObj = null;//追っかける対象
    Vector3 targetPos;//対象の座標

    //　積算回転角を別途覚えておけるようにしておく
    float angleH;
    float angleV;

    void Start()
    {
        targetPos = targetObj.transform.position;
    }

    void Update()
    {
        // targetの移動量分、カメラも移動する
        transform.position += targetObj.transform.position - targetPos;
        targetPos = targetObj.transform.position;

        // 右スティックの移動量
        float KeyInputX = Input.GetAxis("PAD_CAMERA_HORIZONTAL");
        float KeyInputY = Input.GetAxis("PAD_CAMERA_VERTICAL");

        if (Input.GetKey(KeyCode.RightArrow)) //キーボード操作用
        {
            KeyInputX = 1.0f;
        }
        if (Input.GetKey(KeyCode.LeftArrow)) //キーボード操作用
        {
            KeyInputX = -1.0f;
        }
        if (Input.GetKey(KeyCode.UpArrow)) //キーボード操作用
        {
            KeyInputY = -1.0f;
        }
        if (Input.GetKey(KeyCode.DownArrow)) //キーボード操作用
        {
            KeyInputY = 1.0f;
        }

        // マウス移動量から求めた水平・垂直回転角
        float deltaAngleH = KeyInputX * Time.deltaTime * 100f;
        float deltaAngleV = -KeyInputY * Time.deltaTime * 100f; //上下移動のみスティックがリバースしているため-1をかけています

        // 角度を積算する
        angleH += deltaAngleH;
        angleV += deltaAngleV;

        // 積算角度を制限する
        //公転
        //float clampedAngleH = Mathf.Clamp(angleH, -180, 180);
        //垂直
        float clampedAngleV = Mathf.Clamp(angleV, -20, 50); //垂直方向のみいい感じに制限

        // クランプ前の積算角からクランプ後の積算角を引いて、どれだけ制限範囲を超えたかを求める
        // もし制限範囲内なら差は0になるが、マイナス側に越えればマイナスの、プラス側ならプラスの角度差が得られる
        //float overshootH = angleH - clampedAngleH;
        float overshootV = angleV - clampedAngleV;

        // 角度差分だけ回転量を調整して、制限を超えないようにしてやる
        // 積算角度も調整後の値に上書きする
        //deltaAngleH -= overshootH;
        deltaAngleV -= overshootV;
        //angleH = clampedAngleH;
        angleV = clampedAngleV;

        /*
        // targetの位置のY軸を中心に、回転（公転）する
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.RotateAround(targetPos, Vector3.up, -deltaAngleH);
        }

        // カメラの垂直移動
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.RotateAround(targetPos, transform.right, deltaAngleV);
        }
        */

        transform.RotateAround(targetPos, Vector3.up, -deltaAngleH); //実際のカメラ移動処理。ifの中に格納しなくてもよさそうだったので出した。というかfloat型のGetAxisを条件に入れたらエラーが出た
        transform.RotateAround(targetPos, transform.right, deltaAngleV);
    }
}