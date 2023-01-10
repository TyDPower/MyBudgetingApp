using MyBudgetingApp.Server.Data.Repositories.WalletRepository;

namespace MyBudgetingApp.Server.Services.WalletService
{
    public class WalletService : IWalletService
    {
        private readonly IWalletRepository _walletRepository;
        private readonly DtoMapper<Wallet, WalletDto> _walletMapper;

        public WalletService(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
            _walletMapper = new DtoMapper<Wallet, WalletDto>();
        }

        public async Task<IEnumerable<WalletDto>> GetWalletsAsync()
        {
            var walletList = await _walletRepository.GetWalletsAsync();
            //Map to WalletDto and return data
            return walletList.Select(wallet => _walletMapper.Map(wallet));
        }

        public async Task<WalletDto> GetWalletByIdAsync(int id)
        {
            var wallet = await _walletRepository.GetWalletByIdAsync(id);
            //Map to WalletDto and return data
            return _walletMapper.Map(wallet);
        }

    }
}
