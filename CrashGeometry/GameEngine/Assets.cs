using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace CrashGeometry.GameEngine
{
	public class Assets
	{
		private static Assets instance;
		public const string PATH_ASSETS = @"Assets\";
		private Assets()
		{
			try
			{
				if (!Directory.Exists(PATH_ASSETS))
					Directory.CreateDirectory(PATH_ASSETS);
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Ошибка: \n" + ex.ToString(), "Ошибка записи");
			}
		}
		public bool SaveObject(string name, Object obj)
		{
			bool isSave = false;
			try
			{
				XmlSerializer ser = new XmlSerializer(obj.GetType());

				using (Stream stream = new FileStream(name, FileMode.Create))
				{
					ser.Serialize(stream, obj);
				}
				isSave = true;
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Ошибка: \n" + ex.ToString(), "Ошибка записи");
				isSave = false;
			}
			return isSave;
		}
		public T LoadObject<T>(string name)
		{
			T result = (T)new Object();
			try
			{
				XmlSerializer ser = new XmlSerializer(typeof(T));

				using (Stream stream = new FileStream(name, FileMode.Open))
				{
					result = (T)ser.Deserialize(stream);
				}
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Ошибка: \n" + ex.ToString(), "Ошибка записи");
			}

			return result;
		}
		public static Assets GetInstance()
		{
			if (instance == null)
				instance = new Assets();
			return instance;
		}
	}
}
