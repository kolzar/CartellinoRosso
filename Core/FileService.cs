using CartellinoRosso.Core.Interface;

namespace CartellinoRosso.Core
{
    public class FileService : IFileService
    {

        public FileService() { }
        

        public string ExtractRandomName(string filePath)
        {
            try
            {
                var names = File.ReadAllLines(filePath)
                               .Where(name => !string.IsNullOrWhiteSpace(name))
                               .ToList();

                if (!names.Any())
                    throw new InvalidOperationException("The file does not contain any valid names.");

                Random random = new Random();
                int index = random.Next(names.Count);

                return names[index];
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while extracting a name from {filePath}.", ex);
            }
        }
    }

}
