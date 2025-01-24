using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using DG.Tweening;

namespace View
{
    public class ExchangePanelView : MonoBehaviour
    {
        private List<RectTransform> _rectTransforms = new List<RectTransform>();

        public void Init(List<ExchangeCardView> cards)
        {
            foreach (ExchangeCardView cardView in cards)
            {
                if (cardView.TryGetComponent(out RectTransform rectTransform))
                {
                    _rectTransforms.Add(rectTransform);
                }
            }

            OpenCards();
        }

        private async void OpenCards()
        {
            float openingDelay = 2f;
            float delayBetweenCards = 0.5f;

            foreach (RectTransform rectTransform in _rectTransforms)
            {
                rectTransform.localScale = Vector3.zero;
                rectTransform.DOScale(1, openingDelay);

                await UniTask.WaitForSeconds(delayBetweenCards);
            }
        }
    }
}