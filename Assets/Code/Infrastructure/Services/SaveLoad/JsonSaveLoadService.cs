using System;
using Code.Infrastructure.Services.PersistenceProgress;
using Code.Infrastructure.Services.PersistenceProgress.Player;

namespace Code.Infrastructure.Services.SaveLoad
{
    public class JsonSaveLoadService : ISaveLoadService
    {
        private readonly IPersistenceProgressService _progressService;

        public JsonSaveLoadService(IPersistenceProgressService progressService)
        {
            _progressService = progressService;
        }

        public void SaveProgress()
        {
            throw new NotImplementedException();
        }

        public void Save(PlayerData playerData)
        {
            throw new NotImplementedException();
        }

        public PlayerData Load()
        {
            throw new NotImplementedException();
        }
    }
}