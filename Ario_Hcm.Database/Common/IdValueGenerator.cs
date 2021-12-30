using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Ario_Hcm.Database.Common
{
    public class IdValueGenerator : ValueGenerator
    {
        public override bool GeneratesTemporaryValues => false;

        protected override object NextValue([NotNull] EntityEntry entry)
        {
            return Guid.NewGuid()
                .ToString()
                .Replace("-", "");
        }
    }
}
