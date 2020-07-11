using System.Collections.Generic;

namespace FlagrExample.FlagrResolver.Request
{
    public class EvaluationRequest
    {
        public EvaluationRequest()
        {
            FlagTags = new List<string>();
            EnableDebug = false;
        }

        public string EntityId { get; set; }
        public string EntityType { get; set; }
        public object EntityContext { get; set; }
        public bool EnableDebug { get; set; }
        public string FlagKey { get; set; }
        public List<string> FlagTags { get; }
    }
}