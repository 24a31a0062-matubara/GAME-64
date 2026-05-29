using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private ScorePresenter presenter;

    [SerializeField] private ScoreView scoreView;

    void Start()
    {
        var model = new ScoreModel();
        presenter = new ScorePresenter(model, scoreView);

        presenter.ResetScore();
    }

    public void AddScore(int amount)
    {
        presenter.AddScore(amount);
    }
}
