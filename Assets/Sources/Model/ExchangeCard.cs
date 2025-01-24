using System;
using System.Net.Http;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json.Linq;
using View;

namespace Model
{
    public class ExchangeCard
    {
        private string _currencyName;
        private const string API_URL = "https://api.exchangerate-api.com/v4/latest/RUB";
        private ExchangeCardView _cardView;

        public ExchangeCard(ExchangeCardView cardView, string currencyName)
        {
            _cardView = cardView;
            _currencyName = currencyName;

            GetExchangeRatesAsync();
        }

        public async void GetExchangeRatesAsync()
        {
            int delayBetweenRequests = 30;

            while (_cardView.enabled)
            {
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        HttpResponseMessage response = await client.GetAsync(API_URL);
                        response.EnsureSuccessStatusCode();

                        string responseBody = await response.Content.ReadAsStringAsync();
                        JObject jsonResponse = JObject.Parse(responseBody);
                        decimal rate = jsonResponse["rates"][_currencyName].Value<decimal>();
                        _cardView.ResetText(rate);
                    }
                    catch (Exception ex)
                    {
                    }
                }

                await UniTask.WaitForSeconds(delayBetweenRequests);
            }
        }
    }
}