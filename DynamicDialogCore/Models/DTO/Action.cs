using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicDialogCore.Models.DTO
{
#if !(NETCOREAPP1_0)
    [Serializable]
#endif
    public class Action
    {
        public string Id { get; set; }
        public Image Image { get; set; }
        public string Text { get; set; }
        public string ShortActionText { get; set; }
        public string Slug { get; set; }
        public List<string> SideEffects { get; set; }
        public List<string> TrackingTags { get; set; }
        public string NextResponseId { get; set; }

        public string GetSideEffectsAsString()
        {
            if (SideEffects == null || !SideEffects.Any())
                return string.Empty;

            int numSideEffects = SideEffects.Count;
            if (numSideEffects == 1)
                return SideEffects[0];
            var sideeffects = string.Empty;
            for (int i = 0; i < numSideEffects - 1; i++)
                sideeffects += SideEffects[i] + "#";
            sideeffects += sideeffects[numSideEffects - 1];
            return sideeffects;
        }
    }
}
