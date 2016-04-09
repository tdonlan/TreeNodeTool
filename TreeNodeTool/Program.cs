using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

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
			string dataPath = args [2];

			GameDataSet gs = new GameDataSet (dataPath);

			TreeStore ts = loadSimpleFromDirectory (inPath);
			if (ts != null) {
				var validateList = ts.validate (gs);
				if (validateList.Count == 0) {
					exportTreeStore (ts, outPath);
				} else {
					exportTreeStoreValidation (validateList, outPath);
				}
			}
		}

		public static TreeStore loadSimpleFromDirectory (string path)
		{
			string manifestFileName = path + "/" + "manifestSimple.txt";
			var fileList = Directory.GetFiles (path).ToList ();
		

			if (fileList.Contains (manifestFileName)) {
				string manifestStr = File.ReadAllText (manifestFileName);
				TreeStore ts = SimpleTreeParser.LoadTreeStoreFromSimpleManifest (path, manifestStr);
				return ts;

			}
			return null;
		}

		public static void exportTreeStore (TreeStore ts, string path)
		{

			string treeStoreJSON = JsonConvert.SerializeObject (ts);
			File.WriteAllText (path + "/treeStore.json", treeStoreJSON);
		}

		private static void exportTreeStoreValidation (List<TreeStoreValidation> validationList, string path)
		{
			string validationJSON = JsonConvert.SerializeObject (validationList);
			File.WriteAllText (path + "/validationError.json", validationJSON);
		}
	}
}
