using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSharp
{

	public class TypeHierarchyInfo
	{

		public TypeHierarchyInfo(Type type)
		{
			this.type = type;
		}

		protected Type type;

		public List<Type> GetInheritanceLine(bool includeTarget = true)
		{
			var type = this.type;
			Assert.Assigned(type);
			var line = new List<Type>();
			if (includeTarget)
				line.Add(type);
			do
			{
				type = type.BaseType;
				if (type == null)
					break;
				line.Add(type);
			}
			while (true);
			return line;
		}

		public const int AverageMaximumFullClassNameLength = 100;

		public const string Ident = " ";

		// <!> constraint: type != null
		protected string GetAsTextInternal(bool includeTarget = true, bool fullName = true)
		{
			var line = GetInheritanceLine(includeTarget);
			var count = line.Count;
			var text = new StringBuilder(count * AverageMaximumFullClassNameLength);
			if (count > 0)
			{
				int index = count - 1;
				int identIndex = 0;
				do
				{
					Type type = line[index];
					if (type != null)
					{
						var typeName = fullName? type.FullName : type.Name;
						Cycle.Forward(1, identIndex, (i) => text.Append(Ident) );
						text.Append(typeName);
					}
					--index;
					if (0 <= index)
					{
						text.AppendLine();
						++ identIndex;
					}
					else
						break;
				}
				while (true);
			}
			else
				text.Append("No types.");
			return text.ToString();
		}

		public string GetAsText() 
		{
			if (type != null)
				return GetAsTextInternal();
			else
				return "Null type hierarchy";
		}

		public override string ToString()
		{
			return GetAsText();
		}

	}

}
