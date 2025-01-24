using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class ExchangeCardView : MonoBehaviour
    {
        [SerializeField] private Text _value;

        public void ResetText(decimal value)
        {
            string newValue = value.ToString();
            _value.text = newValue;
        }
    }
}