using System;

namespace DarkRift.Extension.Message.Core
{
	public interface IDarkRiftMessage<TTag> : IDarkRiftSerializable
	where TTag : struct, Enum, IConvertible
	{
		TTag Tag { get; }
	}
}
