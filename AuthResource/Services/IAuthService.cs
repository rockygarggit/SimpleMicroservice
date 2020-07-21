using Commons.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commons.Services {
    public interface IAuthService {

        SignInResponseDTO SignIn(SignInRequestDTO requestDTO);

    }
}
