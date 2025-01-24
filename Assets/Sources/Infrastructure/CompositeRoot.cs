using UnityEngine;
using System.Collections.Generic;
using Model;
using View;

namespace Infrastructure
{
    public class CompositeRoot : MonoBehaviour
    {
        [SerializeField] private ExchangeCardView _USDCardView;
        [SerializeField] private ExchangeCardView _JPYCardView;
        [SerializeField] private ExchangeCardView _KZTCardView;
        [SerializeField] private ExchangePanelView _exchangePanel;

        private ExchangeCard USDCard;
        private ExchangeCard JPYCard;
        private ExchangeCard KZTCard;

        private void Start()
        {
            USDCard = new(_USDCardView, "USD");
            JPYCard = new(_JPYCardView, "JPY");
            KZTCard = new(_KZTCardView, "KZT");

            List<ExchangeCardView> cards = new List<ExchangeCardView>() { _USDCardView, _JPYCardView, _KZTCardView };
            _exchangePanel.Init(cards);
        }
    }
}