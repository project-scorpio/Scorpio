namespace Scorpio.Auditing
{
    internal class TestContributor : IAuditContributor
    {
        public void PostContribute(AuditContributionContext context) => context.AuditInfo.Comments.Add("PostContribute");

        public void PreContribute(AuditContributionContext context) => context.AuditInfo.Comments.Add("PreContribute");
    }
}