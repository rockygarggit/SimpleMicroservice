using Commons.ExceptionHandling.Exceptions;
using System.Collections.Generic;
using ProfileMicroservice.DTO.Profile;
using ProfileMicroservice.DTO.Profile.Request;

namespace ProfileMicroservice.Services.Implementation {
    public class UserService : IProfileService {
        public ProfileResponseDTO Create(CreateProfileRequestDTO requestDTO) {
            // todo
            return new ProfileResponseDTO();
        }

        public List<ProfileResponseDTO> GetAll() {
            // todo
            return new List<ProfileResponseDTO>();
        }
        public ProfileResponseDTO GetOneByUuid(string uuid) {
            // todo
            throw new EntityNotFoundException($"User with uuid: {uuid} does not exist!");
        }

        public ProfileResponseDTO Update(UpdateProfilerRequestDTO requestDTO) {
            // todo
            return new ProfileResponseDTO();
        }
    }
}
