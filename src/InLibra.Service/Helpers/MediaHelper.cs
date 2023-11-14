namespace InLibra.Service.Helpers;

public static class MediaHelper
{
    public static string MakeImageName(string fileName)
    {
        var fileInfo = new FileInfo(fileName);
        return "IMG_" + Guid.NewGuid() + fileInfo.Extension;
    }
}