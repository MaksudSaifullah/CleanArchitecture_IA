using Internal.Audit.Domain.Entities.BranchAudit;

namespace Internal.Audit.Application.Contracts.Persistent.Questionnnaires;

public interface IQuestionnaireCommandRepository : IAsyncCommandRepository<Questionnaire>
{
}

