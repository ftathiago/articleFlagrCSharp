using System.Collections.Generic;

namespace FlagrExample.FlagrResolver.Response
{
    public class EvalContext
    {
        public EvalContext()
        {
            FlagTags = new List<string>();
        }

        public string EntityID { get; set; }
        public string EntityType { get; set; }
        public object EntityContext { get; set; }
        public string EnableDebug { get; set; }
        public int FlagID { get; set; }
        public string FlagKey { get; set; }
        public List<string> FlagTags { get; }
    }
}