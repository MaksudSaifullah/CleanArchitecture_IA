using Internal.Audit.Application.Contracts.Persistent.Questionnnaires;
using Internal.Audit.Domain.Entities.BranchAudit;
using Internal.Audit.Infrastructure.Persistent;
using Internal.Audit.Infrastructure.Persistent.Repositories;

public class QuestionnaireCommandRepository : CommandRepositoryBase<Questionnaire>, IQuestionnaireCommandRepository
{
    public QuestionnaireCommandRepository(InternalAuditContext context) : base(context)
    {
    }
}