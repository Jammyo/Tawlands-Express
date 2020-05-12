using System.Collections;
using Tawlands.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Player _player;

    [SerializeField] private Image _overlay;
    [SerializeField] private TextMeshProUGUI _gameOverText;

    [SerializeField] private TextMeshProUGUI _progressText;

    private bool _isGameOver = false;
    
    private void Update()
    {
        _progressText.text = $"{100 + (int)_player.transform.position.x} meters to go!";
        
        if (_isGameOver)
        {
            return;
        }
        
        if (_player.Health <= 0)
        {
            //Game over - lose.
            _isGameOver = true;
            _overlay.color = new Color(1, 0.1f, 0, 0);
            _gameOverText.text = "You Lose. :(";
            _gameOverText.enabled = true;

            StartCoroutine(FadeIn());
        }

        if (_player.transform.position.x <= -100 && _player.Health > 0)
        {
            //Game over - victory.
            _isGameOver = true;
            _overlay.color = new Color(0, 1, 0.1f, 0);
            _gameOverText.text = "You Win! :)";
            _gameOverText.enabled = true;
            
            StartCoroutine(FadeIn());
        }
    }

    private IEnumerator FadeIn()
    {
        var alpha = 0f;
        var color = _overlay.color;
        while (alpha < 1)
        {
            color = new Color(color.r, color.g, color.b, alpha);
            _overlay.color = color;
            alpha += Time.deltaTime / 5;
            yield return null;
        }
    }
}
