namespace DvisualStudio.API.Interfaces
{
    public interface IPhotosService
    {
        string GetImageByReference(string photoReferences,string maxHeight, string maxWidth);
    }
}
