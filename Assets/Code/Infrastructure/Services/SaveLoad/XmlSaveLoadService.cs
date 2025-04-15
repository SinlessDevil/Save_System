using Code.Infrastructure.Services.PersistenceProgress;
using Code.Infrastructure.Services.PersistenceProgress.Player;

namespace Code.Infrastructure.Services.SaveLoad
{
    public class XmlSaveLoadService : ISaveLoadService
    {
        private readonly IPersistenceProgressService _progressService;

        public XmlSaveLoadService(IPersistenceProgressService progressService)
        {
            _progressService = progressService;
        }

        public void SaveProgress()
        {
            
        }

        public void Save(PlayerData playerData)
        {
        }

        public PlayerData Load()
        {
            return null;
        }
    }
}