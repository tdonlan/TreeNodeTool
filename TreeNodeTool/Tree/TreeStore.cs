﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using TreeNodeTool;

namespace UnityRPG
{

	public class TreeManifestItem
	{
		public string treePath { get; set; }

		public TreeType treeType { get; set; }

		public string treeName { get; set; }

		public long treeIndex { get; set; }
	}

	public class TreeStore
	{
		public Dictionary<long, ITree> treeDictionary { get; set; }

		private GlobalFlags _globalFlags;

		public GlobalFlags globalFlags {
			get { return _globalFlags; }
			set {
				_globalFlags = value;
				if (treeDictionary != null) {
					foreach (var tree in treeDictionary.Values) {
						tree.globalFlags = value;
					}
				}
			}
		}

		public long currentTreeIndex { get; set; }

		public TreeStore ()
		{
			this.globalFlags = new GlobalFlags ();
			this.treeDictionary = new Dictionary<long, ITree> ();
		}

		public ITree getCurrentTree ()
		{
			if (treeDictionary.ContainsKey (currentTreeIndex)) {
				return treeDictionary [currentTreeIndex];
			}
			return null;
		}

		public ITree getTree (long index)
		{
			if (treeDictionary.ContainsKey (index)) {
				return treeDictionary [index];
			}
			return null;
		}

		public void SelectTree (long index)
		{
			if (treeDictionary.ContainsKey (index)) {
				this.currentTreeIndex = index;
			}
		}

		//iterate through all trees, return those that have valid quest string lists
		public List<List<string>> getQuestStringLists ()
		{
			List<List<string>> questStrLists = new List<List<string>> ();
			foreach (var tree in treeDictionary.Values) {
				if (tree is QuestTree) {

					var questStrList = ((QuestTree)tree).getQuestDisplay ();
					if (questStrList.Count > 0) {
						questStrLists.Add (questStrList);
					}
				}
			}

			return questStrLists;
		}

		public List<TreeStoreValidation> validate (GameDataSet gs)
		{
			List<TreeStoreValidation> validationList = new List<TreeStoreValidation> ();
			foreach (var tree in treeDictionary.Values) {
				validationList.AddRange (tree.validate (this, gs));
			}

			return validationList;
		}
        


	}
}