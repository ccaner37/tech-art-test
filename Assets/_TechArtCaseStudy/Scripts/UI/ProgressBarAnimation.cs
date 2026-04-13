using Appodeal.TechartCaseStudy.AudioEffect;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace AppoDeal.TehartCaseStudy.UI
{
    public class ProgressBarAnimation : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Slider _progressBar;
        [SerializeField] private TextMeshProUGUI _progressText;

        private const float FillDuration = 0.6f;
        private const float StartValue = 650f;
        private const float EndValue = 2000f;

        private void Start()
        {
            _button.onClick.AddListener(OnPlayClicked);
            UpdateText(StartValue);
        }

        public void OnPlayClicked()
        {
            _progressBar.value = 0.075f; // Hardcoded for testing purposes
            _button.interactable = false;

            AudioService.Instance.PlaySound(GameAudioType.ButtonClick);

            Sequence sequence = DOTween.Sequence();

            sequence.InsertCallback(0.2f, () =>
            {
                 AudioService.Instance.PlaySound(GameAudioType.Progress);
            });

            sequence.Append(
                _progressBar.DOValue(1f, FillDuration)
                    .SetEase(Ease.InOutQuad)
            );

            sequence.Join(
                DOVirtual.Float(StartValue, EndValue, FillDuration, (currentValue) =>
                {
                    UpdateText(currentValue);
                }).SetEase(Ease.InOutQuad)
            );

            sequence.OnComplete(() =>
            {
                AudioService.Instance.PlaySound(GameAudioType.Success);
                _button.interactable = true;
            });
        }

        private void UpdateText(float value)
        {
            if (value >= 1000f)
            {
                _progressText.text = (value / 1000f).ToString("0.#") + "K / 2K";
            }
            else
            {
                _progressText.text = Mathf.RoundToInt(value).ToString() + " / 2K";
            }
        }

        private void OnDestroy()
        {
            transform.DOKill();
            _progressBar.DOKill();
        }
    }
}