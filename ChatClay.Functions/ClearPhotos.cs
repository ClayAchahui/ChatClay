using System;
using ChatClay.Functions.Helpers;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace ChatClay.Functions
{
	public static class ClearPhotos
	{
		[FunctionName("ClearPhotos")]
		public async static void Run([TimerTrigger("0 */60 * * * *")]TimerInfo myTimer, ILogger log)
		{
			await StorageHelper.Clear();
		}
	}
}
