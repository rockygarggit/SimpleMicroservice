using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProfileMicroservice.DTO.Profile;
using ProfileMicroservice.DTO.Profile.Request;

namespace ProfileMicroservice.Services {
    public interface IProfileService : ICrudService<ProfileResponseDTO> {

        ProfileResponseDTO Create(CreateProfileRequestDTO requestDTO);

        ProfileResponseDTO Update(UpdateProfilerRequestDTO requestDTO);

    }
}
