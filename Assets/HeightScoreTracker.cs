using UnityEngine;

public class HeightScoreTracker : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameManager gameManager;

    private float highestY;

    void Start()
    {
        highestY = player.position.y;
    }

    void Update()
    {
        float currentY = player.position.y;

        if (currentY > highestY)
        {
            int add = Mathf.CeilToInt(currentY - highestY);
            highestY = currentY;

            if (add > 0)
            {
                gameManager.AddScore(add);
            }
        }
    }
}
