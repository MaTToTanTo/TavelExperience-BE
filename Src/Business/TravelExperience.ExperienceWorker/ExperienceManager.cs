using TravelExperience.Common;
using TravelExperience.DbContextClass;
using TravelExperience.Entity.Entity;
using TravelExperience.Experience;
using TravelExperience.User;

namespace TravelExperience.ExperienceWorker
{
    public class ExperienceManager
    {
        private readonly IMapperServices<ExperienceEntity, ExperienceDTO> _experienceMapper;
        private readonly IStorageServices<ExperienceEntity> _experienceStorageService;
        private readonly TravelExperienceDBContext _dbContext;


        public ExperienceManager(IMapperServices<ExperienceEntity, ExperienceDTO> experienceMapper, IStorageServices<ExperienceEntity> experienceStorageService, TravelExperienceDBContext dbContext)
        {
            _experienceMapper = experienceMapper;
            _experienceStorageService = experienceStorageService;
            _dbContext = dbContext;
        }

        public async Task<ExperienceDTO> GetExperienceByIdAsync(Guid id)
        {
            ExperienceEntity experienceEntity = await _experienceStorageService.ReadByIdAsync(id);
            return _experienceMapper.ToDTO(experienceEntity);
        }

        public async Task<List<ExperienceDTO>> GetAllExperiencesAsync()
        {
            List<ExperienceEntity> experienceList = await _experienceStorageService.ReadAllAsync();
            /*List<ExperienceDTO> dtoList = new List<ExperienceDTO>();
            foreach (var experience in experienceList) {
                ExperienceDTO experienceDTO = _experienceMapper.ToDTO(experience);
                dtoList.Add(experienceDTO);*/

            return experienceList.Select(experience => _experienceMapper.ToDTO(experience)).ToList();//versione compatta con Linq
        }

        public async Task<List<ExperienceDTO>> GetExperiencesBySearchAsync(string search)

        {
            if (!string.IsNullOrEmpty(search))
            {

                var result = search.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                List<ExperienceEntity> entityList = await _experienceStorageService.ReadBySearchAsync(x =>
                (!string.IsNullOrEmpty(x.Title) &&
                result.Any(word =>
                   x.Title.Contains(word))) ||
                (!string.IsNullOrEmpty(x.Location) &&
                  result.Any(word =>
                   x.Location.Contains(word)))
                  );
                return entityList.Select(entity => _experienceMapper.ToDTO(entity)).ToList();
            }
            return new List<ExperienceDTO>();
        } 

        public async Task CreateExperienceAsync(ExperienceDTO experience, string userID)
        {
            if (string.IsNullOrEmpty(experience.Title) || string.IsNullOrEmpty(experience.Description) || string.IsNullOrEmpty(experience.Information) || string.IsNullOrEmpty(experience.Location))
                throw new Exception("A field is empty");
            
            //experience.HostProfileId = Guid.Parse(userID); aggiungere quando implemento JWT
            experience.CreatedAt = DateTime.UtcNow;
            ExperienceEntity experienceEntity = _experienceMapper.ToEntity(experience);
            await _experienceStorageService.CreateAsync(experienceEntity);
            
        }

        public async Task DeleteExperienceAsync(string experienceId)
        {
            //vedere se serve authorizzation dal jwt
            Guid id = Guid.Parse(experienceId);
            await _experienceStorageService.DeleteAsync(id);
        }

        public async Task UpdateExperienceAsync(ExperienceDTO experience, string userID)
        {
            if (string.IsNullOrEmpty(experience.Title) || string.IsNullOrEmpty(experience.Description) || string.IsNullOrEmpty(experience.Information) || string.IsNullOrEmpty(experience.Location))
                throw new Exception("A field is empty");

            //experience.HostProfileId = Guid.Parse(userID); aggiungere quando implemento JWT
            ExperienceEntity experienceEntity = _experienceMapper.ToEntity(experience);
            await _experienceStorageService.UpdateAsync(experienceEntity);
        }

    } 

}
