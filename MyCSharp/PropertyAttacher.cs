using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSharp
{

	public class PropertyAttacher<T>
	{

		protected Dictionary<T, Property> properties;

		public PropertyAttacher(bool autoCreate)
		{
			properties = new Dictionary<T, Property>();
		}

		protected class Property
		{

			public Property(object x)
			{
				ActualObject = x;
				index = GlobalIndex;
				checked
				{
					++GlobalIndex;
				}
			}

			public readonly object ActualObject;

			protected static int GlobalIndex = 0;

			protected readonly int index;

			public override int GetHashCode()
			{
				return index;
			}

		}

		public PT Get<PT>(T x) where PT: class
		{
			var property = properties[x];
			return (PT)property.ActualObject;
		}



	}

}
