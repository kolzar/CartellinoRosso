using CartellinoRosso.Core.Interface;
using Microsoft.Extensions.Configuration;

namespace CartellinoRosso.Core
{
    public class NameService : INameService
    {
        private readonly string _firstNamePath;
        private readonly string _lastNamePath;
        private readonly string _teamList;
        private readonly IConfiguration _config;
        private readonly IFileService _fileService;

        public NameService(IConfiguration config, IFileService fileService)
        {
            _config = config;
            _fileService = fileService;
            _firstNamePath = _config["FilePaths:FirstNameFile"];
            _lastNamePath = _config["FilePaths:LastNameFile"];
            _teamList = _config["FilePaths:TeamListFile"];
        }

        public string ExtractRandomFirstName()
        {
            return _fileService.ExtractRandomName(_firstNamePath);
        }
        
        public string ExtractRandomLastName()
        {
            return _fileService.ExtractRandomName(_lastNamePath);
        }
        
        public string ExtractRandomTeamList()
        {
            return _fileService.ExtractRandomName(_teamList);
        }
    }
}
