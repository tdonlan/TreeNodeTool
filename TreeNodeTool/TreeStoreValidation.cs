using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TreeNodeTool
{
	public enum ValidationErrorType
	{
		MissingBranchLink,
		MissingLink,
		MismatchedType,
		MissingItem,
		MissingFlag,
		MissingCharacter,
		Other
	}

	public class TreeStoreValidation
	{
		public string treeName;
		public string nodeName;
		public long nodeIndex;
		public string line;
		public string errorText;

		[JsonConverter (typeof(StringEnumConverter))]
		public ValidationErrorType errorType;

		public TreeStoreValidation (string treeName, string nodeName, long nodeIndex, string line, ValidationErrorType type)
		{
			this.treeName = treeName;
			this.nodeName = nodeName;
			this.nodeIndex = nodeIndex;
			this.line = line;
			this.errorType = type;
		}
	}


}

