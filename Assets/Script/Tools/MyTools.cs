using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

public class MyTools
{
    //unity 特殊文件路径 对应ios和安卓实际文件夹    //IOS                                        //Android:
    //Application.persistentDataPath :              Application/xxxxx/Documents                  data/data/xxx.xxx.xxx/files
    //Application.temporaryCachePath :              Application/xxxx/Library/Caches              data/data/xxx.xxx.xxx/cache

    /// <summary>
    /// 序列化  --本地存储
    /// </summary>
    public static void Serial<T>(T[] items, string path)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T[]));
        TextWriter writer = new StreamWriter(path);
        try
        {
            xmlSerializer.Serialize(writer, items);
        }
        finally
        {
            writer.Close();
        }
    }

    /// <summary>
    /// 反序列化  --本地存储
    /// </summary>
    public static T[] Deserial<T>(string path)
    {
        if (!File.Exists(path)) return new T[0];
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T[]));
        FileStream fs = new FileStream(path, FileMode.Open);
        T[] items;
        try
        {
            items = (T[])xmlSerializer.Deserialize(fs);
        }
        finally
        {
            fs.Close();
        }
        return items;
    }


    /// <summary>  
    /// 序列化  --网络传输
    /// </summary>
    public static byte[] Serialize<T>(T obj)
    {
        BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        MemoryStream stream = new System.IO.MemoryStream();
        formatter.Serialize(stream, obj);
        byte[] data = stream.GetBuffer();
        return data;
    }

    /// <summary>  
    /// 反序列化  --网络传输
    /// </summary>   
    public static T Deserialize<T>(byte[] data)
    {
        BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        MemoryStream stream = new System.IO.MemoryStream(data);
        data = null;
        T obj = (T)formatter.Deserialize(stream);
        return obj;
    }
}
