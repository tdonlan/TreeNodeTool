using System;
using System.IO;
using System.Linq;
using UnityRPG;

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
	}
}
