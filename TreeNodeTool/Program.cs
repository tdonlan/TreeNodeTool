using System;
using System.IO;
using System.Linq;
using UnityRPG;

using Newtonsoft.Json;

namespace TreeNodeTool
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			string inPath = args [0];
			string outPath = args [1];


			TreeStore ts = loadSimpleFromDirectory (inPath);
			if (ts != null) {
				exportTreeStore (ts, outPath);
			}

		}

		public static TreeStore loadSimpleFromDirectory(string path)
		{
			string manifestFileName = path + "/" + "manifestSimple.txt";
			var fileList = Directory.GetFiles (path).ToList();
		

			if (fileList.Contains (manifestFileName)) {
				string manifestStr= File.ReadAllText(manifestFileName);
				TreeStore ts = SimpleTreeParser.LoadTreeStoreFromSimpleManifest (path, manifestStr);
				return ts;

			}
			return null;
		}

		public static void exportTreeStore(TreeStore ts, string path)
		{

			string treeStoreJSON = JsonConvert.SerializeObject (ts);
			File.WriteAllText (path + "/treeStore.json", treeStoreJSON);
		}
	}
}
