using StaticData;
using UnityEngine;

namespace Code.Infrastructure.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string BalanceStaticDataPath = "StaticData/Balance/Balance";

        private BalanceStaticData _balanceStaticData;
        
        public BalanceStaticData Balance => _balanceStaticData;

        public void LoadData()
        {
            _balanceStaticData = Resources.Load<BalanceStaticData>(BalanceStaticDataPath);
        }
    }
}