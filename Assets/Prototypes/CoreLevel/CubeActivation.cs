using TMPro;
using UnityEngine;

namespace Prototypes.CoreLevel
{
    public class CubeActivation : MonoBehaviour
    {
        private const float MaxHealth = 100;

        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private TextMeshProUGUI _textMeshPro;

        private float _defaultAlbedo;
        private int _playersTouching = 0;
        private float _health = MaxHealth;

        private void Awake()
        {
            Color.RGBToHSV(_meshRenderer.material.color, out _, out _, out _defaultAlbedo);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Player>() != null)
            {
                ++_playersTouching;
            }
        }
    
        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<Player>() != null)
            {
                --_playersTouching;
            }
        }

        private void Update()
        {
            if (_playersTouching < 0)
            {
                _playersTouching = 0;
            }

            if (_playersTouching == 0)
            {
                _textMeshPro.enabled = false;
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    _health += 20;
                }
            
                if (_health > MaxHealth)
                {
                    _health = MaxHealth;
                }

                _textMeshPro.enabled = true;
            }

            _health -= 5 * Time.deltaTime;
            if (_health < 0)
            {
                _health = 0;
            }

            var greenHue = 120f / 360;
            var hue = _health / MaxHealth * greenHue;
        
            const float numberOfPlayers = 1;
            var brightness = _defaultAlbedo + (1 - _defaultAlbedo) * _playersTouching / numberOfPlayers;
        
            _meshRenderer.material.color = Color.HSVToRGB(hue, 1, brightness);
        }
    }
}
