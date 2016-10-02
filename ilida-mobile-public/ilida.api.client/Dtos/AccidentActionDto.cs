using Ilida.Api.Models;
using System;

namespace Ilida.Api.Dtos
{
    public class AccidentActionDto
    {
        public long Id { get; set; }
        public DateTime Timestamp { get; set; }
        public long PreviousWorkflowStatusId { get; set; }
        public long NextWorkflowStatusId { get; set; }
        public string Comment { get; set; }
        public WorkflowAction WorkflowAction { get; set; }
    }
}