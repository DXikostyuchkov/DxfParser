using System.Runtime.InteropServices.JavaScript;
using netDxf;
using Newtonsoft.Json;

// Creates "Main" to please the toolset
return;

public partial class FileProcessor
{
    // Export this method
    [JSExport]
    internal static async Task<int> ProcessFile(byte[] file)
    {
        await Task.Delay(100);
        return file.Length;
    }

    [JSExport]
    internal static async Task<string> ParseDxf(byte[] file)
    {
        await using (MemoryStream stream = new MemoryStream(file))
        {
            DxfDocument document = DxfDocument.Load(stream);
            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            //string json = JsonConvert.SerializeObject( document.Name, settings);
            string json = document.Entities.Inserts.First().Block.Name;
            return json;
        }
        //
        // найстройка отключающая ссылки на себя же в атрибутах (можно убрать если такие атрибуты не используются)
        //

        //
        // обратиться к данным которые нужны для вьювера -> document.Entities...
        // полностью сериализовать document.Entities нельзя, оно много весить будет
        // нужно набрать данных из document.Entities и из них создать сущности и уже их сериализовать
        //

        //
        // если нужно посмотреть через файлик, сохраняем его на диск
        //
        // await using StreamWriter outputFile = new StreamWriter("WriteTextAsync.json");
        // await outputFile.WriteAsync(json);
        // 

    }
}
