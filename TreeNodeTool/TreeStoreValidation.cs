using System;

namespace TreeNodeTool
{
	public enum ValidationErrorType
	{
		MissingBranchLink,
		MissingLink,
		MismatchedType,
		Other
	}

	public class TreeStoreValidation
	{
		public string treeName;
		public string nodeName;
		public long nodeIndex;
		public string line;
		public string errorText;
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

