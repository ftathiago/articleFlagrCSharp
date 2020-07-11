using System;
using System.Threading.Tasks;
using FlagrExample.FlagrResolver.Request;
using FlagrExample.FlagrResolver.Response;
using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FlagrExample.FlagrResolver.Impl
{
    public class FlagResolver : IFlagResolver
    {
        public EvaluationResponse ResolveFlag<T>(object entityContext)
        {
            var request = GetRequest(typeof(T), entityContext);
            return GetFlag(request).Result;
        }

        private EvaluationRequest GetRequest(Type type, object entityContext) =>
            new EvaluationRequest
            {
                FlagKey = type.Name,
                EntityContext = entityContext,
            };

        private async Task<EvaluationResponse> GetFlag(EvaluationRequest request)
        {
            const string url = "http://localhost:18000/api";
            var response = await url
                .ConfigureRequest(settings =>
                {
                    var jsonSettings = new JsonSerializerSettings
                    {
                        NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                        ContractResolver = new CamelCasePropertyNamesContractResolver(),
                        ObjectCreationHandling = ObjectCreationHandling.Replace
                    };
                    settings.JsonSerializer = new NewtonsoftJsonSerializer(jsonSettings);
                })
                .AppendPathSegment("v1")
                .AppendPathSegment("evaluation")
                .AllowAnyHttpStatus()
                .PostJsonAsync(request)
                .ReceiveJson<EvaluationResponse>()
                .ConfigureAwait(false);
            return response;
        }
    }
}