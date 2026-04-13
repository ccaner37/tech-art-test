using Appodeal.TechartCaseStudy.AudioEffect;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace AppoDeal.TehartCaseStudy.UI
{
    public class ProgressBarAnimation : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Slider _progressBar;

        private const float FillDuration = 0.6f;

        private void Start()
        {
            _button.onClick.AddListener(OnPlayClicked);
        }

        public void OnPlayClicked()
        {
            _progressBar.value = 0.075f; // Hardcoded only for testing

            _button.interactable = false;

            AudioService.Instance.PlaySound(GameAudioType.ButtonClick);

            Sequence sequence = DOTween.Sequence();

            // 2. BUTON ANİMASYONU
            //_playButton.transform.DOPunchScale(Vector3.one * -0.1f, 0.3f, 10, 1);

            sequence.InsertCallback(0.2f, ()=>
            {
                 AudioService.Instance.PlaySound(GameAudioType.Progress);
            });

            sequence.Append(
            _progressBar.DOValue(1f, FillDuration)
                .SetEase(Ease.InOutQuad)
                .OnComplete(() =>
                {

                    AudioService.Instance.PlaySound(GameAudioType.Success);
                    _button.interactable = true;
                }));
        }
    }

}