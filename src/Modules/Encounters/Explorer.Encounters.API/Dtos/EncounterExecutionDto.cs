using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Encounters.API.Dtos;

public class EncounterExecutionDto
{
    public string Id { get; set; }
    public long UserId { get; set; }
    public long EncounterId { get; set; }
    public DateTime? CompletionTime { get; set; }
    public bool IsCompleted { get; set; }
}
