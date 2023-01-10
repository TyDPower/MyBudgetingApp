using MyBudgetingApp.Shared.Dtos.PermissionDtos;

namespace MyBudgetingApp.Server.Services.WalletService
{
    public class WalletService : IWalletService
    {
        private readonly IWalletRepository _walletRepository;
        private readonly DtoMapper<Wallet, WalletDto> _dtoMapper;
        private readonly DtoMapper<WalletDto, Wallet> _objMapper;

        public WalletService(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
            _dtoMapper = new DtoMapper<Wallet, WalletDto>();
            _objMapper = new DtoMapper<WalletDto, Wallet>();
        }

        public async Task<Guid> AddAsync(WalletDto dto)
        {
            var obj = _objMapper.Map(dto);
            return await _walletRepository.AddAsync(obj);
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            // Delete the Permission from the database
            await _walletRepository.DeleteByIdAsync(id);
        }

        public async Task<WalletDto> GetByIdAsync(Guid id)
        {
            var obj = await _walletRepository.GetByIdAsync(id);
            return _dtoMapper.Map(obj);
        }

        public async Task<IEnumerable<WalletDto>> GetListByUserIdAsync(Guid userId)
        {
            var objList = await _walletRepository.GetListByUserIdAsync(userId);
            return objList.Select(x => _dtoMapper.Map(x));
        }

        public async Task UpdateAsync(WalletDto dto)
        {
            var obj = _objMapper.Map(dto);
            await _walletRepository.UpdateAsync(obj);
        }
    }
}
