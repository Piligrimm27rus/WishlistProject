using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace WishlistLibrary
{
    public abstract class ControllerBase
    {
        /// <summary>
        /// Сохранение файла
        /// </summary>
        /// <typeparam name="T">Тип данных</typeparam>
        /// <param name="fileName">Название файла</param>
        /// <param name="data">Данные для сохранения</param>
        protected void Save<T>(string fileName, T data)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, data);
            }
        }

        /// <summary>
        /// Загрузка файла
        /// </summary>
        /// <typeparam name="T">Тип данных</typeparam>
        /// <param name="fileName">Название файла</param>
        /// <returns>Возвращает список данных или Null если таково файла нет или он пуст<returns>
        protected T Load<T>(string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = File.Open(fileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is T data)
                {
                    return data;
                }
                else
                {
                    return default;
                }
            }
        }
    }
}
