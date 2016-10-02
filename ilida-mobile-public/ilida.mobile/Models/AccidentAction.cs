using System;

namespace Ilida.Api.Models
{
    public class AccidentAction
    {
        public long Id { get; set; }
        public DateTime Timestamp { get; set; }
        public long PreviousWorkflowStatusId { get; set; }
        public long NextWorkflowStatusId { get; set; }
        public string Comment { get; set; }

        public long AccidentId { get; set; }
        public virtual Accident Accident { get; set; }
        public long UserId { get; set; }
        public virtual User User { get; set; }
        public long WorkflowActionId { get; set; }
        public virtual WorkflowAction WorkflowAction { get; set; }
    }
}