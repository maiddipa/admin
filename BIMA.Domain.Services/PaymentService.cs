using AutoMapper;
using BIMA.Common.Core.Enum;
using BIMA.Database.Entities;
using BIMA.Domain.Models.Public;
using BIMA.Domain.Models.User;
using BIMA.Domain.Repository.Interfaces;
using BIMA.Domain.Services.Interfaces;
using Stripe;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BIMA.Domain.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWorkAsync<Payment> _unitOfWork;
        private readonly IMapper _mapper;


        public PaymentService(IUnitOfWorkAsync<Payment> unitOfWork,
                                  IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<string> StripePaymentFlow(PaymentModel paymentModel, User user, PlanPrice plan)
        {
            var token = await CreateStripeToken(paymentModel);
            var customer = await GetStripeCustomer(token.Id, paymentModel, user);
            var charge = await CreateStripeCharge(customer, plan);

            if(charge.Status == "succeeded" && charge.Paid)
            {

               await _unitOfWork.Payments.AddAsync(new Payment()
                {
                    Created = DateTime.UtcNow,
                    StripeCustomerId = customer.Id,
                    BalanceTransactionId = charge.BalanceTransactionId,
                    ChargeId = charge.Id,
                    UserId = user.Id,
                    Amount = charge.Amount,
                    PlanPrice = (PlanPricesEnum)plan.Id
                });

                await _unitOfWork.SaveChangesAsync();
            }
            else if(charge.Status == "failed")
            {
                throw new Exception("Attempting to chareg failed");
            }

            return charge.Id;

        }

        private async Task<Token> CreateStripeToken(PaymentModel paymentModel)
        {
            var tokenOptions = new TokenCreateOptions
            {
                Card = new TokenCardOptions
                {
                    Number = paymentModel.CardNumber,
                    ExpMonth = paymentModel.Month,
                    ExpYear = paymentModel.Year,
                    Cvc = paymentModel.CVC
                },
            };

            var service = new TokenService();
            return await service.CreateAsync(tokenOptions);
        }

        private async Task<Customer> GetStripeCustomer(string stripeToken, PaymentModel paymentModel, User user)
        {
            var payment = await _unitOfWork.Payments.GetPaymentByUserId(user.Id);
            if (payment != null)
            {
                var service = new CustomerService();
                return await service.GetAsync(payment.StripeCustomerId);
            }
            else
            {
                var customerOptions = new CustomerCreateOptions
                {
                    Email = user.Email,
                    Source = stripeToken,
                    Description = paymentModel.CardHolder,
                    Metadata = new Dictionary<string, string>()
                {
                    { "UserId", user.Id.ToString() }
                },
                };
                var customerService = new CustomerService();
                return await customerService.CreateAsync(customerOptions);
            }

        }

        private async Task<Charge> CreateStripeCharge(Customer customer, PlanPrice plan)
        {
            var options = new ChargeCreateOptions
            {
                Amount = plan.Price,
                Currency = plan.Currency,
                Description = "My First Test Charge (created for API docs)",
                Customer = customer.Id
            };
            var service = new ChargeService();
            return await service.CreateAsync(options);
        }

        public async Task<long> GetPaymentIdByChargeId(string chargeId)
        {
            return await _unitOfWork.Payments.GetPaymentIdByChargeId(chargeId);
        }

    }
}
