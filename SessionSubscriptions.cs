using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.AspNetCore.Http;

namespace webapisample
{
    public record SimplePayload(
           string Name
    );

    [ExtendObjectType(Name = "Subscription")]
    public class SessionSubscriptions
    {
        [SubscribeAndResolve]
        public async IAsyncEnumerable<SimplePayload> OnSessionEvent(
          [Service] IHttpContextAccessor httpAcc,
          CancellationToken cancellationToken
          )
        {
            
            var txt = "Subscription Called!";
            Console.WriteLine(txt);

            //Send Initial Text
            yield return new SimplePayload(txt);

            //Loop untill task is cancelled
            var num = 0;
            while (!cancellationToken.IsCancellationRequested)
            {
                num++;
                await Task.Delay(TimeSpan.FromSeconds(1)); // Delay task for 1 sec
                Console.WriteLine($"Task Is  Running, Counter: {num}");
            }

            // Send End Text
            Console.WriteLine(new SimplePayload("Subscription cancalled! ................"));
            yield break;
        }
    }
}
