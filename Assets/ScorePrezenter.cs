public class ScorePresenter
{
    private ScoreModel model;
    private ScoreView view;

    public ScorePresenter(ScoreModel model, ScoreView view)
    {
        this.model = model;
        this.view = view;

        view.Bind(model);
    }

    public void AddScore(int amount)
    {
        model.AddScore(amount);
    }

    public void ResetScore()
    {
        model.Reset();
    }
}
