public class ScoreModel
{
    public int Score { get; private set; }

    public event System.Action<int> OnScoreChanged;

    public void AddScore(int amount)
    {
        Score += amount;
        OnScoreChanged?.Invoke(Score);
    }

    public void Reset()
    {
        Score = 0;
        OnScoreChanged?.Invoke(Score);
    }
}
