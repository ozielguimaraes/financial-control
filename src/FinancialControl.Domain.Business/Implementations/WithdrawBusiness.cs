using FinancialControl.Domain.Business.Interfaces;
using FinancialControl.Domain.Business.Requests.Withdraw;
using FinancialControl.Domain.Business.Responses;
using FinancialControl.Domain.Business.Responses.Withdraw;
using FinancialControl.Domain.Entities;
using FinancialControl.Domain.Interfaces.Services;

namespace FinancialControl.Domain.Business.Implementations
{
    public class WithdrawBusiness : IWithdrawBusiness
    {
        private readonly IWithdrawService _withdrawService;

        public WithdrawBusiness(IWithdrawService withdrawService)
        {
            _withdrawService = withdrawService;
        }

        public async Task<CreateWithdrawResponse> Create(CreateWithdrawRequest request)
        {
            //TODO Validate
            var withdraw = new Withdraw();

            var result = await _withdrawService.Add(withdraw);

            return new CreateWithdrawResponse(result.WithdrawId, result.Name);
        }

        public async Task<UpdateWithdrawResponse> Update(UpdateWithdrawRequest request)
        {
            //TODO Validate
            var withdraw = new Withdraw();
            var result = await _withdrawService.Update(withdraw);
            return new UpdateWithdrawResponse(result.WithdrawId, result.Name);
        }

        public async Task<List<WithdrawResponse>> GetAll()
        {
            var result = _withdrawService.All();
            return await Task.FromResult(result.Select(x => new WithdrawResponse(x.WithdrawId, x.Name)).ToList());
        }

        public async Task<WithdrawResponse> GetById(long withdrawId)
        {
            var result = await _withdrawService.GetById(withdrawId);
            return new WithdrawResponse(result.WithdrawId, result.Name);
        }
    }
}
