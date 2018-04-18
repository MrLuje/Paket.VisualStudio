using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using Intel = Microsoft.VisualStudio.Language.Intellisense;

namespace Paket.VisualStudio.IntelliSense.CompletionProviders
{
    internal class PaketMissingNugetKeywordCompletionListProvider : ICompletionListProvider
    {
        private readonly ImageSource glyph;
        private readonly IEnumerable<string> validValues;

        public CompletionContextType ContextType
        {
            get { return CompletionContextType.NuGetKeyword; }
        }

        public PaketMissingNugetKeywordCompletionListProvider(Intel.IGlyphService glyphService, IEnumerable<string> validValues)
        {
            if (validValues == null)
                throw new ArgumentNullException("validValues");

            this.glyph = glyphService.GetGlyph(Intel.StandardGlyphGroup.GlyphGroupVariable, Intel.StandardGlyphItem.GlyphItemPublic);
            this.validValues = validValues;
        }

        public IEnumerable<Intel.Completion> GetCompletionEntries(CompletionContext context)
        {
            return validValues.OrderBy(x => x).Select(item => new Intel.Completion2(item, item, null, glyph, "iconAutomationText"));
        }
    }
}
