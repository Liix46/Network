namespace Network.Application.Common.Interfaces;

public interface IFileService
{
     Task<string> SaveFile(string path);
}