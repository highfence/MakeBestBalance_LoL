using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeBestBalance_LoL
{
	internal class FileManager
	{
		#region SINGLETON
		private static FileManager _instance;

		private FileManager()
		{

		}

		public static FileManager Instace
		{
			get
			{
				if (_instance == null)
					_instance = new FileManager();

				return _instance;
			}
		}
		#endregion

		private string _lastestFileDirectory = null;

		public string OpenSaveFileDirectoryWindow(string windowTitle, string extension, string extensionFilter)
		{
			string savePath = "";

			using (var dialog = new SaveFileDialog())
			{
				if (String.IsNullOrEmpty(_lastestFileDirectory))
				{
					_lastestFileDirectory = @"C:";
				}

				dialog.InitialDirectory = _lastestFileDirectory;
				dialog.Title = windowTitle;
				dialog.DefaultExt = extension;
				dialog.Filter = extensionFilter;
				
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					_lastestFileDirectory = dialog.FileName.ToString();
					savePath = _lastestFileDirectory;
				}
			}

			return savePath;
		}

		public string OpenFileDirectoryWindow(string windowTitle, string extension, string extensionFilter)
		{
			string savePath = "";

			using (var dialog = new OpenFileDialog())
			{
				if (String.IsNullOrEmpty(_lastestFileDirectory))
				{
					_lastestFileDirectory = @"C:";
				}

				dialog.InitialDirectory = _lastestFileDirectory;
				dialog.Title = windowTitle;
				dialog.DefaultExt = extension;
				dialog.Filter = extensionFilter;

				if (dialog.ShowDialog() == DialogResult.OK)
				{
					_lastestFileDirectory = dialog.FileName.ToString();
					savePath = _lastestFileDirectory;
				}
			}

			return savePath;
		}

		public bool SavePlayers(string savePath, List<Player> players)
		{
			if (String.IsNullOrEmpty(savePath) || players == null)
				return false;

			using (var fileStream = File.OpenWrite(savePath))
			{
				var formatter = new BinaryFormatter();

				formatter.Serialize(fileStream, players);

				fileStream.Flush();
				fileStream.Close();
			}

			return true;
		}

		public List<Player> LoadPlayers(string filePath)
		{
			var players = new List<Player>();

			if (String.IsNullOrEmpty(filePath))
				return null;

			using (var fileStream = File.Open(filePath, FileMode.Open))
			{
				var formatter = new BinaryFormatter();

				object obj = formatter.Deserialize(fileStream);
				players = (List<Player>)obj;

				fileStream.Flush();
				fileStream.Close();
			}

			return players;
		}
	}
}
