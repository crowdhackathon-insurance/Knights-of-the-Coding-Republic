using Ilida.Api.Dtos;
using Ilida.Api.Models;

namespace Ilida.Api.Mappers
{
    public class AccidentActionDtoMapper : BaseMapper<AccidentAction, AccidentActionDto>
    {
        public override AccidentActionDto Map(AccidentAction action)
        {
            if (action == null) return null;

            return new AccidentActionDto
            {
                Id = action.Id,
                Timestamp = action.Timestamp,
                Comment = action.Comment,
                WorkflowAction = action.WorkflowAction,
                PreviousWorkflowStatusId = action.PreviousWorkflowStatusId,
                NextWorkflowStatusId = action.NextWorkflowStatusId
            };
        }
    }
}