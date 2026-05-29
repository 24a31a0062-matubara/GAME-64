using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    public void Bind(ScoreModel model)
    {
        Debug.Log("Bind ŒÄ‚Î‚ê‚½‚æ");
        model.OnScoreChanged += x => scoreText.text = x.ToString();
    }

}
