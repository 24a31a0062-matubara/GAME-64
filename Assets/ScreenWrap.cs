using UnityEngine;

public class HorizontalWrap : MonoBehaviour
{
    private float screenHalfWidth;

    void Start()
    {
        // カメラの横幅を計算（縦サイズ × アスペクト比）
        screenHalfWidth = Camera.main.orthographicSize * Camera.main.aspect;
    }

    void Update()
    {
        Vector3 pos = transform.position;

        float leftEdge = Camera.main.transform.position.x - screenHalfWidth;
        float rightEdge = Camera.main.transform.position.x + screenHalfWidth;

        if (pos.x < leftEdge)
        {
            pos.x = rightEdge;
            transform.position = pos;
        }
        else if (pos.x > rightEdge)
        {
            pos.x = leftEdge;
            transform.position = pos;
        }
    }
}
