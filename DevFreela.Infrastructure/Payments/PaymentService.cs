using DevFreela.Core.DTOs;
using DevFreela.Core.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Payments
{
    public class PaymentService : IPaymentService
    {
        // Refactoring for use RabbitMQ
        //private readonly IHttpClientFactory _httpClientFactory;
        //private readonly string _paymentsBaseUrl;

        private readonly IMessageBusService _messageBusService;
        private const string QUEUE_NAME = "Payments";
        public PaymentService(IMessageBusService messageBusService)
        {
            // Refactoring for use RabbitMQ
            //_httpClientFactory = httpClientFactory;
            //_paymentsBaseUrl = configuration.GetSection("Services:Payments").Value;

            _messageBusService = messageBusService;
        }

        public void ProcessPayment(PaymentInfoDTO paymentInfoDTO)
        {
            // Refactoring for use RabbitMQ
            //var url = $"{_paymentsBaseUrl}/api/payments";

            //var paymentInfoJson = JsonSerializer.Serialize(paymentInfoDTO);

            //var paymentInfoContent = new StringContent(
            //    paymentInfoJson,
            //    Encoding.UTF8,
            //    "application/json"
            //    );

            //var httpClient = _httpClientFactory.CreateClient("Payments");

            //var response = await httpClient.PostAsync(url, paymentInfoContent);

            //return response.IsSuccessStatusCode;

            var paymentInfoJson = JsonSerializer.Serialize(paymentInfoDTO);

            var paymentInfoBytes = Encoding.UTF8.GetBytes(paymentInfoJson);

            _messageBusService.Publish(QUEUE_NAME, paymentInfoBytes);
        }
    }
}
