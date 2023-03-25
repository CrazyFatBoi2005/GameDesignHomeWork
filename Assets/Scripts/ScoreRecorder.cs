using TMPro;
using UnityEngine;

public class ScoreRecorder : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _finalScoreText;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip confrim;
    [SerializeField] private AudioClip reject;

    private int _score;

    private void Start()
    {
        _score = 0;
    }

    public void AddScore(bool positive)
    {
        if (positive)
        {
            _score += 1;
            _audioSource.PlayOneShot(confrim);
            _scoreText.text = $"Файлов Отсортированно: {_score}";
            _finalScoreText.text = $"Файлов Отсортированно: {_score}";
        }
        else
        {
            _score -= 1;
            _audioSource.PlayOneShot(reject);
            _scoreText.text = $"Файлов Отсортированно: {_score}";
            _finalScoreText.text = $"Файлов Отсортированно: {_score}";
        }
    }
}
