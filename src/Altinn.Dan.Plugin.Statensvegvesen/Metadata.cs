using System.Collections.Generic;
using Altinn.Dan.Plugin.Statensvegvesen.Models;
using Nadobe.Common.Interfaces;
using Nadobe.Common.Models;
using Nadobe.Common.Models.Enums;
using Newtonsoft.Json;

namespace Altinn.Dan.Plugin.Statensvegvesen;

public class Metadata : IEvidenceSourceMetadata
{
    public const string SOURCE = "Svv";

    public const int ERROR_ORGANIZATION_NOT_FOUND = 1;

    public static int ERROR_CCR_UPSTREAM_ERROR = 2;


    public List<EvidenceCode> GetEvidenceCodes()
    {
        return new List<EvidenceCode>
        {
            new()
            {
                EvidenceCodeName = "Kjoretoy",
                EvidenceSource = SOURCE,
                BelongsToServiceContexts = new List<string> { "OED" },
                RequiredScopes = "",
                Values = new List<EvidenceValue>
                {
                    new()
                    {
                        EvidenceValueName = "default",
                        ValueType = EvidenceValueType.JsonSchema,
                        JsonSchemaDefintion = JsonConvert.SerializeObject(new SvvResponse())
                    }
                },
                AuthorizationRequirements = new List<Requirement>
                {
                    new MaskinportenScopeRequirement
                    {
                        RequiredScopes = new List<string> { "altinn:dataaltinnno/oed" }
                    }
                }
            }
        };
    }
}
