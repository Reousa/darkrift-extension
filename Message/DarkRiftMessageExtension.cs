namespace DarkRift.Extension.Message
{
	public static class DarkRiftMessageExtension
	{
		public static bool IsEmpty(this DarkRift.Message message)
		{
			return message.DataLength < 1;
		}

		/// <summary>
		/// Extension shorthand for extracting messages.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="e"></param>
		/// <returns></returns>
		public static T ExtractMessage<T>(this DarkRift.Client.MessageReceivedEventArgs e) where T : IDarkRiftSerializable, new()
		{
			using (DarkRift.Message message = e.GetMessage())
			using (DarkRiftReader reader = message.GetReader())
			{
				return message.Deserialize<T>();
			}
		}

		/// <summary>
		/// Extension shorthand for extracting messages.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="e"></param>
		/// <returns></returns>
		public static T ExtractMessage<T>(this DarkRift.Server.MessageReceivedEventArgs e) where T : IDarkRiftSerializable, new()
		{
			using (DarkRift.Message message = e.GetMessage())
			using (DarkRiftReader reader = message.GetReader())
			{
				return message.Deserialize<T>();
			}
		}
	}
}
