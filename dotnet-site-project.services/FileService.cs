
using dotnet_site_project.services.Models;

namespace dotnet_site_project.services
{
    public interface IFileService
    {
        List<FileListItemModel> GetFileList();
        //FileListItemModel GetFile(string name);
        string GetFilePreview(string path, int offset = 0, int length = 1050);
        Stream GetFileStream(string path);
    }

    public class FileService : IFileService
    {
        public FileService()
        {

        }

        //public FileModel GetFile(string name)
        //{
        //    throw new NotImplementedException();
        //}

        public List<FileListItemModel> GetFileList()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files");

            List<FileListItemModel> ret = new List<FileListItemModel>();
            foreach (var file in Directory.GetFiles(path))
            {
                ret.Add(new FileListItemModel
                {
                    FileName = Path.GetFileName(file)
                });
            }

            return ret;
        }

        public string GetFilePreview(string fileName, int offset = 0, int length = 1050)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files");
            var fileNameWithPath = Path.Combine(path, Path.GetFileName(fileName));
            if (!File.Exists(fileNameWithPath))
                return "File not exists";

            byte[] stringBytes = new byte[length];
            int bytesRead = 0;
            using (var stream = new FileStream(fileNameWithPath, FileMode.Open))
            {
                bytesRead = stream.Read(stringBytes, offset, length);
            }

            string preview = System.Text.Encoding.Default.GetString(stringBytes, 0, bytesRead);
            return preview;
        }

        public Stream GetFileStream(string fileName)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");
            var fileNameWithPath = Path.Combine(path, Path.GetFileName(fileName));

            if (!File.Exists(fileNameWithPath)) 
                return null;

            try
            {
                using (var stream = new FileStream(fileNameWithPath, FileMode.Open, FileAccess.Read))
                {
                    var memoryStream = new MemoryStream();
                    stream.CopyTo(memoryStream);
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    return memoryStream;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}