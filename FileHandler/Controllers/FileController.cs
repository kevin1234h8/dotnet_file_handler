using Microsoft.AspNetCore.Mvc;

namespace FileHandler.Controllers
{
    [ApiController]
    [Route("/api/v1/files")]
    public class FileController : ControllerBase
    {
        /*     private readonly ILogger<WeatherForecastController> _logger;
             public FileController(ILogger<FileController> logger)
             {
                 _logger = logger;
             }
     */
        [HttpGet]
        public async Task<ActionResult> GetFiles()
        {
            string[] lines = { "first", "second", "third" };
            string docPath = Environment.CurrentDirectory;
            string filePath = Path.Combine(docPath, "file", "WriteLines.txt");

            SaveToFile(lines, filePath);

            // Uncomment the line below to read and return the file content
            // string fileContent = ReadFromFile(filePath);

            return Ok(new { docPath, filePath });
        }

        private void SaveToFile(string[] lines, string filePath)
        {
            using (StreamWriter outputFile = new StreamWriter(filePath))
            {
                foreach (string line in lines)
                    outputFile.WriteLine(line);
            }
        }

        private string ReadFromFile(string filePath)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                return sr.ReadToEnd();
            }
        }
    }
}
